using System;
using System.Collections.Generic;
using KissU.Surging.Swagger.Swagger.Model;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace KissU.Surging.Swagger.SwaggerGen.Generator
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
        /// <param name="apiDescriptionsGroups">The API descriptions groups.</param>
        /// <param name="apiDescriptions">The API descriptions.</param>
        /// <param name="schemaRegistry">The schema registry.</param>
        public DocumentFilterContext(
            ApiDescriptionGroupCollection apiDescriptionsGroups,
            IEnumerable<ApiDescription> apiDescriptions,
            ISchemaRegistry schemaRegistry)
        {
            ApiDescriptionsGroups = apiDescriptionsGroups;
            ApiDescriptions = apiDescriptions;
            SchemaRegistry = schemaRegistry;
        }

        /// <summary>
        /// Gets the API descriptions groups.
        /// </summary>
        [Obsolete("Deprecated: Use ApiDescriptions")]
        public ApiDescriptionGroupCollection ApiDescriptionsGroups { get; }

        /// <summary>
        /// Gets the API descriptions.
        /// </summary>
        public IEnumerable<ApiDescription> ApiDescriptions { get; }

        /// <summary>
        /// Gets the schema registry.
        /// </summary>
        public ISchemaRegistry SchemaRegistry { get; }
    }
}