using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Modules.Application.Configurations;
using KissU.Modules.Application.Service.Contracts;
using KissU.Surging.ProxyGenerator;

namespace KissU.Modules.Application.Service.Implements
{
    [ModuleName("Bloging")]
    public class BlogingApplicationConfigurationService : AbpApplicationConfigurationService
    {
        public BlogingApplicationConfigurationService(IAbpApplicationConfigurationAppService appService) : base(appService)
        {
        }
    }
}