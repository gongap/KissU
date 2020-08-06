using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Modules.Blogging.Application.Contracts.Files;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.KestrelHttpServer.Abstractions;
using KissU.KestrelHttpServer.Internal;

namespace KissU.Modules.Blogging.Service.Contracts
{
    [ServiceBundle("api/blogging/files")]
    public interface IBlogFilesService : IServiceKey
    {
        [HttpGet(true)]
        [ServiceRoute("{name}")]
        Task<RawFileDto> GetAsync(string name);

        [HttpGet(true)]
        [ServiceRoute("www/{name}")]
        Task<FileResult> GetForWebAsync(string fileName);

        [HttpPost(true)]
        Task<FileUploadOutputDto> CreateAsync(FileUploadInputDto input);

        [HttpPost(true)]
        [ServiceRoute("images")]
        Task<FileUploadResult> UploadAsync(HttpFormCollection formData);
    }
}
