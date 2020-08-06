using System.Threading.Tasks;
using KissU.Modules.Application.Configurations;
using KissU.Modules.Configuration.Service.Contracts;
using KissU.ServiceProxy;

namespace KissU.Modules.Configuration.Service.Implements
{
    public class AbpApplicationConfigurationService : ProxyServiceBase, IAbpApplicationConfigurationService
    {
        private readonly IAbpApplicationConfigurationAppService _appService;

        public AbpApplicationConfigurationService(IAbpApplicationConfigurationAppService appService)
        {
            _appService = appService;
        }

        public Task<ApplicationConfigurationDto> GetAsync()
        {
            return _appService.GetAsync();
        }
    }
}