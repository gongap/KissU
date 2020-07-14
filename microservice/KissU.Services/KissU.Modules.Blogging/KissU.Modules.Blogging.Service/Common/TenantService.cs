using KissU.Dependency;
using KissU.Modules.Application.MultiTenancy;
using KissU.Modules.Application.Service.Implements;

namespace KissU.Modules.Blogging.Service.Common
{
    [ModuleName("Bloging")]
    public class BlogingTenantService : AbpTenantService
    {
        protected BlogingTenantService(IAbpTenantAppService appService) : base(appService)
        {
        }
    }
}