using System;
using IdentityServer4.Stores;
using KissU.Modules.IdentityServer.Options;
using KissU.Modules.IdentityServer.Services;
using KissU.Modules.IdentityServer.Stores;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KissU.Modules.IdentityServer
{
    /// <summary>
    /// Extension methods to add EF database support to IdentityServer.
    /// </summary>
    public static class IdentityServerBuilderExtensions
    {
        /// <summary>
        /// 添加IdentityServer4服务
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="storeOptionsAction">操作配置</param>
        public static IIdentityServerBuilder AddIdentityServer4(this IServiceCollection services,
            Action<OperationalStoreOptions> storeOptionsAction = null)
        {
            var builder = services.AddIdentityServer()
                //添加一个签名密钥服务，该服务将指定的密钥提供给各种令牌创建/验证服务
                .AddDeveloperSigningCredential()
                //使用Asp.Net Identity 持久用户数据
                //配置数据（资源和客户端）
                .AddConfigurationStore()
                //操作数据（令牌，代码和同意书）
                .AddOperationalStore(storeOptionsAction);
            return builder;
        }

        /// <summary>
        /// Configures EF implementation of IClientStore, IResourceStore, and ICorsPolicyService with IdentityServer.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="storeOptionsAction">The storeOptionsAction.</param>
        /// <returns></returns>
        public static IIdentityServerBuilder AddConfigurationStore(this IIdentityServerBuilder builder,
            Action<OperationalStoreOptions> storeOptionsAction = null)
        {
            builder.AddClientStore<ClientStore>();
            builder.AddResourceStore<ResourceStore>();
            builder.AddCorsPolicyService<CorsPolicyService>();

            return builder;
        }

        /// <summary>
        /// Configures caching for IClientStore, IResourceStore, and ICorsPolicyService with IdentityServer.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static IIdentityServerBuilder AddConfigurationStoreCache(this IIdentityServerBuilder builder)
        {
            builder.AddInMemoryCaching();

            builder.AddClientStoreCache<ClientStore>();
            builder.AddResourceStoreCache<ResourceStore>();
            builder.AddCorsPolicyCache<CorsPolicyService>();

            return builder;
        }

        /// <summary>
        /// Configures EF implementation of IPersistedGrantStore with IdentityServer.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="storeOptionsAction">The store options action.</param>
        /// <returns></returns>
        public static IIdentityServerBuilder AddOperationalStore(this IIdentityServerBuilder builder,
            Action<OperationalStoreOptions> storeOptionsAction = null)
        {
            var options = new OperationalStoreOptions();
            builder.Services.AddSingleton(options);
            storeOptionsAction?.Invoke(options);

            builder.Services.AddTransient<IPersistedGrantStore, PersistedGrantStore>();
            builder.Services.AddTransient<IDeviceFlowStore, DeviceFlowStore>();
            builder.Services.AddTransient<TokenCleanupService>();
            builder.Services.AddSingleton<IHostedService, TokenCleanupHost>();

            return builder;
        }

        /// <summary>
        /// Adds an implementation of the IOperationalStoreNotification to IdentityServer.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IIdentityServerBuilder AddOperationalStoreNotification<T>(this IIdentityServerBuilder builder)
            where T : class, IOperationalStoreNotification
        {
            builder.Services.AddTransient<IOperationalStoreNotification, T>();
            return builder;
        }
    }
}