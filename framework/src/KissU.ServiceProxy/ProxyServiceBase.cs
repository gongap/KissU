using System;
using Autofac;
using KissU.Dependency;
using KissU.EventBus.Events;
using KissU.EventBus.Implementation;
using KissU.Extensions;

namespace KissU.ServiceProxy
{
    /// <summary>
    /// ProxyServiceBase.
    /// Implements the <see cref="ServiceBase" />
    /// </summary>
    /// <seealso cref="ServiceBase" />
    public abstract class ProxyServiceBase : ServiceBase
    {
        /// <summary>
        /// Creates the proxy.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns>T.</returns>
        [Obsolete("This method is Obsolete, use GetService")]
        public T CreateProxy<T>(string key) where T : class
        {
            // return ServiceLocator.GetService<IServiceProxyFactory>().CreateProxy<T>(key);
            var result = ServiceResolver.Current.GetService<T>(key);
            if (result == null)
            {
                result = ServiceLocator.GetService<IServiceProxyFactory>().CreateProxy<T>(key);
                ServiceResolver.Current.Register(key, result);
            }

            return result;
        }

        /// <summary>
        /// Creates the proxy.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>System.Object.</returns>
        [Obsolete("This method is Obsolete, use GetService")]
        public object CreateProxy(Type type)
        {
            var result = ServiceResolver.Current.GetService(type);
            if (result == null)
            {
                result = ServiceLocator.GetService<IServiceProxyFactory>().CreateProxy(type);
                ServiceResolver.Current.Register(null, result);
            }

            return result;
        }

        /// <summary>
        /// Creates the proxy.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="type">The type.</param>
        /// <returns>System.Object.</returns>
        [Obsolete("This method is Obsolete, use GetService")]
        public object CreateProxy(string key, Type type)
        {
            var result = ServiceResolver.Current.GetService(type, key);
            if (result == null)
            {
                result = ServiceLocator.GetService<IServiceProxyFactory>().CreateProxy(key, type);
                ServiceResolver.Current.Register(key, result);
            }

            return result;
        }

        /// <summary>
        /// Creates the proxy.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>T.</returns>
        [Obsolete("This method is Obsolete, use GetService")]
        public T CreateProxy<T>() where T : class
        {
            var result = ServiceResolver.Current.GetService<T>();
            if (result == null)
            {
                result = ServiceLocator.GetService<IServiceProxyFactory>().CreateProxy<T>();
                ServiceResolver.Current.Register(null, result);
            }

            return result;
        }

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <typeparam name="T">服务类型</typeparam>
        /// <param name="key">The key.</param>
        /// <returns>T.</returns>
        public override T GetService<T>(string key)
        {
            if (ServiceLocator.Current.IsRegisteredWithKey<T>(key))
                return base.GetService<T>(key);
            var result = ServiceResolver.Current.GetService<T>(key);
            if (result == null)
            {
                result = ServiceLocator.GetService<IServiceProxyFactory>().CreateProxy<T>(key);
                ServiceResolver.Current.Register(key, result);
            }

            return result;
        }

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <typeparam name="T">服务类型</typeparam>
        /// <returns>T.</returns>
        public override T GetService<T>()
        {
            if (ServiceLocator.Current.IsRegistered<T>())
                return base.GetService<T>();
            var result = ServiceResolver.Current.GetService<T>();
            if (result == null)
            {
                result = ServiceLocator.GetService<IServiceProxyFactory>().CreateProxy<T>();
                ServiceResolver.Current.Register(null, result);
            }

            return result;
        }

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>System.Object.</returns>
        public override object GetService(Type type)
        {
            if (ServiceLocator.Current.IsRegistered(type))
                return base.GetService(type);
            var result = ServiceResolver.Current.GetService(type);
            if (result == null)
            {
                result = ServiceLocator.GetService<IServiceProxyFactory>().CreateProxy(type);
                ServiceResolver.Current.Register(null, result);
            }

            return result;
        }

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="type">The type.</param>
        /// <returns>System.Object.</returns>
        public override object GetService(string key, Type type)
        {
            if (ServiceLocator.Current.IsRegisteredWithKey(key, type))
                return base.GetService(key, type);
            var result = ServiceResolver.Current.GetService(type, key);
            if (result == null)
            {
                result = ServiceLocator.GetService<IServiceProxyFactory>().CreateProxy(key, type);
                ServiceResolver.Current.Register(key, result);
            }

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