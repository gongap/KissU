using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Http.Client;
using Volo.Abp.IdentityModel;
using KissU.Dependency;
using KissU.Extensions;
using KissU.ServiceProxy;
using KissU.WebSocket.Core;
using IdentityModel.Client;
using KissU.Msm.Sample.Service.Contracts;
using KissUtil.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace KissU.ServiceClient
{
    public class AppService : Volo.Abp.DependencyInjection.ITransientDependency
    {
        private static int _endedConnenctionCount;
        private static DateTime begintime;
        private readonly AbpRemoteServiceOptions _remoteServiceOptions;
        private readonly IIdentityModelAuthenticationService _authenticationService;
        private readonly IConfiguration _configuration;
        private Encoding _encoding = new UTF8Encoding(false);

        public AppService(IOptions<AbpRemoteServiceOptions> remoteServiceOptions, IIdentityModelAuthenticationService authenticationService,IConfiguration configuration)
        {
            _remoteServiceOptions = remoteServiceOptions.Value;
            _authenticationService = authenticationService;
            _configuration = configuration;
        }

        public async Task RunAsync()
        {
            DoWhile(TestWithHttpClientAndIdentityModelAuthenticationServiceAsync);
            // DoWhile(TestForRoutePath);
            // TestParallel();
        }

        private async Task TestWithHttpClientAndIdentityModelAuthenticationServiceAsync()
        {
            Console.WriteLine();
            Console.WriteLine($"***** {nameof(TestWithHttpClientAndIdentityModelAuthenticationServiceAsync)} *****");

            // Get access token using Abp's IIdentityModelAuthenticationService

            var accessToken = await _authenticationService.GetAccessTokenAsync(
                new IdentityClientConfiguration(
                    _configuration["IdentityClients:Default:Authority"],
                    _configuration["IdentityClients:Default:Scope"],
                    _configuration["IdentityClients:Default:ClientId"],
                    _configuration["IdentityClients:Default:ClientSecret"],
                    _configuration["IdentityClients:Default:GrantType"],
                    _configuration["IdentityClients:Default:UserName"],
                    _configuration["IdentityClients:Default:Password"],
                    _configuration["IdentityClients:Default:RequireHttps"].ToBool()
                )
            );
            Console.WriteLine("AccessToken: " + accessToken);

            // Perform the actual HTTP request
            using (var httpClient = new HttpClient())
            {
                httpClient.SetBearerToken(accessToken);

                //await FindByUserName(httpClient);

                //await httpClient.RevokeTokenAsync(new TokenRevocationRequest
                //{
                //    Address = $"{_configuration["IdentityClients:Default:Authority"]}/connect/revocation",
                //    ClientId = _configuration["IdentityClients:Default:ClientId"],
                //    ClientSecret = _configuration["IdentityClients:Default:ClientSecret"],
                //    Token = accessToken,
                //});

                //await FindByUserName(httpClient);
               await WebSocketConnectAsync(accessToken);
            }
        }

        private async Task FindByUserName(HttpClient httpClient)
        {
            var url = _remoteServiceOptions.RemoteServices.Default.BaseUrl.EnsureEndsWith('/') + "api/UserLookup/FindByUserName?userName=admin";

            var responseMessage = await httpClient.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseString = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine("Result: " + responseString);
            }
            else
            {
                throw new Exception("Remote server returns error code: " + responseMessage.StatusCode);
            }
        }

        private async Task TestForRoutePath()
        {
            Console.WriteLine();
            Console.WriteLine("*** TestForRoutePath ************************************");

            try
            {
                var serviceProxyProvider = ServiceLocator.GetService<IServiceProxyProvider>();
                var path = "api/Manager/SayHello?name=admin";
                var output = await serviceProxyProvider.Invoke<string>(null, path);
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
                var proxy = ServiceLocator.GetService<IServiceProxyFactory>().CreateProxy<IManagerService>();
                proxy = ServiceResolver.Current.GetService<IManagerService>();
                sw.Stop();
                Console.WriteLine($"代理所花{sw.ElapsedMilliseconds}ms");

                DoWhile(() =>
                {
                    ThreadPool.SetMinThreads(100, 100);
                    Parallel.For(0, connectionCount / 6000, new ParallelOptions { MaxDegreeOfParallelism = 50 }, async u =>
                    {
                        for (var i = 0; i < 6000; i++)
                        {
                            await StartRequest(proxy, connectionCount);
                        }
                    });

                    return Task.CompletedTask;
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            async Task StartRequest(IManagerService proxy, int connectionCount)
            {
                var result = await proxy.SayHelloAsync("admin");
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

        private async void DoWhile(Func<Task> func)
        {
            do
            {
                var watch = Stopwatch.StartNew();

                if (func != null)
                {
                    await func();
                }

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

        /// <summary>
        /// Connect
        /// </summary>
        async Task WebSocketConnectAsync(string accessToken)
        {
            try
            {
                //var webSocket1 = new ClientWebSocket();
                //webSocket1.Options.SetRequestHeader("Authorization", $"Bearer {accessToken}");
                //await webSocket1.ConnectAsync(new Uri($"ws://127.0.0.1:52000/api/chat?to=aa&name=bb"), CancellationToken.None);
                //var data1 = new byte[0];
                //var segment = new ArraySegment<byte>(data1, 0, data1.Length);
                //await webSocket1.SendAsync(segment, WebSocketMessageType.Text, true, CancellationToken.None);
                //var receiveBuffer = new byte[1024 * 1024 * 4];
                //var receivedMessage = await GetWebSocketReply(webSocket1, receiveBuffer);

                Console.WriteLine($"name:");
                var name = Console.ReadLine();
                Console.WriteLine($"to:");
                var to = Console.ReadLine();
                var webSocket = new WebSocket.Core.WebSocket($"ws://127.0.0.1:52000/api/chat?to={to}&name={name}&access_token={accessToken}");
                webSocket.OnOpen += WebSocket_OnOpen;
                webSocket.OnClose += WebSocket_OnClose;
                webSocket.OnError += WebSocket_OnError;
                webSocket.OnMessage += WebSocket_OnMessage;
                webSocket.EmitOnPing = true;
                webSocket.Connect();
                while (true)
                {
                    var data = Console.ReadLine();
                    webSocket.Send($"{data}  {DateTime.Now:G}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// WebSocket_OnError
        /// </summary>
        private static void WebSocket_OnError(object? sender, WebSocket.Core.ErrorEventArgs e)
        {
            Console.WriteLine($"ws异常 {DateTime.Now:G}");
        }

        /// <summary>
        /// WebSocket_OnClose
        /// </summary>
        private static void WebSocket_OnClose(object? sender, CloseEventArgs e)
        {
            Console.WriteLine($"ws关闭 {DateTime.Now:G}");
        }

        /// <summary>
        /// WebSocket_OnOpen
        /// </summary>
        private static void WebSocket_OnOpen(object? sender, EventArgs e)
        {
            Console.WriteLine($"ws连接 {DateTime.Now:G}");
        }

        /// <summary>
        /// WebSocket_OnMessage
        /// </summary>
        private static void WebSocket_OnMessage(object? sender, MessageEventArgs e)
        {
            if (e.IsPing)
            {
                Console.WriteLine($"ws收到心跳包 {DateTime.Now:G}");
            }
            else
            {
                Console.WriteLine($"ws收到{(e.IsBinary?"Binary":"")}消息: {(e.IsBinary?e.RawData.ToHexString(): e.Data)} {DateTime.Now:G}");
            }
        }

        private async ValueTask<string> GetWebSocketReply(ClientWebSocket websocket, byte[] receiveBuffer)
        {
            return await GetWebSocketReply(websocket, receiveBuffer, WebSocketMessageType.Text);
        }

        private async ValueTask<string> GetWebSocketReply(ClientWebSocket websocket, byte[] receiveBuffer, WebSocketMessageType messageType)
        {
            var sb = new StringBuilder();

            while (true)
            {
                var receiveSegment = new ArraySegment<byte>(receiveBuffer, 0, receiveBuffer.Length);
                var result = await websocket.ReceiveAsync(receiveSegment, CancellationToken.None);

                sb.Append(_encoding.GetString(receiveBuffer, 0, result.Count));

                if (result.EndOfMessage)
                    break;
            }

            return sb.ToString();
        }

        private async ValueTask<string> GetWebSocketReply(ClientWebSocket websocket, byte[] receiveBuffer, string request)
        {
            var data = _encoding.GetBytes(request);
            var segment = new ArraySegment<byte>(data, 0, data.Length);

            await websocket.SendAsync(new ArraySegment<byte>(data, 0, data.Length), WebSocketMessageType.Text, true, CancellationToken.None);

            return await GetWebSocketReply(websocket, receiveBuffer);
        }
    }
}
