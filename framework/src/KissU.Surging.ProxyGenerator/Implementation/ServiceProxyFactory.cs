using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using KissU.Convertibles;

using KissU.Dependency;
using KissU.Surging.CPlatform.Runtime.Client;
using Microsoft.Extensions.DependencyInjection;
using KissU.Surging.CPlatform.Routing;
using KissU.Extensions;

namespace KissU.Surging.ProxyGenerator.Implementation
{
    /// <summary>
    /// 默认的服务代理工厂实现。
    /// </summary>
    public class ServiceProxyFactory : IServiceProxyFactory
    {
        #region Field

        private readonly IRemoteInvokeService _remoteInvokeService;
        private readonly ITypeConvertibleService _typeConvertibleService;
        private readonly IServiceProvider _serviceProvider;
        private readonly IServiceRouteProvider _serviceRouteProvider;
        private Type[] _serviceTypes = new Type[0];

        #endregion Field

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceProxyFactory" /> class.
        /// </summary>
        /// <param name="remoteInvokeService">The remote invoke service.</param>
        /// <param name="typeConvertibleService">The type convertible service.</param>
        /// <param name="serviceProvider">The service provider.</param>
        public ServiceProxyFactory(IRemoteInvokeService remoteInvokeService,
            ITypeConvertibleService typeConvertibleService,
            IServiceProvider serviceProvider, IServiceRouteProvider serviceRouteProvider) : this(remoteInvokeService, typeConvertibleService, serviceProvider, serviceRouteProvider, null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceProxyFactory" /> class.
        /// </summary>
        /// <param name="remoteInvokeService">The remote invoke service.</param>
        /// <param name="typeConvertibleService">The type convertible service.</param>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="types">The types.</param>
        /// <param name="namespaces">The namespaces.</param>
        public ServiceProxyFactory(IRemoteInvokeService remoteInvokeService,
            ITypeConvertibleService typeConvertibleService,
            IServiceProvider serviceProvider, IServiceRouteProvider serviceRouteProvider, IEnumerable<Type> types, IEnumerable<string> namespaces)
        {
            _serviceRouteProvider = serviceRouteProvider;
            _remoteInvokeService = remoteInvokeService;
            _typeConvertibleService = typeConvertibleService;
            _serviceProvider = serviceProvider;
            if (types != null)
            {
                RegisterProxType(namespaces.ToArray(), types.ToArray());
            }
        }

        #endregion Constructor

        #region Implementation of IServiceProxyFactory

        /// <summary>
        /// Creates the proxy.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>System.Object.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object CreateProxy(Type type)
        {
            var instance = ServiceResolver.Current.GetService(type);
            if (instance == null)
            {
                var proxyType = _serviceTypes.Single(type.GetTypeInfo().IsAssignableFrom);
                instance = proxyType.GetTypeInfo().GetConstructors().First().Invoke(new object[]
                {
                    _remoteInvokeService, _typeConvertibleService, null,
                    _serviceProvider.GetService<CPlatformContainer>(),_serviceRouteProvider
                });
                ServiceResolver.Current.Register(null, instance, type);
            }

            return instance;
        }

        /// <summary>
        /// Creates the proxy.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="type">The type.</param>
        /// <returns>System.Object.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object CreateProxy(string key, Type type)
        {
            var instance = ServiceResolver.Current.GetService(type, key);
            if (instance == null)
            {
                var proxyType = _serviceTypes.Single(type.GetTypeInfo().IsAssignableFrom);
                instance = proxyType.GetTypeInfo().GetConstructors().First().Invoke(new object[]
                {
                    _remoteInvokeService, _typeConvertibleService, key,
                    _serviceProvider.GetService<CPlatformContainer>(),_serviceRouteProvider
                });
                ServiceResolver.Current.Register(key, instance, type);
            }

            return instance;
        }

        /// <summary>
        /// Creates the proxy.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns>T.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T CreateProxy<T>(string key) where T : class
        {
            var instanceType = typeof(T);
            var instance = ServiceResolver.Current.GetService(instanceType, key);
            if (instance == null)
            {
                var proxyType = _serviceTypes.Single(typeof(T).GetTypeInfo().IsAssignableFrom);
                instance = proxyType.GetTypeInfo().GetConstructors().First().Invoke(new object[]
                {
                    _remoteInvokeService, _typeConvertibleService, key,
                    _serviceProvider.GetService<CPlatformContainer>(),_serviceRouteProvider
                });
                ServiceResolver.Current.Register(key, instance, instanceType);
            }

            return instance as T;
        }

        /// <summary>
        /// Creates the proxy.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>T.</returns>
        public T CreateProxy<T>() where T : class
        {
            return CreateProxy<T>(null);
        }

        /// <summary>
        /// Registers the type of the prox.
        /// </summary>
        /// <param name="namespaces">The namespaces.</param>
        /// <param name="types">The types.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RegisterProxType(string[] namespaces, params Type[] types)
        {
            var proxyGenerater = _serviceProvider.GetService<IServiceProxyGenerater>();
            var serviceTypes = proxyGenerater.GenerateProxys(types, namespaces).ToArray();
            _serviceTypes = _serviceTypes.Except(serviceTypes).Concat(serviceTypes).ToArray();
            proxyGenerater.Dispose();
            GC.Collect();
        }

        #endregion Implementation of IServiceProxyFactory
    }
}