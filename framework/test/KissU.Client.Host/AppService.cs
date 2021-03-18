using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Models;
using KissU.Modules.Identity.Service.Contracts;
using KissU.ServiceProxy;
using KissU.Extensions;
using Microsoft.Extensions.Options;
using Volo.Abp.Http.Client;
using Volo.Abp.Identity;

namespace KissU.Client.Host
{
    public class AppService : Volo.Abp.DependencyInjection.ITransientDependency
    {
        private static int _endedConnenctionCount;
        private static DateTime begintime;
        private readonly AbpRemoteServiceOptions _remoteServiceOptions;

        public AppService(IOptions<AbpRemoteServiceOptions> remoteServiceOptions)
        {
            _remoteServiceOptions = remoteServiceOptions.Value;
        }

        public async Task RunAsync()
        {
            await TestWithHttpClient();
            await TestForRoutePath();
            TestParallel();
        }

        private async Task TestWithHttpClient()
        {
            Console.WriteLine();
            Console.WriteLine("*** TestWithHttpClient ************************************");

            try
            {
                using (var client = new HttpClient())
                {
                    var url = _remoteServiceOptions.RemoteServices.Default.BaseUrl.EnsureEndsWith('/') + "api/identityuser/getasync/1";
                    var response = await client.GetAsync(url);

                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine(response.StatusCode);
                    }
                    else
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(responseContent);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private async Task TestForRoutePath()
        {
            Console.WriteLine();
            Console.WriteLine("*** TestForRoutePath ************************************");

            try
            {
                var serviceProxyProvider = ServiceLocator.GetService<IServiceProxyProvider>();
                var model = new Dictionary<string, object>
                {
                    {
                        "input",
                        new GetIdentityUsersInput
                        {
                            MaxResultCount = 10
                        }
                    }
                };
                var path = "api/identityuser/getlistasync";
                var serviceKey = "IdentityUser";

                var output = await serviceProxyProvider.Invoke<PagedResult<IdentityUserDto>>(model, path, serviceKey);
                Console.WriteLine($"{output}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void TestParallel()
        {
            Console.WriteLine();
            Console.WriteLine("*** TestParallel ************************************");

            try
            {
                var connectionCount = 300000;
                var sw = new Stopwatch();
                sw.Start();
                var userProxy = ServiceLocator.GetService<IServiceProxyFactory>().CreateProxy<IUserService>("IdentityUser");
                ServiceResolver.Current.Register("IdentityUser", userProxy);
                userProxy = ServiceResolver.Current.GetService<IUserService>("IdentityUser");
                sw.Stop();
                Console.WriteLine($"代理所花{sw.ElapsedMilliseconds}ms");

                do
                {
                    var watch = Stopwatch.StartNew();

                    ThreadPool.SetMinThreads(100, 100);
                    Parallel.For(0, connectionCount / 6000, new ParallelOptions { MaxDegreeOfParallelism = 50 }, async u =>
                    {
                        for (var i = 0; i < 6000; i++)
                        {
                            await StartRequest(userProxy, connectionCount);
                        }
                    });

                    watch.Stop();
                    Console.WriteLine($"调用结束，执行时间：{watch.ElapsedMilliseconds}ms");
                    Console.WriteLine("Press any key to continue, q to exit the loop...");
                    var key = Console.ReadLine();
                    if (key != null && key.ToLower() == "q")
                    {
                        break;
                    }
                } while (true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            async Task StartRequest(IUserService userProxy, int connectionCount)
            {
                var result = await userProxy.GetList(new GetIdentityUsersInput { MaxResultCount = 10 });
                Interlocked.Increment(ref _endedConnenctionCount);
                if (_endedConnenctionCount == 1)
                {
                    begintime = DateTime.Now;
                }

                if (_endedConnenctionCount >= connectionCount)
                {
                    Console.WriteLine($"结束时间{(DateTime.Now - begintime).TotalMilliseconds}");
                }
            }
        }
    }
}