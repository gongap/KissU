using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace KissU.Surging.Swagger.SwaggerGen.Generator
{
    /// <summary>
    /// SchemaRegistryFactory.
    /// Implements the <see cref="KissU.Surging.Swagger.SwaggerGen.Generator.ISchemaRegistryFactory" />
    /// </summary>
    /// <seealso cref="KissU.Surging.Swagger.SwaggerGen.Generator.ISchemaRegistryFactory" />
    public class SchemaRegistryFactory : ISchemaRegistryFactory
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        private readonly SchemaRegistryOptions _schemaRegistryOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaRegistryFactory" /> class.
        /// </summary>
        /// <param name="mvcJsonOptionsAccessor">The MVC json options accessor.</param>
        /// <param name="schemaRegistryOptionsAccessor">The schema registry options accessor.</param>
        public SchemaRegistryFactory(
            IOptions<MvcNewtonsoftJsonOptions> mvcJsonOptionsAccessor,
            IOptions<SchemaRegistryOptions> schemaRegistryOptionsAccessor)
            : this(mvcJsonOptionsAccessor.Value.SerializerSettings, schemaRegistryOptionsAccessor.Value)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaRegistryFactory" /> class.
        /// </summary>
        /// <param name="jsonSerializerSettings">The json serializer settings.</param>
        /// <param name="schemaRegistryOptions">The schema registry options.</param>
        public SchemaRegistryFactory(
            JsonSerializerSettings jsonSerializerSettings,
            SchemaRegistryOptions schemaRegistryOptions)
        {
            _jsonSerializerSettings = jsonSerializerSettings;
            _schemaRegistryOptions = schemaRegistryOptions;
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>ISchemaRegistry.</returns>
        public ISchemaRegistry Create()
        {
            return new SchemaRegistry(_jsonSerializerSettings, _schemaRegistryOptions);
        }
    }
}