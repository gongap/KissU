using System.Threading.Tasks;
using KissU.Modules.Application.Configurations;
using KissU.Modules.Application.Service.Contracts;
using KissU.Surging.ProxyGenerator;

namespace KissU.Modules.Application.Service.Implements
{
    public abstract class AbpApplicationConfigurationService : ProxyServiceBase, IAbpApplicationConfigurationService
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