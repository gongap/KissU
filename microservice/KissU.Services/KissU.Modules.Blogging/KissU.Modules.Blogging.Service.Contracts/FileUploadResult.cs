namespace KissU.Modules.Blogging.Service.Contracts
{
    public class FileUploadResult
    {
        public string FileUrl { get; set; }

        public FileUploadResult(string fileUrl)
        {
            FileUrl = fileUrl;
        }
    }
}