using Volo.Abp.Application;
using Volo.Abp.AspNetCore;
using Volo.Abp.Auditing;
using Volo.Abp.Authorization;
using Volo.Abp.Autofac;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.ExceptionHandling;
using Volo.Abp.Features;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Settings;
using Volo.Abp.Timing;
using Volo.Abp.Validation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.Caching.StackExchangeRedis;
using System.Threading.Tasks;
using Volo.Abp;
using KissU.Abp.AppConfigurations;
using Volo.Abp.Threading;

namespace KissU.Abp
{
    [DependsOn(typeof(AbpAutofacModule)
        , typeof(AbpAuthorizationModule)
        , typeof(AbpAuditingModule)
        , typeof(AbpFeaturesModule)
        , typeof(AbpSettingsModule)
        , typeof(AbpAuthorizationModule)
        , typeof(AbpValidationModule) 
        , typeof(AbpTimingModule)
        , typeof(AbpLocalizationModule)
        , typeof(AbpMultiTenancyModule)
        , typeof(AbpCachingStackExchangeRedisModule)
        , typeof(AbpEventBusRabbitMqModule)
        , typeof(AbpExceptionHandlingModule)
        , typeof(AbpAspNetCoreModule)
        , typeof(AbpDddApplicationContractsModule)
    )]
    public class AbpStartupModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            if (CPlatform.AppConfig.ServerOptions.AlwaysAllowAuthorization)
            {
                context.Services.AddAlwaysAllowAuthorization();
            }

            var configuration = context.Services.GetConfiguration();
            var clockSection = configuration.GetSection(nameof(AbpClockOptions));
            if (clockSection.Exists())
            {
                Configure<AbpClockOptions>(clockSection);
            }
            else
            {
                Configure<AbpClockOptions>(options =>
                {
                    options.Kind =  DateTimeKind.Utc;
                });
            }

            var multiTenancySection = configuration.GetSection(nameof(AbpMultiTenancyOptions));
            if (multiTenancySection.Exists())
            {
                Configure<AbpMultiTenancyOptions>(multiTenancySection);
            }

            Configure<AbpTenantResolveOptions>(options =>
            {
                options.TenantResolvers.Add(new AbpTenantResolveContributor());
            });

            Configure<AbpAuditingOptions>(options =>
            {
                options.Contributors.Add(new AbpAuditLogContributor());
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            AsyncHelper.RunSync(() => OnApplicationInitializationAsync(context));
        }

        public async override Task OnApplicationInitializationAsync(ApplicationInitializationContext context)
        {
            await context.ServiceProvider.GetRequiredService<CachedAppConfigurationClient>().InitializeAsync();
        }
    }
}
