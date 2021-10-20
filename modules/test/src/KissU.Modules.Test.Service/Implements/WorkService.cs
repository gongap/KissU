using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KissU.BackgroundServer.Runtime;
using KissU.Dependency;
using KissU.Modules.Test.Service.Contracts;
using KissU.Modules.Test.Service.Contracts.Models;
using KissU.ServiceProxy;
using Microsoft.Extensions.Logging;

namespace KissU.Modules.Test.Service.Implements
{
    public class WorkService : BackgroundServiceBehavior, IWorkService, ISingletonDependency
    {
        private readonly ILogger<WorkService> _logger;
        private   readonly Queue<Message> _queue = new Queue<Message>();
        private readonly IServiceProxyProvider _serviceProxyProvider;
        private CancellationToken _token;

        public WorkService(ILogger<WorkService> logger, IServiceProxyProvider serviceProxyProvider)
        {
            _logger = logger;
            _serviceProxyProvider = serviceProxyProvider;
        }

        public  Task<bool> AddWork(Message message)
        {
            _queue.Enqueue(message);
            return Task.FromResult(true);
        }

        protected override async  Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                _token = stoppingToken;
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                _queue.TryDequeue(out Message message);
                if (message != null)
                {
                    var result = await _serviceProxyProvider.Invoke<object>(message.Parameters, message.RoutePath, message.ServiceKey);
                    _logger.LogInformation("Invoke Service at: {time},Invoke result:{result}", DateTimeOffset.Now, result);
                }
                if (!_token.IsCancellationRequested)
                    await Task.Delay(1000, stoppingToken);
            }
            catch (Exception ex){
                _logger.LogError("WorkService execute error, message：{message} ,trace info:{trace} ", ex.Message, ex.StackTrace);
            }
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
