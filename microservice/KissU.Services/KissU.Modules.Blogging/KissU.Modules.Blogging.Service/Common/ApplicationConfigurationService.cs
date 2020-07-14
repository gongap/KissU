using KissU.Dependency;
using KissU.Modules.Application.Configurations;
using KissU.Modules.Application.Service.Implements;

namespace KissU.Modules.Blogging.Service.Common
{
    [ModuleName("Bloging")]
    public class BlogingApplicationConfigurationService : AbpApplicationConfigurationService
    {
        public BlogingApplicationConfigurationService(IAbpApplicationConfigurationAppService appService) : base(appService)
        {
        }
    }
}