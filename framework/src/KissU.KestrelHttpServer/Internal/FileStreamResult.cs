using System;
using System.IO;
using System.Net.Http.Headers;
using KissU.KestrelHttpServer.Abstractions;

namespace KissU.KestrelHttpServer.Internal
{
    /// <summary>
    /// FileStreamResult.
    /// Implements the <see cref="KissU.KestrelHttpServer.Abstractions.FileResult" />
    /// </summary>
    /// <seealso cref="KissU.KestrelHttpServer.Abstractions.FileResult" />
    public class FileStreamResult : FileResult
    {
        private Stream _fileStream;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileStreamResult" /> class.
        /// </summary>
        /// <param name="fileStream">The file stream.</param>
        /// <param name="contentType">Type of the content.</param>
        public FileStreamResult(Stream fileStream, string contentType)
            : this(fileStream, MediaTypeHeaderValue.Parse(contentType))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileStreamResult" /> class.
        /// </summary>
        /// <param name="fileStream">The file stream.</param>
        /// <param name="contentType">Type of the content.</param>
        /// <exception cref="ArgumentNullException">fileStream</exception>
        public FileStreamResult(Stream fileStream, MediaTypeHeaderValue contentType)
            : base(contentType?.ToString())
        {
            if (fileStream == null)
            {
                throw new ArgumentNullException(nameof(fileStream));
            }

            FileStream = fileStream;
        }

        /// <summary>
        /// Gets or sets the file stream.
        /// </summary>
        /// <exception cref="ArgumentNullException">value</exception>
        public Stream FileStream
        {
            get => _fileStream;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                _fileStream = value;
            }
        }
    }
}