using System;
using KissU.Core.Swagger.Swagger.Model;
using Newtonsoft.Json.Serialization;

namespace KissU.Core.Swagger.SwaggerGen.Generator
{
    /// <summary>
    /// Interface ISchemaFilter
    /// </summary>
    public interface ISchemaFilter
    {
        /// <summary>
        /// Applies the specified schema.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="context">The context.</param>
        void Apply(Schema schema, SchemaFilterContext context);
    }

    /// <summary>
    /// SchemaFilterContext.
    /// </summary>
    public class SchemaFilterContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaFilterContext" /> class.
        /// </summary>
        /// <param name="systemType">Type of the system.</param>
        /// <param name="jsonContract">The json contract.</param>
        /// <param name="schemaRegistry">The schema registry.</param>
        public SchemaFilterContext(
            Type systemType,
            JsonContract jsonContract,
            ISchemaRegistry schemaRegistry)
        {
            SystemType = systemType;
            JsonContract = jsonContract;
            SchemaRegistry = schemaRegistry;
        }

        /// <summary>
        /// Gets the type of the system.
        /// </summary>
        public Type SystemType { get; }

        /// <summary>
        /// Gets the json contract.
        /// </summary>
        public JsonContract JsonContract { get; }

        /// <summary>
        /// Gets the schema registry.
        /// </summary>
        public ISchemaRegistry SchemaRegistry { get; }
    }
}