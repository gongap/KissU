using System;
using System.IO;
using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Kestrel.Http.Abstractions;
using KissU.Kestrel.Http.Internal;
using KissU.Modules.Blogging.Application.Contracts.Files;
using KissU.Modules.Blogging.Service.Contracts;
using KissU.ServiceProxy;
using Volo.Abp;
using Volo.Abp.Http;

namespace KissU.Modules.Blogging.Service.Implements
{
    [ModuleName("BlogFiles")]
    public class BlogFilesService : ProxyServiceBase, IBlogFilesService
    {
        private readonly IFileAppService _fileAppService;

        public BlogFilesService(IFileAppService fileAppService)
        {
            _fileAppService = fileAppService;
        }

        public async Task<RawFileDto> GetAsync(string name)
        {
            return await _fileAppService.GetAsync(name);
        }

        public async Task<FileResult> GetForWebAsync(string fileName)
        {
            var file = await _fileAppService.GetAsync(fileName);
            var contentType = MimeTypes.GetByExtension(Path.GetExtension(fileName));
            return new FileContentResult(file.Bytes, contentType, fileName);
        }

        public async Task<FileUploadOutputDto> CreateAsync(FileUploadInputDto input)
        {
            return await _fileAppService.CreateAsync(input);
        }

        public async Task<FileUploadResult> UploadAsync(HttpFormCollection formData)
        {
            var file = formData.Files[0];

            if (file.Length <= 0)
            {
                throw new UserFriendlyException("File is empty!");
            }

            if (!file.ContentType.Contains("image"))
            {
                throw new UserFriendlyException("Not a valid image!");
            }

            var output = await _fileAppService.CreateAsync(
                new FileUploadInputDto
                {
                    Bytes = file.File,
                    Name = file.FileName
                }
            );

            return new FileUploadResult(output.WebUrl);
        }
    }
}
