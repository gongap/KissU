using System;
using System.IO;
using System.Threading.Tasks;
using KissU.Core.KestrelHttpServer.Internal;
using Microsoft.Net.Http.Headers;

namespace KissU.Core.KestrelHttpServer.Abstractions
{
    /// <summary>
    /// FileContentResult.
    /// Implements the <see cref="KissU.Core.KestrelHttpServer.Abstractions.FileResult" />
    /// </summary>
    /// <seealso cref="KissU.Core.KestrelHttpServer.Abstractions.FileResult" />
    public class FileContentResult : FileResult
    {
        private byte[] _fileContents;
        /// <summary>
        /// The buffer size
        /// </summary>
        protected const int BufferSize = 64 * 1024;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileContentResult" /> class.
        /// </summary>
        /// <param name="fileContents">The file contents.</param>
        /// <param name="contentType">Type of the content.</param>
        /// <exception cref="ArgumentNullException">fileContents</exception>
        public FileContentResult(byte[] fileContents, string contentType)
            : this(fileContents, MediaTypeHeaderValue.Parse(contentType))
        {
            if (fileContents == null)
            {
                throw new ArgumentNullException(nameof(fileContents));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileContentResult" /> class.
        /// </summary>
        /// <param name="fileContents">The file contents.</param>
        /// <param name="contentType">Type of the content.</param>
        /// <param name="fileDownloadName">Name of the file download.</param>
        /// <exception cref="ArgumentNullException">fileContents</exception>
        /// <exception cref="ArgumentNullException">fileDownloadName</exception>
        /// <exception cref="ArgumentNullException">fileContents</exception>
        public FileContentResult(byte[] fileContents, string contentType,string fileDownloadName)
      : this(fileContents, MediaTypeHeaderValue.Parse(contentType))
        {
            if (fileContents == null)
            {
                throw new ArgumentNullException(nameof(fileContents));
            }
            if (fileDownloadName == null)
            {
                throw new ArgumentNullException(nameof(fileDownloadName));
            }
            this.FileDownloadName = fileDownloadName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileContentResult" /> class.
        /// </summary>
        /// <param name="fileContents">The file contents.</param>
        /// <param name="contentType">Type of the content.</param>
        /// <exception cref="ArgumentNullException">fileContents</exception>
        public FileContentResult(byte[] fileContents, MediaTypeHeaderValue contentType)
            : base(contentType?.ToString())
        {
            if (fileContents == null)
            {
                throw new ArgumentNullException(nameof(fileContents));
            }

            FileContents = fileContents;
        }

        /// <summary>
        /// Gets or sets the file contents.
        /// </summary>
        /// <exception cref="ArgumentNullException">value</exception>
        public byte[] FileContents
        {
            get => _fileContents;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                _fileContents = value;
            }
        }

        /// <summary>
        /// execute result as an asynchronous operation.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="ArgumentNullException">context</exception>
        public override async Task ExecuteResultAsync(ActionContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            try
            {
                var contentDisposition = new ContentDispositionHeaderValue("attachment");
                contentDisposition.SetHttpFileName(FileDownloadName);
                var httpResponse = context.HttpContext.Response;

                httpResponse.Headers.Add("Content-Type", this.ContentType);
                httpResponse.Headers.Add("Content-Length", FileContents.Length.ToString());
                httpResponse.Headers[HeaderNames.ContentDisposition] = contentDisposition.ToString();
                using (var stream = new MemoryStream(FileContents))
                    await StreamCopyOperation.CopyToAsync(stream, httpResponse.Body, count: null, bufferSize: BufferSize, cancel: context.HttpContext.RequestAborted);
            }
            catch (OperationCanceledException)
            {
                context.HttpContext.Abort();
            }
        }
    }
}
