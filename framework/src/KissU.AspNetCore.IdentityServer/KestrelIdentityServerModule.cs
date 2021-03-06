﻿using KissU.AspNetCore.Extensions;
using KissU.AspNetCore.IdentityServer.Configurations;
using KissU.AspNetCore.IdentityServer.Filters;
using KissU.Modularity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace KissU.AspNetCore.IdentityServer
{
    /// <summary>
    /// KestrelNLogModule.
    /// Implements the <see cref="AspNetCoreModule" />
    /// </summary>
    /// <seealso cref="AspNetCoreModule" />
    public class KestrelIdentityServerModule : AspNetCoreModule
    {
        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Configure(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            app.UseAuthentication();
            app.UseAuthorization();
        }

        /// <summary>
        /// Registers the builder.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddFilters(typeof(JWTBearerAuthorizationFilterAttribute));
            context.Services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = AppConfig.Options.Authority;
                    options.ApiName = AppConfig.Options.ApiName;
                    options.RequireHttpsMetadata = false;
                });
        }

        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void ConfigureContainer(ContainerBuilderWrapper builder)
        {
            CPlatform.AppConfig.ServerOptions.DisableServiceRegistration = true;
            var section = CPlatform.AppConfig.GetSection("AuthServer");
            if (section.Exists())
            {
                AppConfig.Options = section.Get<AuthServerOption>();
            }
        }
    }
}