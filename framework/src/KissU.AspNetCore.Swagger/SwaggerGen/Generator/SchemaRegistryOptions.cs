using System;
using System.Collections.Generic;
using KissU.Kestrel.Swagger.Swagger.Model;

namespace KissU.Kestrel.Swagger.SwaggerGen.Generator
{
    /// <summary>
    /// SchemaRegistryOptions.
    /// </summary>
    public class SchemaRegistryOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaRegistryOptions" /> class.
        /// </summary>
        public SchemaRegistryOptions()
        {
            CustomTypeMappings = new Dictionary<Type, Func<Schema>>();
            SchemaIdSelector = type => type.FriendlyId(IgnoreFullyQualified);
            SchemaFilters = new List<ISchemaFilter>();
        }

        /// <summary>
        /// Gets or sets the custom type mappings.
        /// </summary>
        public IDictionary<Type, Func<Schema>> CustomTypeMappings { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [describe all enums as strings].
        /// </summary>
        public bool DescribeAllEnumsAsStrings { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [describe string enums in camel case].
        /// </summary>
        public bool DescribeStringEnumsInCamelCase { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [use referenced definitions for enums].
        /// </summary>
        public bool UseReferencedDefinitionsForEnums { get; set; }

        /// <summary>
        /// Gets or sets the schema identifier selector.
        /// </summary>
        public Func<Type, string> SchemaIdSelector { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [ignore fully qualified].
        /// </summary>
        public bool IgnoreFullyQualified { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [ignore obsolete properties].
        /// </summary>
        public bool IgnoreObsoleteProperties { get; set; }

        /// <summary>
        /// Gets or sets the schema filters.
        /// </summary>
        public IList<ISchemaFilter> SchemaFilters { get; set; }
    }
}