using System;
using System.Net;
using System.Threading.Tasks;
using Autofac;
using KissU.CPlatform.Module;
using KissU.Dependency;
using KissU.EventBus.Events;
using KissU.EventBus.Implementation;
using KissU.ServiceProxy;

namespace KissU.DotNetty.DNS.Runtime
{
    /// <summary>
    /// DnsBehavior.
    /// Implements the <see cref="IServiceBehavior" />
    /// </summary>
    /// <seealso cref="IServiceBehavior" />
    public abstract class DnsBehavior : IServiceBehavior
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
        /// Publishes the specified event.
        /// </summary>
        /// <param name="event">The event.</param>
        public void Publish(IntegrationEvent @event)
        {
            GetService<IEventBus>().Publish(@event);
        }

        /// <summary>
        /// Resolves the specified domain name.
        /// </summary>
        /// <param name="domainName">Name of the domain.</param>
        /// <returns>Task&lt;IPAddress&gt;.</returns>
        public abstract Task<IPAddress> Resolve(string domainName);


        /// <summary>
        /// Domains the resolve.
        /// </summary>
        /// <param name="domainName">Name of the domain.</param>
        /// <returns>Task&lt;IPAddress&gt;.</returns>
        internal async Task<IPAddress> DomainResolve(string domainName)
        {
            domainName = domainName.TrimEnd('.');
            var prefixLen = domainName.IndexOf(".");
            IPAddress result = null;
            if (prefixLen > 0)
            {
                var prefixName = domainName.Substring(0, prefixLen);
                var pathLen = domainName.LastIndexOf(".") - prefixLen - 1;
                if (pathLen > 0)
                {
                    var routePath = domainName.Substring(prefixLen + 1, pathLen).Replace(".", "/");
                    if (routePath.IndexOf("/") < 0 && routePath[0] != '/')
                        routePath = $"/{routePath}";
                    var address = await GetService<IEchoService>().Locate(prefixName, routePath);
                    if (!string.IsNullOrEmpty(address.WanIp))
                        result = IPAddress.Parse(address.WanIp);
                }
            }

            result = await Resolve(domainName) ?? result;
            return result;
        }
    }
}