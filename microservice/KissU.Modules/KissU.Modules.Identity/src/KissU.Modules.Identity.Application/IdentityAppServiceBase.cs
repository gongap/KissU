using KissU.Modules.Identity.Domain.Shared.Localization;
using Volo.Abp.Application.Services;

namespace KissU.Modules.Identity.Application
{
    public abstract class IdentityAppServiceBase : ApplicationService
    {
        protected IdentityAppServiceBase()
        {
            ObjectMapperContext = typeof(AbpIdentityApplicationModule);
            LocalizationResource = typeof(IdentityResource);
        }
    }
}
