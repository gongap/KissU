using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using KissU.Core.Dependency;
using KissU.Surging.CPlatform.Diagnostics;
using KissU.Surging.CPlatform.Transport.Implementation;
using KissU.Surging.ProxyGenerator;
using KissU.Modules.SampleA.Service.Contracts;
using KissU.Modules.SampleA.Service.Contracts.Dtos;
using KissU.Modules.SampleA.Service.Contracts.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace KissU.Client
{
    public class Startup
    {
        private ContainerBuilder _builder;

        public Startup(IConfigurationBuilder config)
        {
        }

        public IContainer ConfigureServices(ContainerBuilder builder)
        {
            var services = new ServiceCollection();
            ConfigureLogging(services);
            builder.Populate(services);
            _builder = builder;
            ServiceLocator.Current = builder.Build();
            return ServiceLocator.Current;
        }

        public void Configure(IContainer app)
        {
        }

        #region 私有方法

        /// <summary>
        /// 配置日志服务
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureLogging(IServiceCollection services)
        {
            services.AddLogging();
        }

        /// <summary>
        /// 测试
        /// </summary>
        /// <param name="serviceProxyFactory"></param>
        public static void Test(IServiceProxyFactory serviceProxyFactory)
        {
            var tracingContext = ServiceLocator.GetService<ITracingContext>();
            Task.Run(async () =>
            {
                RpcContext.GetContext().SetAttachment("xid", 124);

                var userProxy = serviceProxyFactory.CreateProxy<IAccountService>("Account");
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
                    Console.WriteLine("正在循环 1w次调用 GetUser.....");

                    //1w次调用
                    var watch = Stopwatch.StartNew();
                    for (var i = 0; i < 10000; i++)
                    {
                        //var a = userProxy.GetDictionary().Result;
                        var a = await userProxy.GetDictionary();
                        //var result = serviceProxyProvider.Invoke<object>(new Dictionary<string, object>(), "api/user/GetDictionary", "User").Result;
                    }

                    watch.Stop();
                    Console.WriteLine($"1w次调用结束，执行时间：{watch.ElapsedMilliseconds}ms");
                    Console.WriteLine("Press any key to continue, q to exit the loop...");
                    var key = Console.ReadLine();
                    if (key.ToLower() == "q")
                        break;
                } while (true);
            }).Wait();
        }

        public static void TestRabbitMq(IServiceProxyFactory serviceProxyFactory)
        {
            serviceProxyFactory.CreateProxy<IAccountService>("User").PublishThroughEventBusAsync(new UserEvent
            {
                Age = 18,
                Name = "gongap",
                UserId = 1
            });
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

        public static void TestForRoutePath(IServiceProxyProvider serviceProxyProvider)
        {
            var model = new Dictionary<string, object>();
            model.Add("user", JsonConvert.SerializeObject(new
            {
                Name = "gongap",
                Age = 18,
                UserId = 1,
                Sex = "Man"
            }));
            var path = "api/account/getuser";
            var serviceKey = "User";

            var userProxy = serviceProxyProvider.Invoke<object>(model, path, serviceKey);
            var s = userProxy.Result;
            Console.WriteLine($"{s}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

        #endregion
    }
}