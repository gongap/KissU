using System;

namespace KissU.Core.Swagger.Swagger.Model
{
    public interface ISwaggerProvider
    {
        SwaggerDocument GetSwagger(
            string documentName,
            string host = null,
            string basePath = null,
            string[] schemes = null);
    }

    public class UnknownSwaggerDocument : Exception
    {
        public UnknownSwaggerDocument(string documentName)
            : base(string.Format("Unknown Swagger document - {0}", documentName))
        {}
    }
}