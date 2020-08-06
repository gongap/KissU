using System;
using System.Linq;
using Autofac;
using KissU.Dependency;
using KissU.EventBus.Events;
using KissU.EventBus.Implementation;
using KissU.Protocol.WS.Runtime;
using KissU.ProxyGenerator;
using WebSocketCore.Server;

namespace KissU.Protocol.WS
{
    /// <summary>
    /// WSBehavior.
    /// Implements the <see cref="WebSocketCore.Server.WebSocketBehavior" />
    /// Implements the <see cref="IServiceBehavior" />
    /// </summary>
    /// <seealso cref="WebSocketCore.Server.WebSocketBehavior" />
    /// <seealso cref="IServiceBehavior" />
    public abstract class WSBehavior : WebSocketBehavior, IServiceBehavior
    {
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

        /// <summary>
        /// Publishes the specified event.
        /// </summary>
        /// <param name="event">The event.</param>
        public void Publish(IntegrationEvent @event)
        {
            GetService<IEventBus>().Publish(@event);
        }
    }
}