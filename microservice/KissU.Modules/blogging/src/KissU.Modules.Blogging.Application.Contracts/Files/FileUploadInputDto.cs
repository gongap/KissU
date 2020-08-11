using System.ComponentModel.DataAnnotations;

namespace KissU.Modules.Blogging.Application.Contracts.Files
{
    public class FileUploadInputDto
    {
        [Required]
        public byte[] Bytes { get; set; }

        [Required]
        public string Name { get; set; }
    }
}