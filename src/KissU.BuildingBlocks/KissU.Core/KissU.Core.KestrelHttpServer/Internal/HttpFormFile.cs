namespace KissU.Core.KestrelHttpServer.Internal
{
    /// <summary>
    /// HttpFormFile.
    /// </summary>
    public class HttpFormFile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpFormFile"/> class.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <param name="name">The name.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="file">The file.</param>
        public HttpFormFile(long length, string name, string fileName,byte[] file)
        {
            Length = length;
            Name = name;
            FileName = fileName;
            File = file;
        }
        /// <summary>
        /// Gets the length.
        /// </summary>
        public long Length { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        public string FileName { get; }

        /// <summary>
        /// Gets the file.
        /// </summary>
        public byte[] File { get; } 
    }
}
