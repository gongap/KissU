using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using KissU.Dependency;
using KissU.CPlatform.Transport.Implementation;
using KissU.Extensions;
using KissU.Modules.SampleA.Service.Contracts;
using KissU.Modules.SampleA.Service.Contracts.Dtos;
using KissU.Modules.SampleA.Service.Contracts.Events;
using KissU.ServiceProxy;

namespace KissU.ConsoleClient.Host
{
    public class ClientDemoService : Volo.Abp.DependencyInjection.ITransientDependency
    {
        private static int _endedConnenctionCount;
        private static DateTime begintime;

        public async Task RunAsync()
        {
            await TestForRoutePath();
            await TestRabbitMq();
            TestParallel();
            //TestDotNettyInvoker();
            //TestThriftInvoker();
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
    }
}