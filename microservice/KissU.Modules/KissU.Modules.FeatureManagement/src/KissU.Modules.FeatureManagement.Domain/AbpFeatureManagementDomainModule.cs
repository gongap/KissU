using KissU.Modules.FeatureManagement.Domain.Shared;
using KissU.Modules.FeatureManagement.Domain.Shared.Localization;
using Volo.Abp.Caching;
using Volo.Abp.Features;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;

namespace KissU.Modules.FeatureManagement.Domain
{
    [DependsOn(
        typeof(AbpFeatureManagementDomainSharedModule),
        typeof(AbpFeaturesModule),
        typeof(AbpCachingModule)
        )]
    public class AbpFeatureManagementDomainModule : AbpModule
    {
        public override void ConfigureServices(Volo.Abp.Modularity.ServiceConfigurationContext context)
        {
            Configure<FeatureManagementOptions>(options =>
            {
                options.Providers.Add<DefaultValueFeatureManagementProvider>();
                options.Providers.Add<EditionFeatureManagementProvider>();

                //TODO: Should be moved to the Tenant Management module
                options.Providers.Add<TenantFeatureManagementProvider>();
                options.ProviderPolicies[TenantFeatureValueProvider.ProviderName] = "AbpTenantManagement.Tenants.ManageFeatures";
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("AbpFeatureManagement", typeof(AbpFeatureManagementResource));
            });
        }
    }
}
