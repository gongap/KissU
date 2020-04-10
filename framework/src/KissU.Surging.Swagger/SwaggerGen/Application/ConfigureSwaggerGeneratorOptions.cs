using System;
using System.Collections.Generic;
using KissU.Surging.Swagger.Swagger.Model;
using KissU.Surging.Swagger.SwaggerGen.Generator;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace KissU.Surging.Swagger.SwaggerGen.Application
{
    /// <summary>
    /// ConfigureSwaggerGeneratorOptions.
    /// Implements the
    /// <see
    ///     cref="Microsoft.Extensions.Options.IConfigureOptions{KissU.Surging.Swagger.SwaggerGen.Generator.SwaggerGeneratorOptions}" />
    /// </summary>
    /// <seealso
    ///     cref="Microsoft.Extensions.Options.IConfigureOptions{KissU.Surging.Swagger.SwaggerGen.Generator.SwaggerGeneratorOptions}" />
    internal class ConfigureSwaggerGeneratorOptions : IConfigureOptions<SwaggerGeneratorOptions>
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly SwaggerGenOptions _swaggerGenOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigureSwaggerGeneratorOptions" /> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="swaggerGenOptionsAccessor">The swagger gen options accessor.</param>
        public ConfigureSwaggerGeneratorOptions(
            IServiceProvider serviceProvider,
            IOptions<SwaggerGenOptions> swaggerGenOptionsAccessor)
        {
            _serviceProvider = serviceProvider;
            _swaggerGenOptions = swaggerGenOptionsAccessor.Value;
        }

        /// <summary>
        /// Invoked to configure a <typeparamref name="TOptions" /> instance.
        /// </summary>
        /// <param name="options">The options instance to configure.</param>
        public void Configure(SwaggerGeneratorOptions options)
        {
            DeepCopy(_swaggerGenOptions.SwaggerGeneratorOptions, options);

            // Create and add any filters that were specified through the FilterDescriptor lists ...

            _swaggerGenOptions.ParameterFilterDescriptors.ForEach(
                filterDescriptor => options.ParameterFilters.Add(CreateFilter<IParameterFilter>(filterDescriptor)));

            _swaggerGenOptions.OperationFilterDescriptors.ForEach(
                filterDescriptor => options.OperationFilters.Add(CreateFilter<IOperationFilter>(filterDescriptor)));

            _swaggerGenOptions.DocumentFilterDescriptors.ForEach(
                filterDescriptor => options.DocumentFilters.Add(CreateFilter<IDocumentFilter>(filterDescriptor)));
        }

        /// <summary>
        /// Deeps the copy.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="target">The target.</param>
        public void DeepCopy(SwaggerGeneratorOptions source, SwaggerGeneratorOptions target)
        {
            target.SwaggerDocs = new Dictionary<string, Info>(source.SwaggerDocs);
            target.DocInclusionPredicate = source.DocInclusionPredicate;
            target.IgnoreObsoleteActions = source.IgnoreObsoleteActions;
            target.DocInclusionPredicateV2 = source.DocInclusionPredicateV2;
            target.ConflictingActionsResolver = source.ConflictingActionsResolver;
            target.OperationIdSelector = source.OperationIdSelector;
            target.TagsSelector = source.TagsSelector;
            target.SortKeySelector = source.SortKeySelector;
            target.DescribeAllParametersInCamelCase = source.DescribeAllParametersInCamelCase;
            target.SecurityDefinitions = new Dictionary<string, SecurityScheme>(source.SecurityDefinitions);
            target.SecurityRequirements =
                new List<IDictionary<string, IEnumerable<string>>>(source.SecurityRequirements);
            target.ParameterFilters = new List<IParameterFilter>(source.ParameterFilters);
            target.OperationFilters = new List<IOperationFilter>(source.OperationFilters);
            target.DocumentFilters = new List<IDocumentFilter>(source.DocumentFilters);
        }

        private TFilter CreateFilter<TFilter>(FilterDescriptor filterDescriptor)
        {
            return (TFilter) ActivatorUtilities
                .CreateInstance(_serviceProvider, filterDescriptor.Type, filterDescriptor.Arguments);
        }
    }
}