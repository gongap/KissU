using KissU.AuthServer.Host.EntityFrameworkCore;
using KissU.Modules.Account.Application;
using KissU.Modules.Account.Web.IdentityServer;
using KissU.Modules.AuditLogging.EntityFrameworkCore.EntityFrameworkCore;
using KissU.Modules.Identity.Application.Contracts;
using KissU.Modules.Identity.EntityFrameworkCore;
using KissU.Modules.IdentityServer.EntityFrameworkCore.EntityFrameworkCore;
using KissU.Modules.PermissionManagement.EntityFrameworkCore;
using KissU.Modules.SettingManagement.EntityFrameworkCore;
using KissU.Modules.TenantManagement.Application.Contracts;
using KissU.Modules.TenantManagement.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.Auditing;
using Volo.Abp.Autofac;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Threading;

namespace KissU.AuthServer.Host
{
    [DependsOn(
        typeof(AbpAutofacModule),
        //typeof(AbpEventBusRabbitMqModule),
        typeof(AbpPermissionManagementEntityFrameworkCoreModule),
        typeof(AbpAuditLoggingEntityFrameworkCoreModule),
        typeof(AbpSettingManagementEntityFrameworkCoreModule),
        typeof(AbpIdentityEntityFrameworkCoreModule),
        typeof(AbpIdentityApplicationContractsModule),
        typeof(AbpAccountApplicationModule),
        typeof(AbpIdentityServerEntityFrameworkCoreModule),
        typeof(AbpEntityFrameworkCoreSqlServerModule),
        typeof(AbpAccountWebIdentityServerModule),
        typeof(AbpAspNetCoreMvcUiBasicThemeModule),
        typeof(AbpTenantManagementEntityFrameworkCoreModule),
        typeof(AbpTenantManagementApplicationContractsModule)
    )]
    public class AuthServerHostModule : AbpModule
    {
        private bool isMultiTenancyEnabled = false;

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            context.Services.AddAbpDbContext<AuthServerDbContext>(options =>
            {
                options.AddDefaultRepositories();
            });

            Configure<AbpMultiTenancyOptions>(options =>
            {
                options.IsEnabled = isMultiTenancyEnabled;
            });

            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Languages.Add(new LanguageInfo("en", "en", "English"));
            });

            Configure<AbpAuditingOptions>(options =>
            {
                options.IsEnabledForGetRequests = true;
                options.ApplicationName = "AuthServer";
            });

            //context.Services.AddStackExchangeRedisCache(options =>
            //{
            //    options.Configuration = configuration["Redis:Configuration"];
            //});

            //TODO: ConnectionMultiplexer.Connect call has problem since redis may not be ready when this service has started!
            //var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
            //context.Services.AddDataProtection().PersistKeysToStackExchangeRedis(redis, "MsDemo-DataProtection-Keys");
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();

            app.UseCorrelationId();
            app.UseVirtualFiles();
            app.UseRouting();
            app.UseAbpRequestLocalization();
            if (isMultiTenancyEnabled)
            {
                app.UseMultiTenancy();
            }
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseAuditing();
            app.UseConfiguredEndpoints();

            //TODO: Problem on a clustered environment
            AsyncHelper.RunSync(async () =>
            {
                using (var scope = context.ServiceProvider.CreateScope())
                {
                    await scope.ServiceProvider
                        .GetRequiredService<IDataSeeder>()
                        .SeedAsync();
                }
            });
        }
    }
}
