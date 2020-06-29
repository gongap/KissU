using System.Threading.Tasks;
using KissU.Modules.Application.Configurations;
using KissU.Modules.Application.Service.Contracts;
using KissU.Surging.ProxyGenerator;

namespace KissU.Modules.Application.Service.Implements
{
    public class AbpApplicationConfigurationService : ProxyServiceBase, IAbpApplicationConfigurationService
    {
        private readonly IAbpApplicationConfigurationService _appService;

        public AbpApplicationConfigurationService(IAbpApplicationConfigurationService appService)
        {
            _appService = appService;
        }

        public Task<ApplicationConfigurationDto> GetAsync()
        {
            return _appService.GetAsync();
        }
    }
}