using System;
using System.Collections.Generic;
using KissU.Kestrel.Swagger.Swagger.Model;
using KissU.Kestrel.Swagger.SwaggerGen.Generator;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace KissU.Kestrel.Swagger.SwaggerGen.Application
{
    /// <summary>
    /// ConfigureSchemaRegistryOptions.
    /// Implements the
    /// <see
    ///     cref="SchemaRegistryOptions" />
    /// </summary>
    /// <seealso
    ///     cref="SchemaRegistryOptions" />
    internal class ConfigureSchemaRegistryOptions : IConfigureOptions<SchemaRegistryOptions>
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly SwaggerGenOptions _swaggerGenOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigureSchemaRegistryOptions" /> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="swaggerGenOptionsAccessor">The swagger gen options accessor.</param>
        public ConfigureSchemaRegistryOptions(
            IServiceProvider serviceProvider,
            IOptions<SwaggerGenOptions> swaggerGenOptionsAccessor)
        {
            _serviceProvider = serviceProvider;
            _swaggerGenOptions = swaggerGenOptionsAccessor.Value;
        }

        /// <summary>
        /// Configures the specified options.
        /// </summary>
        /// <param name="options">The options.</param>
        public void Configure(SchemaRegistryOptions options)
        {
            DeepCopy(_swaggerGenOptions.SchemaRegistryOptions, options);

            // Create and add any filters that were specified through the FilterDescriptor lists
            _swaggerGenOptions.SchemaFilterDescriptors.ForEach(
                filterDescriptor => options.SchemaFilters.Add(CreateFilter<ISchemaFilter>(filterDescriptor)));
        }

        private void DeepCopy(SchemaRegistryOptions source, SchemaRegistryOptions target)
        {
            target.CustomTypeMappings = new Dictionary<Type, Func<Schema>>(source.CustomTypeMappings);
            target.DescribeAllEnumsAsStrings = source.DescribeAllEnumsAsStrings;
            target.IgnoreFullyQualified = source.IgnoreFullyQualified;
            target.DescribeStringEnumsInCamelCase = source.DescribeStringEnumsInCamelCase;
            target.UseReferencedDefinitionsForEnums = source.UseReferencedDefinitionsForEnums;
            target.SchemaIdSelector = source.SchemaIdSelector;
            target.IgnoreObsoleteProperties = source.IgnoreObsoleteProperties;
            target.SchemaFilters = new List<ISchemaFilter>(source.SchemaFilters);
        }

        private TFilter CreateFilter<TFilter>(FilterDescriptor filterDescriptor)
        {
            return (TFilter) ActivatorUtilities
                .CreateInstance(_serviceProvider, filterDescriptor.Type, filterDescriptor.Arguments);
        }
    }
}