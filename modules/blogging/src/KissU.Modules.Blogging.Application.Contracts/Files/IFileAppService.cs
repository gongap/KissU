using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace KissU.Modules.Blogging.Application.Contracts.Files
{
    public interface IFileAppService : IApplicationService
    {
        Task<RawFileDto> GetAsync(string name);

        Task<FileUploadOutputDto> CreateAsync(FileUploadInputDto input);
    }
}
