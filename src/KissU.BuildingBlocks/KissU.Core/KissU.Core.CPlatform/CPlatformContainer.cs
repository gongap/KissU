using System;
using Autofac;
using KissU.Core.CPlatform.DependencyResolution;

namespace KissU.Core.CPlatform
{
    /// <summary>
    /// 平台容器
    /// </summary>
    public class CPlatformContainer
    {
        /// <summary>
        /// 容器
        /// </summary>
        private IComponentContext _container;

        /// <summary>
        /// 当前IComponentContext
        /// </summary>
        public IComponentContext Current
        {
            get
            {
                return _container;
            }
           internal set
            {
                _container = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CPlatformContainer"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public CPlatformContainer(IComponentContext container)
        {
            this._container = container;
        }

        /// <summary>
        /// 确定此实例是否已注册.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns><c>true</c> if this instance is registered; otherwise, <c>false</c>.</returns>
        public bool IsRegistered<T>()
        {
            return _container.IsRegistered<T>();
        }

        /// <summary>
        /// Determines whether [is registered with key] [the specified service key].
        /// </summary>
        /// <param name="serviceKey">The service key.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns><c>true</c> if [is registered with key] [the specified service key]; otherwise, <c>false</c>.</returns>
        public bool IsRegisteredWithKey(string serviceKey,Type serviceType)
        {
            if(!string.IsNullOrEmpty(serviceKey))
            return _container.IsRegisteredWithKey(serviceKey, serviceType);
            else
                return _container.IsRegistered(serviceType);
        }

        /// <summary>
        /// 确定是否注册了指定的服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceKey">The service key.</param>
        /// <returns><c>true</c> if the specified service key is registered; otherwise, <c>false</c>.</returns>
        public bool IsRegistered<T>(object serviceKey)
        {
            return _container.IsRegisteredWithKey<T>(serviceKey);
        }

        /// <summary>
        /// 获取实例。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">The name.</param>
        /// <returns>T.</returns>
        public T GetInstances<T>(string name) where T : class
        {
     
            return _container.ResolveKeyed<T>(name);
        }

        /// <summary>
        /// 获取实例。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>T.</returns>
        public T GetInstances<T>() where T : class
        {
            return _container.Resolve<T>();
        }

        /// <summary>
        /// 获取实例。
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>System.Object.</returns>
        public object GetInstances(Type type)  
        {
            return _container.Resolve(type);
        }

        /// <summary>
        /// 获取实例。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">The type.</param>
        /// <returns>T.</returns>
        public T GetInstances<T>(Type type) where T : class
        {
            return _container.Resolve(type) as T;
        }

        /// <summary>
        /// 获取每个生命周期范围内的实例。
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="type">The type.</param>
        /// <returns>System.Object.</returns>
        public object GetInstancePerLifetimeScope(string name, Type type)
        {
           return string.IsNullOrEmpty(name) ? GetInstances(type) : _container.ResolveKeyed(name, type);
        }

        /// <summary>
        /// 获取实例。
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="type">The type.</param>
        /// <returns>System.Object.</returns>
        public object GetInstances(string name,Type type)  
        {
            // var appConfig = AppConfig.DefaultInstance;
            var objInstance = ServiceResolver.Current.GetService(type, name);
            if (objInstance == null)
            {
                objInstance = string.IsNullOrEmpty(name) ? GetInstances(type) : _container.ResolveKeyed(name, type);
                ServiceResolver.Current.Register(name, objInstance, type);
            }
            return objInstance;
        }
    }
}
