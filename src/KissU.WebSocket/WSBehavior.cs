using System;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using KissU.CPlatform.Ioc;
using KissU.CPlatform.Messages;
using KissU.Dependency;
using KissU.ServiceProxy;
using KissU.WebSocket.Core.Server;
using KissU.WebSocket.Runtime;

namespace KissU.WebSocket
{
    /// <summary>
    /// WSBehavior.
    /// Implements the <see cref="WebSocketBehavior" />
    /// Implements the <see cref="IServiceBehavior" />
    /// </summary>
    /// <seealso cref="WebSocketBehavior" />
    /// <seealso cref="IServiceBehavior" />
    public abstract class WSBehavior : WebSocketBehavior, IServiceBehavior
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
        /// Gets the client.
        /// </summary>
        /// <returns>WebSocketSessionManager.</returns>
        public WebSocketSessionManager GetClient()
        {
            WebSocketSessionManager result = null;
            var server = ServiceLocator.GetService<DefaultWSServerMessageListener>().Server;
            var entries = ServiceLocator.GetService<IWSServiceEntryProvider>().GetEntries();
            var entry = entries.Where(p => p.Type == GetType()).FirstOrDefault();
            if (server.WebSocketServices.TryGetServiceHost(entry.Path, out var webSocketServiceHost))
                result = webSocketServiceHost.Sessions;
            return result;
        }
    }
}