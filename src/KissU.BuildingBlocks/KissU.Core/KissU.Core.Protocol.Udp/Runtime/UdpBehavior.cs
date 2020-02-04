using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using KissU.Core.CPlatform.EventBus.Events;
using KissU.Core.CPlatform.EventBus.Implementation;
using KissU.Core.CPlatform.Ioc;
using KissU.Core.CPlatform.Utilities;
using KissU.Core.ProxyGenerator;

namespace KissU.Core.Protocol.Udp.Runtime
{
    /// <summary>
    /// UdpBehavior.
    /// Implements the <see cref="KissU.Core.CPlatform.Ioc.IServiceBehavior" />
    /// </summary>
    /// <seealso cref="KissU.Core.CPlatform.Ioc.IServiceBehavior" />
    public abstract class UdpBehavior : IServiceBehavior
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
            else
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
            else
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
            else
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
            else
                return ServiceLocator.GetService<IServiceProxyFactory>().CreateProxy(key, type);

        }

        /// <summary>
        /// Dispatches the specified bytes.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public abstract Task<bool> Dispatch(IEnumerable<byte> bytes);

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