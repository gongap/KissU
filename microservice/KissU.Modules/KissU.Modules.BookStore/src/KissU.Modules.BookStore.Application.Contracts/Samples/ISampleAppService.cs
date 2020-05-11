using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace KissU.Modules.BookStore.Samples
{
    public interface ISampleAppService : IApplicationService
    {
        Task<SampleDto> GetAsync();

        Task<SampleDto> GetAuthorizedAsync();
    }
}
