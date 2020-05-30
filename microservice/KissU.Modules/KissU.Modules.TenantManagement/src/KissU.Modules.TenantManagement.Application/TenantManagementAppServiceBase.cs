using Volo.Abp.Application.Services;
using KissU.Modules.TenantManagement.Localization;

namespace KissU.Modules.TenantManagement
{
    public abstract class TenantManagementAppServiceBase : ApplicationService
    {
        protected TenantManagementAppServiceBase()
        {
            ObjectMapperContext = typeof(AbpTenantManagementApplicationModule);
            LocalizationResource = typeof(AbpTenantManagementResource);
        }
    }
}