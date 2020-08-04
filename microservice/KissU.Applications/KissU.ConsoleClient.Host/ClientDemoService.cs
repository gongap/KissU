using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Modules.Identity.Application.Contracts;
using KissU.Modules.TenantManagement.Application.Contracts;
using KissU.Surging.CPlatform.Transport.Implementation;
using KissU.Surging.ProxyGenerator;
using Microsoft.Extensions.Options;
using Volo.Abp.Http.Client;
using Volo.Abp.IdentityModel;
using KissU.Extensions;
using KissU.Modules.Identity.Service.Contracts;
using KissU.Modules.SampleA.Service.Contracts;
using KissU.Modules.SampleA.Service.Contracts.Dtos;
using KissU.Modules.SampleA.Service.Contracts.Events;
using KissU.Modules.TenantManagement.Service.Contracts;
using Microsoft.Extensions.Configuration;
using Volo.Abp;
using IdentityModel.Client;
using Volo.Abp.Http;
using Volo.Abp.Json;
using Volo.Abp.Users;

namespace KissU.ConsoleClient.Host
{
    public class ClientDemoService : Volo.Abp.DependencyInjection.ITransientDependency
    {
        private readonly IConfiguration _configuration;
        private readonly ICurrentUser _currentUser;
        private readonly IIdentityModelAuthenticationService _authenticationService;
        private readonly AbpRemoteServiceOptions _remoteServiceOptions;
        private static int _endedConnenctionCount;
        private static DateTime begintime;
        private readonly IJsonSerializer _jsonSerializer;

        public ClientDemoService(
            ICurrentUser currentUser,
            IIdentityModelAuthenticationService authenticationService,
            IConfiguration configuration,
            IOptions<AbpRemoteServiceOptions> remoteServiceOptions, IJsonSerializer jsonSerializer)
        {
            _currentUser = currentUser;
            _authenticationService = authenticationService;
            _configuration = configuration;
            _jsonSerializer = jsonSerializer;
            _remoteServiceOptions = remoteServiceOptions.Value;
        }

        public async Task RunAsync()
        {
            //await TestWithHttpClient();
            await TestWithHttpClientAndIdentityModelAuthenticationServiceAsync();
            //await TestIdentityService();
            //await TestTenantManagementService();
            //await TestForRoutePath();
            //await TestRabbitMq();
            //TestParallel();
            //TestDotNettyInvoker();
            //TestThriftInvoker();
        }

        private async Task TestWithHttpClient()
        {
            Console.WriteLine();
            Console.WriteLine("*** TestWithHttpClient ************************************");

            try
            {
                using (var client = new HttpClient())
                {
                    await _authenticationService.TryAuthenticateAsync(client);

                    var url = GetServerUrl() + "api/user/getuserid/{username}?userName=10";
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


        /* Shows how to use HttpClient to perform a request to the HTTP API.
         * It uses ABP's IIdentityModelAuthenticationService to simplify obtaining access tokens.
         */
        private async Task TestWithHttpClientAndIdentityModelAuthenticationServiceAsync()
        {
            Console.WriteLine();
            Console.WriteLine($"***** {nameof(TestWithHttpClientAndIdentityModelAuthenticationServiceAsync)} *****");

            //Get access token using ABP's IIdentityModelAuthenticationService

            var accessToken = await _authenticationService.GetAccessTokenAsync(
                new IdentityClientConfiguration(
                    _configuration["IdentityClients:Default:Authority"],
                    _configuration["IdentityClients:Default:Scope"],
                    _configuration["IdentityClients:Default:ClientId"],
                    _configuration["IdentityClients:Default:ClientSecret"],
                    _configuration["IdentityClients:Default:GrantType"],
                    _configuration["IdentityClients:Default:UserName"],
                    _configuration["IdentityClients:Default:UserPassword"]
                )
            );
            Console.WriteLine("The accessToken: " + accessToken);
            using (var httpClient = new HttpClient())
            {

                do
                {
                    httpClient.SetBearerToken(accessToken);
                    var url = GetServerUrl() + "api/identityrole/createasync";
                    var postData = _jsonSerializer.Serialize(new { input = new IdentityRoleCreateDto { Name = $"Test{Volo.Abp.RandomHelper.GetRandom()}", IsDefault = true, IsPublic = true } });
                    var responseMessage = await httpClient.PostAsync(url, new StringContent(postData, Encoding.UTF8, MimeTypes.Application.Json));
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var responseString = await responseMessage.Content.ReadAsStringAsync();
                        Console.WriteLine("Result: " + responseString);
                    }
                    else
                    {
                        throw new Exception("Remote server returns error code: " + responseMessage.StatusCode);
                    }

                    Console.WriteLine("Press any key to continue, q to exit the loop...");
                    var key = Console.ReadLine();
                    if (key != null && key.ToLower() == "q")
                    {
                        break;
                    }
                } while (true);
            }

            //var userName = _currentUser.UserName;
            //RpcContext.GetContext().SetAttachment("xid", RandomHelper.GetRandom());

            //var roleProxy = ServiceLocator.GetService<IServiceProxyFactory>().CreateProxy<IIdentityRoleService>();
            //var roleOutput = await roleProxy.CreateAsync(new IdentityRoleCreateDto { Name = $"Test{Volo.Abp.RandomHelper.GetRandom()}", IsDefault = true, IsPublic = true });

            //Console.WriteLine("Total IdentityRoleCreateDto: " + roleOutput.Name);
        }

        private async Task TestIdentityService()
        {
            Console.WriteLine();
            Console.WriteLine($"*** {nameof(TestIdentityService)} ************************************");

            try
            {
                var userProxy = ServiceLocator.GetService<IServiceProxyFactory>().CreateProxy<IIdentityUserService>();
                var output = await userProxy.GetListAsync(new GetIdentityUsersInput());

                Console.WriteLine("Total user count: " + output.TotalCount);

                foreach (var user in output.Items)
                {
                    Console.WriteLine($"- UserName={user.UserName}, Email={user.Email}, Name={user.Name}, Surname={user.Surname}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private async Task TestTenantManagementService()
        {
            Console.WriteLine();
            Console.WriteLine("*** TestTenantManagementService ************************************");

            try
            {
                var tenantProxy = ServiceLocator.GetService<IServiceProxyFactory>().CreateProxy<ITenantService>();
                var output = await tenantProxy.GetListAsync(new GetTenantsInput());

                Console.WriteLine("Total tenant count: " + output.TotalCount);

                foreach (var tenant in output.Items)
                {
                    Console.WriteLine($"- Id={tenant.Id}, Name={tenant.Name}");
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
                        "user",
                        new UserModel
                        {
                            Name = "gongap",
                            Age = 18,
                            UserId = 1,
                            Sex = Sex.Woman
                        }
                    }
                };
                var path = "api/user/getuser";
                var serviceKey = "User";

                var output = await serviceProxyProvider.Invoke<UserModel>(model, path, serviceKey);
                Console.WriteLine($"{output}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private async Task TestRabbitMq()
        {
            Console.WriteLine();
            Console.WriteLine("*** TestRabbitMq ************************************");

            try
            {
                var serviceProxyFactory = ServiceLocator.GetService<IServiceProxyFactory>();
                await serviceProxyFactory.CreateProxy<IUserService>("User").PublishThroughEventBusAsync(new UserEvent
                {
                    Age = 18,
                    Name = "gongap",
                    UserId = 1
                });
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
                var userProxy = ServiceLocator.GetService<IServiceProxyFactory>().CreateProxy<IUserService>("User");
                ServiceResolver.Current.Register("User", userProxy);
                userProxy = ServiceResolver.Current.GetService<IUserService>("User");
                sw.Stop();
                Console.WriteLine($"代理所花{sw.ElapsedMilliseconds}ms");

                ThreadPool.SetMinThreads(100, 100);
                Parallel.For(0, connectionCount / 6000, new ParallelOptions { MaxDegreeOfParallelism = 50 }, async u =>
                {
                    for (var i = 0; i < 6000; i++)
                    {
                        await StartRequest(userProxy, connectionCount);
                    }
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            async Task StartRequest(IUserService userProxy, int connectionCount)
            {
                var a = await userProxy.GetDictionary();
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

        private void TestDotNettyInvoker()
        {
            Console.WriteLine();
            Console.WriteLine("*** TestThriftInvoker ************************************");

            try
            {
                var serviceProxyFactory = ServiceLocator.GetService<IServiceProxyFactory>();
                var userProxy = serviceProxyFactory.CreateProxy<IUserService>("User");
                var asyncProxy = serviceProxyFactory.CreateProxy<IAsyncService>();
                var serviceProxyProvider = ServiceLocator.GetService<IServiceProxyProvider>();
                Task.Run(async () =>
                {
                    RpcContext.GetContext().SetAttachment("xid", 124);
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

                    do
                    {
                        Console.WriteLine("正在循环 1w次调用 GetDictionary.....");

                        //1w次调用
                        var watch = Stopwatch.StartNew();
                        for (var i = 0; i < 10000; i++)
                        {
                            var output = await userProxy.GetDictionary();
                            //var output = serviceProxyProvider.Invoke<object>(new Dictionary<string, object>(), "api/user/GetDictionary", "User").Result;
                        }

                        watch.Stop();
                        Console.WriteLine($"1w次调用结束，执行时间：{watch.ElapsedMilliseconds}ms");
                        Console.WriteLine("Press any key to continue, q to exit the loop...");
                        var key = Console.ReadLine();
                        if (key != null && key.ToLower() == "q")
                        {
                            break;
                        }
                    } while (true);
                }).Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void TestThriftInvoker()
        {
            Console.WriteLine();
            Console.WriteLine("*** TestThriftInvoker ************************************");

            try
            {
                var serviceProxyFactory = ServiceLocator.GetService<IServiceProxyFactory>();
                var proxy = serviceProxyFactory.CreateProxy<IAsyncService>();
                var proxy1 = serviceProxyFactory.CreateProxy<IThirdAsyncService>();
                Task.Run(async () =>
                {
                    do
                    {
                        var result1 = await proxy.SayHelloAsync();
                        var result2 = await proxy1.SayHelloAsync();
                        Console.WriteLine("正在循环 1w次调用 SayHello.....");
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
                        Console.WriteLine($"1w次调用结束，执行时间：{watch.ElapsedMilliseconds}ms");
                        Console.WriteLine("Press any key to continue, q to exit the loop...");
                        var key = Console.ReadLine();
                        if (key != null && key.ToLower() == "q")
                        {
                            break;
                        }
                    } while (true);
                }).Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private string GetServerUrl()
        {
            return _remoteServiceOptions.RemoteServices.Default.BaseUrl.EnsureEndsWith('/');
        }
    }
}