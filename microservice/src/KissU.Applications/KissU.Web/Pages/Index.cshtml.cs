using System;
using System.Diagnostics;
using System.Threading.Tasks;
using KissU.Core.Dependency;
using KissU.Modules.SampleA.Service.Contracts;
using KissU.Modules.SampleA.Service.Contracts.Dtos;
using KissU.Modules.SampleA.Service.Contracts.Events;
using KissU.Surging.CPlatform.Diagnostics;
using KissU.Surging.CPlatform.Transport.Implementation;
using KissU.Surging.ProxyGenerator;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace KissU.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IServiceProxyFactory _serviceProxyFactory;

        public IndexModel(ILogger<IndexModel> logger, IServiceProxyFactory serviceProxyFactory)
        {
            _logger = logger;
            _serviceProxyFactory = serviceProxyFactory;
        }

        public void OnGet()
        {
            Test(_serviceProxyFactory);
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
    }
}
