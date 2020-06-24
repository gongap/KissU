using System;

namespace KissU.Surging.Kestrel.Swagger.Swagger.Model
{
    /// <summary>
    /// Interface ISwaggerProvider
    /// </summary>
    public interface ISwaggerProvider
    {
        /// <summary>
        /// Gets the swagger.
        /// </summary>
        /// <param name="documentName">Name of the document.</param>
        /// <param name="host">The host.</param>
        /// <param name="basePath">The base path.</param>
        /// <param name="schemes">The schemes.</param>
        /// <returns>SwaggerDocument.</returns>
        SwaggerDocument GetSwagger(
            string documentName,
            string host = null,
            string basePath = null,
            string[] schemes = null);
    }

    /// <summary>
    /// UnknownSwaggerDocument.
    /// Implements the <see cref="System.Exception" />
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class UnknownSwaggerDocument : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnknownSwaggerDocument" /> class.
        /// </summary>
        /// <param name="documentName">Name of the document.</param>
        public UnknownSwaggerDocument(string documentName)
            : base(string.Format("Unknown Swagger document - {0}", documentName))
        {
        }
    }
}