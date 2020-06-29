using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Extensions;
using KissU.Modules.Application.MultiTenancy;
using KissU.Modules.Application.Service.Contracts;
using KissU.Surging.ProxyGenerator;

namespace KissU.Modules.Application.Service.Implements
{
    [ModuleName("Bloging")]
    public class BlogingTenantService : AbpTenantService
    {
        protected BlogingTenantService(IAbpTenantAppService appService) : base(appService)
        {
        }
    }
}