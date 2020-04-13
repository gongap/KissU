using System;
using IdentityServer4.Stores;
using KissU.Modules.IdentityServer.Application.Services;
using KissU.Modules.IdentityServer.Application.Services.Options;
using KissU.Modules.IdentityServer.Data.Stores;
using KissU.Modules.IdentityServer.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KissU.Modules.IdentityServer.Service.Extensions
{
    /// <summary>
    /// IdentityServer的扩展方法
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 添加IdentityServer4服务
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="storeOptionsAction">操作配置</param>
        /// <returns>IIdentityServerBuilder.</returns>
        public static IIdentityServerBuilder AddIdentityServer4(this IServiceCollection services, Action<OperationalStoreOptions> storeOptionsAction = null)
        {
            var builder = services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddConfigurationStore()
                .AddOperationalStore(storeOptionsAction)
                .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>();
            return builder;
        }

        /// <summary>
        /// 使用IdentityServer配置IClientStore、IResourceStore和ICorsPolicyService的EF实现。
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>IIdentityServerBuilder.</returns>
        public static IIdentityServerBuilder AddConfigurationStore(this IIdentityServerBuilder builder)
        {
            builder.AddClientStore<ClientStore>();
            builder.AddResourceStore<ResourceStore>();
            builder.AddCorsPolicyService<CorsPolicyService>();

            return builder;
        }

        /// <summary>
        /// 使用IdentityServer配置IClientStore、IResourceStore和ICorsPolicyService的缓存。
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>IIdentityServerBuilder.</returns>
        public static IIdentityServerBuilder AddConfigurationStoreCache(this IIdentityServerBuilder builder)
        {
            builder.AddInMemoryCaching();

            builder.AddClientStoreCache<ClientStore>();
            builder.AddResourceStoreCache<ResourceStore>();
            builder.AddCorsPolicyCache<CorsPolicyService>();

            return builder;
        }

        /// <summary>
        /// 使用IdentityServer配置IPersistedGrantStore的EF实现。
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="storeOptionsAction">The store options action.</param>
        /// <returns>IIdentityServerBuilder.</returns>
        public static IIdentityServerBuilder AddOperationalStore(this IIdentityServerBuilder builder, Action<OperationalStoreOptions> storeOptionsAction = null)
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
    }
}