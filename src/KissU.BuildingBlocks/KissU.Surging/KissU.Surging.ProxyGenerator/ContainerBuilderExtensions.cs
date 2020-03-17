using System;
using Autofac;
using KissU.Surging.CPlatform;
using KissU.Surging.CPlatform.Convertibles;
using KissU.Surging.CPlatform.Diagnostics;
using KissU.Surging.CPlatform.Runtime.Client;
using KissU.Surging.ProxyGenerator.Diagnostics;
using KissU.Surging.ProxyGenerator.Implementation;
using KissU.Surging.ProxyGenerator.Interceptors;
using KissU.Surging.ProxyGenerator.Interceptors.Implementation;

namespace KissU.Surging.ProxyGenerator
{
    /// <summary>
    /// ContainerBuilderExtensions.
    /// </summary>
    public static class ContainerBuilderExtensions
    {
        /// <summary>
        /// 添加客户端代理
        /// </summary>
        /// <param name="builder">服务构建者</param>
        /// <returns>服务构建者。</returns>
        public static IServiceBuilder AddClientProxy(this IServiceBuilder builder)
        {
            var services = builder.Services;
            services.RegisterType<ServiceProxyGenerater>().As<IServiceProxyGenerater>().SingleInstance();
            services.RegisterType<ServiceProxyProvider>().As<IServiceProxyProvider>().SingleInstance();
            builder.Services.Register(provider => new ServiceProxyFactory(
                provider.Resolve<IRemoteInvokeService>(),
                provider.Resolve<ITypeConvertibleService>(),
                provider.Resolve<IServiceProvider>(),
                builder.GetInterfaceService(),
                builder.GetDataContractName()
            )).As<IServiceProxyFactory>().SingleInstance();
            return builder;
        }

        /// <summary>
        /// Adds the client intercepted.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="interceptorServiceTypes">The interceptor service types.</param>
        /// <returns>IServiceBuilder.</returns>
        public static IServiceBuilder AddClientIntercepted(this IServiceBuilder builder,
            params Type[] interceptorServiceTypes)
        {
            var services = builder.Services;
            services.RegisterTypes(interceptorServiceTypes).As<IInterceptor>().SingleInstance();
            services.RegisterType<InterceptorProvider>().As<IInterceptorProvider>().SingleInstance();
            return builder;
        }

        /// <summary>
        /// Adds the RPC transport diagnostic.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>IServiceBuilder.</returns>
        public static IServiceBuilder AddRpcTransportDiagnostic(this IServiceBuilder builder)
        {
            var services = builder.Services;
            services.RegisterType<RpcTransportDiagnosticProcessor>().As<ITracingDiagnosticProcessor>().SingleInstance();
            return builder;
        }

        /// <summary>
        /// 添加客户端拦截
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="interceptorServiceType">Type of the interceptor service.</param>
        /// <returns>服务构建者</returns>
        public static IServiceBuilder AddClientIntercepted(this IServiceBuilder builder, Type interceptorServiceType)
        {
            var services = builder.Services;
            services.RegisterType(interceptorServiceType).As<IInterceptor>().SingleInstance();
            services.RegisterType<InterceptorProvider>().As<IInterceptorProvider>().SingleInstance();
            return builder;
        }

        /// <summary>
        /// Adds the client.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>IServiceBuilder.</returns>
        public static IServiceBuilder AddClient(this ContainerBuilder services)
        {
            return services
                .AddCoreService()
                .AddClientRuntime()
                .AddClientProxy();
        }

        /// <summary>
        /// 添加关联服务
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>服务构建者</returns>
        public static IServiceBuilder AddRelateService(this IServiceBuilder builder)
        {
            return builder.AddRelateServiceRuntime().AddClientProxy();
        }

        /// <summary>
        /// 添加客户端属性注入
        /// </summary>
        /// <param name="builder">服务构建者</param>
        /// <returns>服务构建者</returns>
        public static IServiceBuilder AddClient(this IServiceBuilder builder)
        {
            return builder
                .RegisterServices()
                .RegisterRepositories()
                .RegisterServiceBus()
                .RegisterModules()
                .RegisterInstanceByConstraint()
                .AddClientRuntime()
                .AddClientProxy();
        }
    }
}