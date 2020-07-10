using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Extensions;
using KissU.Modules.SampleA.Service.Contracts;
using KissU.Modules.SampleA.Service.Contracts.Dtos;
using KissU.Modules.SampleA.Service.Contracts.Events;
using KissU.Surging.CPlatform.Diagnostics;
using KissU.Surging.CPlatform.Transport.Implementation;
using KissU.Surging.ProxyGenerator;
using Microsoft.Extensions.Options;
using Volo.Abp.Http.Client;
using Volo.Abp.IdentityModel;

namespace KissU.ConsoleClient.Host
{
    public class ClientDemoService : Volo.Abp.DependencyInjection.ITransientDependency
    {
        private readonly IIdentityModelAuthenticationService _authenticator;
        private readonly AbpRemoteServiceOptions _remoteServiceOptions;
        private static int _endedConnenctionCount;
        private static DateTime begintime;

        public ClientDemoService(
            IIdentityModelAuthenticationService authenticator, 
            IOptions<AbpRemoteServiceOptions> remoteServiceOptions)
        {
            _authenticator = authenticator;
            _remoteServiceOptions = remoteServiceOptions.Value;
        }

        public async Task RunAsync()
        {
            await TestWithHttpClient(); 
            Test(ServiceLocator.GetService<IServiceProxyFactory>());
        }

        /// <summary>
        /// Shows how to manually create an HttpClient and authenticate using the
        /// IIdentityModelAuthenticationService service.
        /// </summary>
        private async Task TestWithHttpClient()
        {
            Console.WriteLine();
            Console.WriteLine("*** TestWithHttpClient ************************************");

            try
            {
                using (var client = new HttpClient())
                {
                    await _authenticator.TryAuthenticateAsync(client);

                    var serverUrl = _remoteServiceOptions.RemoteServices.Default.BaseUrl.EnsureEndsWith('/');;

                    var url = serverUrl + "api/user/getuserid/{username}?userName=10";

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

        private void StartRequest(int connectionCount)
        {
            var sw = new Stopwatch();
            sw.Start();
            var userProxy = ServiceLocator.GetService<IServiceProxyFactory>().CreateProxy<IUserService>("User");
            ServiceResolver.Current.Register("User", userProxy);
            var service = ServiceLocator.GetService<IServiceProxyFactory>();
            userProxy = ServiceResolver.Current.GetService<IUserService>("User");
            sw.Stop();
            System.Console.WriteLine($"代理所花{sw.ElapsedMilliseconds}ms");
            ThreadPool.SetMinThreads(100, 100);
            Parallel.For(0, connectionCount / 6000, new ParallelOptions { MaxDegreeOfParallelism = 50 }, async u =>
            {
                for (var i = 0; i < 6000; i++)
                    await Test(userProxy, connectionCount);
            });
        }

        public async Task Test(IUserService userProxy, int connectionCount)
        {
            var a = await userProxy.GetDictionary();
            IncreaseSuccessConnection(connectionCount);
        }

        private void IncreaseSuccessConnection(int connectionCount)
        {
            Interlocked.Increment(ref _endedConnenctionCount);
            if (_endedConnenctionCount == 1)
            {
                begintime = DateTime.Now;
            }

            if (_endedConnenctionCount >= connectionCount)
            {
                System.Console.WriteLine($"结束时间{(DateTime.Now - begintime).TotalMilliseconds}");
            }
        }

        /// <summary>
        /// 测试
        /// </summary>
        /// <param name="serviceProxyFactory"></param>
        public void Test(IServiceProxyFactory serviceProxyFactory)
        {
            var tracingContext = ServiceLocator.GetService<ITracingContext>();
            Task.Run(async () =>
            {
                RpcContext.GetContext().SetAttachment("xid", 124);

                var userProxy = serviceProxyFactory.CreateProxy<IUserService>("User");
                var asyncProxy = serviceProxyFactory.CreateProxy<IAsyncService>();
                var result = await asyncProxy.AddAsync(1, 2);
                var user = userProxy.GetUser(new UserModel
                {
                    UserId = 1,
                    Name = "fanly",
                    Age = 120,
                    Sex = 0
                }).GetAwaiter().GetResult();
                var e = userProxy.SetSex(Sex.Woman).GetAwaiter().GetResult();
                var v = userProxy.GetUserId("gongap").GetAwaiter().GetResult();
                var fa = userProxy.GetUserName(1).GetAwaiter().GetResult();
                userProxy.Try().GetAwaiter().GetResult();
                var v1 = userProxy.GetUserLastSignInTime(1).Result;
                var things = userProxy.GetAllThings().Result;
                var apiResult = userProxy.GetApiResult().GetAwaiter().GetResult();
                userProxy.PublishThroughEventBusAsync(new UserEvent
                {
                    UserId = 1,
                    Name = "gongap"
                }).Wait();

                userProxy.PublishThroughEventBusAsync(new UserEvent
                {
                    UserId = 1,
                    Name = "gongap"
                }).Wait();

                var r = await userProxy.GetDictionary();
                var serviceProxyProvider = ServiceLocator.GetService<IServiceProxyProvider>();

                do
                {
                    System.Console.WriteLine("正在循环 1w次调用 GetUser.....");

                    //1w次调用
                    var watch = Stopwatch.StartNew();
                    for (var i = 0; i < 10000; i++)
                    {
                        //var a = userProxy.GetDictionary().Result;
                        var a = await userProxy.GetDictionary();
                        //var result = serviceProxyProvider.Invoke<object>(new Dictionary<string, object>(), "api/user/GetDictionary", "User").Result;
                    }

                    watch.Stop();
                    System.Console.WriteLine($"1w次调用结束，执行时间：{watch.ElapsedMilliseconds}ms");
                    System.Console.WriteLine("Press any key to continue, q to exit the loop...");
                    var key = System.Console.ReadLine();
                    if (key.ToLower() == "q")
                        break;
                } while (true);
            }).Wait();
        }

        public void TestRabbitMq(IServiceProxyFactory serviceProxyFactory)
        {
            serviceProxyFactory.CreateProxy<IUserService>("User").PublishThroughEventBusAsync(new UserEvent
            {
                Age = 18,
                Name = "gongap",
                UserId = 1
            });
            System.Console.WriteLine("Press any key to exit...");
            System.Console.ReadLine();
        }

        public void TestForRoutePath(IServiceProxyProvider serviceProxyProvider)
        {
            var model = new Dictionary<string, object>();
            model.Add("user", new UserModel
            {
                Name = "gongap",
                Age = 18,
                UserId = 1,
                Sex = Sex.Woman
            });
            var path = "api/user/getuser";
            var serviceKey = "User";

            var userProxy = serviceProxyProvider.Invoke<UserModel>(model, path, serviceKey);
            var s = userProxy.Result;
            System.Console.WriteLine($"{s}");
            System.Console.WriteLine("Press any key to exit...");
            System.Console.ReadLine();
        }

        public void TestThriftInvoker(IServiceProxyFactory serviceProxyFactory)
        {
            var proxy = serviceProxyFactory.CreateProxy<IAsyncService>();
            var proxy1 = serviceProxyFactory.CreateProxy<IThirdAsyncService>();
            Task.Run(async () =>
            {
                do
                {
                    var result1 = await proxy.SayHelloAsync();
                    var result2 = await proxy1.SayHelloAsync();
                    System.Console.WriteLine("正在循环 1w次调用 GetUser.....");

                    var watch = Stopwatch.StartNew();

                    for (var i = 0; i < 10000; i++)
                    {
                        try
                        {
                            var result = await proxy.SayHelloAsync();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    watch.Stop();
                    System.Console.WriteLine($"1w次调用结束，执行时间：{watch.ElapsedMilliseconds}ms");
                    System.Console.WriteLine("Press any key to continue, q to exit the loop...");
                    var key = System.Console.ReadLine();
                    if (key.ToLower() == "q")
                        break;
                } while (true);
            }).Wait();

            System.Console.ReadLine();
        }
    }
}