using System;
using System.Threading.Tasks;
using KissU.CPlatform.Messages;
using KissU.Dependency;

namespace KissU.CPlatform.Ioc
{
    /// <summary>
    /// 服务基类.
    /// Implements the <see cref="IServiceBehavior" />
    /// </summary>
    /// <seealso cref="IServiceBehavior" />
    public abstract class ServiceBase : IServiceBehavior
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

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <typeparam name="T">服务类型</typeparam>
        /// <returns>T.</returns>
        public virtual T GetService<T>()
            where T : class
        {
            return ServiceLocator.GetService<T>();
        }

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <typeparam name="T">服务类型</typeparam>
        /// <param name="key">The key.</param>
        /// <returns>T.</returns>
        public virtual T GetService<T>(string key)
            where T : class
        {
            return ServiceLocator.GetService<T>(key);
        }

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>System.Object.</returns>
        public virtual object GetService(Type type)
        {
            return ServiceLocator.GetService(type);
        }

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="type">The type.</param>
        /// <returns>System.Object.</returns>
        public virtual object GetService(string key, Type type)
        {
            return ServiceLocator.GetService(key, type);
        }
    }
}