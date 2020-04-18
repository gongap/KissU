using Autofac.Extensions.DependencyInjection;
using IdentityServer;
using IdentityServer4;
using KissU.Core;
using KissU.Core.Dependency;
using KissU.Core.Module;
using KissU.Surging.CPlatform;
using KissU.Modules.IdentityServer.Data;
using KissU.Modules.IdentityServer.Data.UnitOfWorks.SqlServer;
using KissU.Modules.IdentityServer.Domain.UnitOfWorks;
using KissU.Modules.IdentityServer.Service.Extensions;
using KissU.Surging.KestrelHttpServer;
using KissU.Util.Dapper;
using KissU.Util.Ddd.Domain.Datas.Enums;
using KissU.Util.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace KissU.Modules.IdentityServer.Service
{
    /// <summary>
    /// 扩展系统模块
    /// </summary>
    public class IdentityServerModule : KestrelHttpModule
    {
        public override void RegisterBuilder(ConfigurationContext context)
        {
            base.RegisterBuilder(context);
            context.Services.AddUnitOfWork<IIdentityServerUnitOfWork, IdentityServerUnitOfWork>(AppConfig.GetSection(DbConstants.ConnectionStringSection).GetSection(DbConstants.ConnectionStringName).Value);
            context.Services.AddSqlQuery<IdentityServerUnitOfWork>(config =>
            {
                config.DatabaseType = DatabaseType.SqlServer;
            });
            //var builder = context.Services.AddIdentityServer()
            //    .AddInMemoryIdentityResources(Config.Ids)
            //    .AddInMemoryApiResources(Config.Apis)
            //    .AddInMemoryClients(Config.Clients)
            //    .AddTestUsers(TestUsers.Users);

            //builder.AddDeveloperSigningCredential();

            context.Services.AddIdentityServer4();

            context.Services.AddAuthentication()
                .AddOpenIdConnect("oidc", "Demo IdentityServer", options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                    options.SignOutScheme = IdentityServerConstants.SignoutScheme;
                    options.SaveTokens = true;

                    options.Authority = "https://demo.identityserver.io/";
                    options.ClientId = "native.code";
                    options.ClientSecret = "secret";
                    options.ResponseType = "code";

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = "name",
                        RoleClaimType = "role"
                    };
                });
        }

        protected override void RegisterBuilder(ContainerBuilderWrapper wrapper)
        {
            base.RegisterBuilder(wrapper);
            wrapper.ContainerBuilder.AddUtil();
        }

        public override void Initialize(ApplicationInitializationContext context)
        {
            base.Initialize(context);
            context.Builder.UseIdentityServer();
        }
    }
}