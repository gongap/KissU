using System.Collections.Generic;
using KissU.AspNetCore.Swagger.Swagger.Model;
using KissU.CPlatform.Runtime.Server;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace KissU.AspNetCore.Swagger.SwaggerGen.Generator
{
    /// <summary>
    /// Interface IDocumentFilter
    /// </summary>
    public interface IDocumentFilter
    {
        /// <summary>
        /// Applies the specified swagger document.
        /// </summary>
        /// <param name="swaggerDoc">The swagger document.</param>
        /// <param name="context">The context.</param>
        void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context);
    }

    /// <summary>
    /// DocumentFilterContext.
    /// </summary>
    public class DocumentFilterContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentFilterContext" /> class.
        /// </summary>
        /// <param name="apiDescriptions">The API descriptions.</param>
        /// <param name="schemaRegistry">The schema registry.</param>
        public DocumentFilterContext(IEnumerable<ApiDescription> apiDescriptions, ISchemaRegistry schemaRegistry)
            :this(apiDescriptions, null, schemaRegistry)
        {
        }

        public DocumentFilterContext(
            IEnumerable<ApiDescription> apiDescriptions,
            IEnumerable<ServiceEntry> serviceEntries,
            ISchemaRegistry schemaRegistry)
        {
            ApiDescriptions = apiDescriptions;
            ServiceEntries = serviceEntries;
            SchemaRegistry = schemaRegistry;
        }

        /// <summary>
        /// Gets the API descriptions.
        /// </summary>
        public IEnumerable<ApiDescription> ApiDescriptions { get; }

        /// <summary>
        /// Gets or sets the service entries.
        /// </summary>
        public IEnumerable<ServiceEntry>  ServiceEntries { get; set; }

        /// <summary>
        /// Gets the schema registry.
        /// </summary>
        public ISchemaRegistry SchemaRegistry { get; }
    }
}