using IdentityServer4.Stores;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using IdentityServer4.Services;
using KFNets.Microservices.IdentityServer.Services;
using KFNets.Microservices.IdentityServer.Services.Options;
using KissU.Modules.GreatWall.Domain.Models;
using KissU.Modules.IdentityServer.Data.Stores;

namespace KFNets.Microservices.IdentityServer.Extensions
{
    /// <summary>
    /// IdentityServer4扩展
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 添加IdentityServer服务
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="storeOptionsAction">操作配置</param>
        public static IIdentityServerBuilder AddIdentityServer4(this IServiceCollection services, Action<OperationalStoreOptions> storeOptionsAction = null)
        {
            var builder = services.AddIdentityServer(options => {
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseSuccessEvents = true;
                options.Events.RaiseErrorEvents = true;
            })
               //添加一个签名密钥服务，该服务将指定的密钥提供给各种令牌创建/验证服务
               .AddDeveloperSigningCredential()
               //使用Asp.Net Identity 持久用户数据
               //.AddAspNetIdentity<User>()
               .AddResourceOwnerValidator<ResourceOwnerPasswordValidator<User>>()
               .AddProfileService<ProfileService>()
               //配置数据（资源和客户端）
               .AddConfigurationStore()
               //操作数据（令牌，代码和同意书）
               .AddOperationalStore(storeOptionsAction);
            return builder;
        }

        /// <summary>
        /// 配置 IClientStore, IResourceStore, ICorsPolicyService.
        /// </summary>
        /// <param name="builder">构造器</param>
        /// <returns></returns>
        public static IIdentityServerBuilder AddConfigurationStore(this IIdentityServerBuilder builder)
        {
            builder.AddClientStore<ClientStore>();
            builder.AddResourceStore<ResourceStore>();
            builder.AddCorsPolicyService<CorsPolicyService>();
            builder.Services.AddTransient<IEventSink, EventSink>();
            return builder;
        }

        /// <summary>
        /// 配置缓存 IClientStore, IResourceStore, ICorsPolicyService.
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
        /// 配置IPersistedGrantStore
        /// </summary>
        /// <param name="builder">构造器</param>
        /// <param name="storeOptionsAction">操作配置</param>
        /// <returns></returns>
        public static IIdentityServerBuilder AddOperationalStore(this IIdentityServerBuilder builder,
            Action<OperationalStoreOptions> storeOptionsAction = null)
        {
            var options = new OperationalStoreOptions();
            builder.Services.AddSingleton(options);
            storeOptionsAction?.Invoke(options);

            builder.Services.AddSingleton<TokenCleanup>();
            builder.Services.AddSingleton<IHostedService, TokenCleanupHost>();

            builder.Services.AddTransient<IPersistedGrantStore, PersistedGrantStore>();

            return builder;
        }

        /// <summary>
        /// 清理令牌作业
        /// </summary>
        class TokenCleanupHost : IHostedService
        {
            private readonly TokenCleanup _tokenCleanup;
            private readonly OperationalStoreOptions _options;

            public TokenCleanupHost(TokenCleanup tokenCleanup, OperationalStoreOptions options)
            {
                _tokenCleanup = tokenCleanup;
                _options = options;
            }

            public Task StartAsync(CancellationToken cancellationToken)
            {
                if (_options.EnableTokenCleanup)
                {
                    _tokenCleanup.Start(cancellationToken);
                }
                return Task.CompletedTask;
            }

            public Task StopAsync(CancellationToken cancellationToken)
            {
                if (_options.EnableTokenCleanup)
                {
                    _tokenCleanup.Stop();
                }
                return Task.CompletedTask;
            }
        }
    }
}
