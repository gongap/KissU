using Volo.Abp.Application.Services;
using KissU.Modules.FeatureManagement.Localization;

namespace KissU.Modules.FeatureManagement
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