using System;
using System.Collections.Generic;
using KissU.Core.Swagger.SwaggerGen.Generator;

namespace KissU.Core.Swagger.SwaggerGen.Application
{
    /// <summary>
    /// SwaggerGenOptions.
    /// </summary>
    public class SwaggerGenOptions
    {
        /// <summary>
        /// Gets or sets the swagger generator options.
        /// </summary>
        public SwaggerGeneratorOptions SwaggerGeneratorOptions { get; set; } = new SwaggerGeneratorOptions();

        /// <summary>
        /// Gets or sets the schema registry options.
        /// </summary>
        public SchemaRegistryOptions SchemaRegistryOptions { get; set; } = new SchemaRegistryOptions();

        // NOTE: Filter instances can be added directly to the options exposed above OR they can be specified in
        // the following lists. In the latter case, they will be instantiated and added when options are injected
        // into their target services. This "deferred instantiation" allows the filters to be created from the
        // DI container, thus supporting contructor injection of services within filters.

        /// <summary>
        /// Gets or sets the parameter filter descriptors.
        /// </summary>
        public List<FilterDescriptor> ParameterFilterDescriptors { get; set; } = new List<FilterDescriptor>();

        /// <summary>
        /// Gets or sets the operation filter descriptors.
        /// </summary>
        public List<FilterDescriptor> OperationFilterDescriptors { get; set; } = new List<FilterDescriptor>();

        /// <summary>
        /// Gets or sets the document filter descriptors.
        /// </summary>
        public List<FilterDescriptor> DocumentFilterDescriptors { get; set; } = new List<FilterDescriptor>();

        /// <summary>
        /// Gets or sets the schema filter descriptors.
        /// </summary>
        public List<FilterDescriptor> SchemaFilterDescriptors { get; set; } = new List<FilterDescriptor>();
    }

    /// <summary>
    /// FilterDescriptor.
    /// </summary>
    public class FilterDescriptor
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// Gets or sets the arguments.
        /// </summary>
        public object[] Arguments { get; set; }
    }
}