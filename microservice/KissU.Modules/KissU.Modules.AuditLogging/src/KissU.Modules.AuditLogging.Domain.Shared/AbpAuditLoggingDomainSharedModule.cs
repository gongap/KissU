using KissU.Modules.AuditLogging.Domain.Shared.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace KissU.Modules.AuditLogging.Domain.Shared
{
    public class AbpAuditLoggingDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(Volo.Abp.Modularity.ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources.Add<AuditLoggingResource>("en");
            });
        }
    }
}
