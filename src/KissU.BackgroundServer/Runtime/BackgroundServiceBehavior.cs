using System;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using KissU.CPlatform.Ioc;
using KissU.CPlatform.Messages;
using KissU.Dependency;
using KissU.ServiceProxy;

namespace KissU.BackgroundServer.Runtime
{
    /// <summary>
    /// BackgroundServiceBehavior.
    /// Implements the <see cref="IServiceBehavior" />
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="IServiceBehavior" />
    /// <seealso cref="System.IDisposable" />
    public abstract class BackgroundServiceBehavior : IServiceBehavior, IDisposable
    {
        private ServerReceivedDelegate received;
        public event ServerReceivedDelegate Received
        {
            add
            {
                if (received == null)
                {
                    received += value;
                }
            }
            remove
            {
                received -= value;
            }
        }

        public string MessageId { get; } = Guid.NewGuid().ToString("N");
        public async Task Write(object result, int statusCode = 200, string exceptionMessage = "")
        {
            if (received == null)
                return;
            var message = new TransportMessage(MessageId, new ReactiveResultMessage
            {
                ExceptionMessage = exceptionMessage,
                StatusCode = statusCode,
                Result = result

            });
            await received(message);
        }

        private Task _executingTask;
        private CancellationTokenSource _stoppingCts = new CancellationTokenSource();

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public virtual void Dispose()
        {
            _stoppingCts.Cancel();
        }

        /// <summary>
        /// Creates the proxy.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns>T.</returns>
        public T CreateProxy<T>(string key) where T : class
        {
            return ServiceLocator.GetService<IServiceProxyFactory>().CreateProxy<T>(key);
        }

        /// <summary>
        /// Creates the proxy.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>System.Object.</returns>
        public object CreateProxy(Type type)
        {
            return ServiceLocator.GetService<IServiceProxyFactory>().CreateProxy(type);
        }

        /// <summary>
        /// Creates the proxy.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="type">The type.</param>
        /// <returns>System.Object.</returns>
        public object CreateProxy(string key, Type type)
        {
            return ServiceLocator.GetService<IServiceProxyFactory>().CreateProxy(key, type);
        }

        /// <summary>
        /// Creates the proxy.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>T.</returns>
        public T CreateProxy<T>() where T : class
        {
            return ServiceLocator.GetService<IServiceProxyFactory>().CreateProxy<T>();
        }

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns>T.</returns>
        public T GetService<T>(string key) where T : class
        {
            if (ServiceLocator.Current.IsRegisteredWithKey<T>(key))
                return ServiceLocator.GetService<T>(key);
            return ServiceLocator.GetService<IServiceProxyFactory>().CreateProxy<T>(key);
        }

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>T.</returns>
        public T GetService<T>() where T : class
        {
            if (ServiceLocator.Current.IsRegistered<T>())
                return ServiceLocator.GetService<T>();
            return ServiceLocator.GetService<IServiceProxyFactory>().CreateProxy<T>();
        }

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>System.Object.</returns>
        public object GetService(Type type)
        {
            if (ServiceLocator.Current.IsRegistered(type))
                return ServiceLocator.GetService(type);
            return ServiceLocator.GetService<IServiceProxyFactory>().CreateProxy(type);
        }

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="type">The type.</param>
        /// <returns>System.Object.</returns>
        public object GetService(string key, Type type)
        {
            if (ServiceLocator.Current.IsRegisteredWithKey(key, type))
                return ServiceLocator.GetService(key, type);
            return ServiceLocator.GetService<IServiceProxyFactory>().CreateProxy(key, type);
        }

        /// <summary>
        /// Executes the asynchronous.
        /// </summary>
        /// <param name="stoppingToken">The stopping token.</param>
        /// <returns>Task.</returns>
        protected abstract Task ExecuteAsync(CancellationToken stoppingToken);

        /// <summary>
        /// Starts the asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        public virtual Task StartAsync(CancellationToken cancellationToken)
        {
            _stoppingCts = new CancellationTokenSource();
            _executingTask = ExecutingAsync(_stoppingCts.Token);

            if (_executingTask.IsCompleted)
            {
                return _executingTask;
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// stop as an asynchronous operation.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual async Task StopAsync(CancellationToken cancellationToken)
        {
            if (_executingTask == null)
            {
                return;
            }

            try
            {
                _stoppingCts.Cancel();
            }
            finally
            {
                await Task.WhenAny(_executingTask, Task.Delay(Timeout.Infinite, cancellationToken));
            }
        }

        private async Task ExecutingAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await ExecuteAsync(stoppingToken);
            }
        }
    }
}