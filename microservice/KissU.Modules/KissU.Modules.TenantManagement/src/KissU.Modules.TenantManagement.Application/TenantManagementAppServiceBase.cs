using KissU.Modules.TenantManagement.Domain.Shared.Localization;
using Volo.Abp.Application.Services;

namespace KissU.Modules.TenantManagement.Application
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