using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using KissU.BackgroundServer.Runtime;
using KissU.Dependency;
using KissU.DotNetty.Tcp;
using KissU.ServiceProxy;
using KissU.Msm.Sample.Service.Contracts;
using KissU.Msm.Sample.Service.Contracts.Models;
using Microsoft.Extensions.Logging;

namespace KissU.Msm.Sample.Service.Implements
{
    public class BackgroundService : BackgroundServiceBehavior, IBackgroundService, ISingletonDependency
    {
        private readonly ILogger<BackgroundService> _logger;
        private   readonly Queue<Message> _queue = new Queue<Message>();
        private readonly IServiceProxyProvider _serviceProxyProvider;
        private CancellationToken _token;

        public BackgroundService(ILogger<BackgroundService> logger, IServiceProxyProvider serviceProxyProvider)
        {
            _logger = logger;
            _serviceProxyProvider = serviceProxyProvider;
            var messageListener = ServiceLocator.GetService<DotNettyTcpServerMessageListener>();
            if(messageListener != null)
                messageListener.NewClientAccepted += NewClientAccepted;
        }

        private void NewClientAccepted(EndPoint remoteAddress)
        {
            if(remoteAddress is IPEndPoint ipEndPoint)
            {
                var address = string.Concat(new string[] { ipEndPoint.Address.MapToIPv4().ToString(), ":", ipEndPoint.Port.ToString() });
                _logger.LogInformation(address);
            }
        }

        public  Task<bool> AddWorkAsync(Message message)
        {
            _queue.Enqueue(message);
            return Task.FromResult(true);
        }

        protected override async  Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                _token = stoppingToken;
                _queue.TryDequeue(out Message message);
                if (message != null)
                {
                    var result = await _serviceProxyProvider.Invoke<object>(message.Parameters, message.RoutePath, message.ServiceKey);
                    _logger.LogDebug("Invoke Service at: {time},Invoke result:{result}", DateTimeOffset.Now, result);
                }
            }
            catch (Exception ex){
                _logger.LogError("BackgroundService execute error, message：{message} ,trace info:{trace} ", ex.Message, ex.StackTrace);
            }

            if (!_token.IsCancellationRequested)
                await Task.Delay(10000, stoppingToken);
        }

        public async Task StartAsync()
        {
            if (_token.IsCancellationRequested)
            { 
                await base.StartAsync(_token);
            }
        }

        public async Task StopAsync()
        {
            if (!_token.IsCancellationRequested)
            {
               await  base.StopAsync(_token);
            }
        }
    }
}
