using System;

namespace KissU.KestrelHttpServer.Abstractions
{
    /// <summary>
    /// FileResult.
    /// Implements the <see cref="KissU.KestrelHttpServer.Abstractions.ActionResult" />
    /// </summary>
    /// <seealso cref="KissU.KestrelHttpServer.Abstractions.ActionResult" />
    public abstract class FileResult : ActionResult
    {
        private string _fileDownloadName;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileResult" /> class.
        /// </summary>
        /// <param name="contentType">Type of the content.</param>
        /// <exception cref="ArgumentNullException">contentType</exception>
        protected FileResult(string contentType)
        {
            if (contentType == null)
            {
                throw new ArgumentNullException(nameof(contentType));
            }

            ContentType = contentType;
        }

        /// <summary>
        /// Gets the type of the content.
        /// </summary>
        public string ContentType { get; }


        /// <summary>
        /// Gets or sets the name of the file download.
        /// </summary>
        public string FileDownloadName
        {
            get => _fileDownloadName ?? string.Empty;
            set => _fileDownloadName = value;
        }
    }
}