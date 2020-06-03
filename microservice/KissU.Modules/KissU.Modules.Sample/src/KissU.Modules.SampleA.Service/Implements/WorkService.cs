using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Surging.ProxyGenerator;
using KissU.Surging.BackgroundServer.Runtime;
using KissU.Modules.SampleA.Service.Contracts;
using KissU.Modules.SampleA.Service.Contracts.Dtos;
using Microsoft.Extensions.Logging;

namespace KissU.Modules.SampleA.Service.Implements
{
    /// <summary>
    /// WorkService.
    /// Implements the <see cref="KissU.Surging.BackgroundServer.Runtime.BackgroundServiceBehavior" />
    /// Implements the <see cref="KissU.Modules.SampleA.Service.Contracts.IWorkService" />
    /// Implements the <see cref="ISingleInstance" />
    /// </summary>
    /// <seealso cref="KissU.Surging.BackgroundServer.Runtime.BackgroundServiceBehavior" />
    /// <seealso cref="KissU.Modules.SampleA.Service.Contracts.IWorkService" />
    /// <seealso cref="ISingleInstance" />
    public class WorkService : BackgroundServiceBehavior, IWorkService, ISingleInstance
    {
        private readonly ILogger<WorkService> _logger;
        private readonly Queue<Message> _queue = new Queue<Message>();
        private readonly IServiceProxyProvider _serviceProxyProvider;
        private CancellationToken _token;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkService" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="serviceProxyProvider">The service proxy provider.</param>
        public WorkService(ILogger<WorkService> logger, IServiceProxyProvider serviceProxyProvider)
        {
            _logger = logger;
            _serviceProxyProvider = serviceProxyProvider;
        }

        /// <summary>
        /// Adds the work.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public Task<bool> AddWork(Message message)
        {
            _queue.Enqueue(message);
            return Task.FromResult(true);
        }

        /// <summary>
        /// start as an asynchronous operation.
        /// </summary>
        /// <returns>Task.</returns>
        public async Task StartAsync()
        {
            if (_token.IsCancellationRequested)
            {
                await base.StartAsync(_token);
            }
        }

        /// <summary>
        /// stop as an asynchronous operation.
        /// </summary>
        /// <returns>Task.</returns>
        public async Task StopAsync()
        {
            if (!_token.IsCancellationRequested)
            {
                await base.StopAsync(_token);
            }
        }

        /// <summary>
        /// execute as an asynchronous operation.
        /// </summary>
        /// <param name="stoppingToken">The stopping token.</param>
        /// <returns>Task.</returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                _token = stoppingToken;
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                _queue.TryDequeue(out var message);
                if (message != null)
                {
                    var result = await _serviceProxyProvider.Invoke<object>(message.Parameters, message.RoutePath,
                        message.ServiceKey);
                    _logger.LogInformation("Invoke Service at: {time},Invoke result:{result}", DateTimeOffset.Now,
                        result);
                }

                if (!_token.IsCancellationRequested)
                    await Task.Delay(10000, stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError("WorkService execute error, message：{message} ,trace info:{trace} ", ex.Message,
                    ex.StackTrace);
            }
        }
    }
}