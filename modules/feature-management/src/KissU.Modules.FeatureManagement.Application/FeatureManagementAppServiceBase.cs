using KissU.Modules.FeatureManagement.Domain.Shared.Localization;
using Volo.Abp.Application.Services;

namespace KissU.Modules.FeatureManagement.Application
{
    public abstract class FeatureManagementAppServiceBase : ApplicationService
    {
        protected FeatureManagementAppServiceBase()
        {
            ObjectMapperContext = typeof(AbpFeatureManagementApplicationModule);
            LocalizationResource = typeof(AbpFeatureManagementResource);
        }
    }
}