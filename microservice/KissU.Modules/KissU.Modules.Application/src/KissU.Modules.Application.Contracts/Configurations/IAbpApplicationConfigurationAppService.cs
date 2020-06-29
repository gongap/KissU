using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace KissU.Modules.Application.Configurations
{
    public interface IAbpApplicationConfigurationAppService : IApplicationService
    {
        Task<ApplicationConfigurationDto> GetAsync();
    }
}