using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using KissU.Surging.CPlatform.Runtime.Server;
using KissU.Surging.Kestrel.Swagger.Swagger.Model;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace KissU.Surging.Kestrel.Swagger.SwaggerGen.Generator
{
    /// <summary>
    /// SwaggerGeneratorOptions.
    /// </summary>
    public class SwaggerGeneratorOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwaggerGeneratorOptions" /> class.
        /// </summary>
        public SwaggerGeneratorOptions()
        {
            SwaggerDocs = new Dictionary<string, Info>();
            DocInclusionPredicate = DefaultDocInclusionPredicate;
            DocInclusionPredicateV2 = DefaultDocInclusionPredicateV2;
            OperationIdSelector = DefaultOperationIdSelector;
            TagsSelector = DefaultTagsSelector;
            SortKeySelector = DefaultSortKeySelector;
            SecurityDefinitions = new Dictionary<string, SecurityScheme>();
            SecurityRequirements = new List<IDictionary<string, IEnumerable<string>>>();
            ParameterFilters = new List<IParameterFilter>();
            OperationFilters = new List<IOperationFilter>();
            DocumentFilters = new List<IDocumentFilter>();
        }

        /// <summary>
        /// Gets or sets the swagger docs.
        /// </summary>
        public IDictionary<string, Info> SwaggerDocs { get; set; }

        /// <summary>
        /// Gets or sets the document inclusion predicate.
        /// </summary>
        public Func<string, ApiDescription, bool> DocInclusionPredicate { get; set; }

        /// <summary>
        /// Gets or sets the document inclusion predicate v2.
        /// </summary>
        public Func<string, ServiceEntry, bool> DocInclusionPredicateV2 { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [ignore obsolete actions].
        /// </summary>
        public bool IgnoreObsoleteActions { get; set; }

        /// <summary>
        /// Gets or sets the conflicting actions resolver.
        /// </summary>
        public Func<IEnumerable<ApiDescription>, ApiDescription> ConflictingActionsResolver { get; set; }

        /// <summary>
        /// Gets or sets the operation identifier selector.
        /// </summary>
        public Func<ApiDescription, string> OperationIdSelector { get; set; }

        /// <summary>
        /// Gets or sets the tags selector.
        /// </summary>
        public Func<ApiDescription, IList<string>> TagsSelector { get; set; }

        /// <summary>
        /// Gets or sets the sort key selector.
        /// </summary>
        public Func<ApiDescription, string> SortKeySelector { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [describe all parameters in camel case].
        /// </summary>
        public bool DescribeAllParametersInCamelCase { get; set; }

        /// <summary>
        /// Gets or sets the security definitions.
        /// </summary>
        public IDictionary<string, SecurityScheme> SecurityDefinitions { get; set; }

        /// <summary>
        /// Gets or sets the security requirements.
        /// </summary>
        public IList<IDictionary<string, IEnumerable<string>>> SecurityRequirements { get; set; }

        /// <summary>
        /// Gets or sets the parameter filters.
        /// </summary>
        public IList<IParameterFilter> ParameterFilters { get; set; }

        /// <summary>
        /// Gets or sets the operation filters.
        /// </summary>
        public List<IOperationFilter> OperationFilters { get; set; }

        /// <summary>
        /// Gets or sets the document filters.
        /// </summary>
        public IList<IDocumentFilter> DocumentFilters { get; set; }

        private bool DefaultDocInclusionPredicate(string documentName, ApiDescription apiDescription)
        {
            return apiDescription.GroupName == null || apiDescription.GroupName == documentName;
        }

        private bool DefaultDocInclusionPredicateV2(string documentName, ServiceEntry apiDescription)
        {
            var assembly = apiDescription.Type.Assembly;

            var versions = assembly
                .GetCustomAttributes(true)
                .OfType<AssemblyVersionAttribute>();
            return versions != null;
        }

        private string DefaultOperationIdSelector(ApiDescription apiDescription)
        {
            var routeName = apiDescription.ActionDescriptor.AttributeRouteInfo?.Name;
            if (routeName != null) return routeName;

            if (apiDescription.TryGetMethodInfo(out var methodInfo)) return methodInfo.Name;

            return null;
        }

        private IList<string> DefaultTagsSelector(ApiDescription apiDescription)
        {
            return new[] {apiDescription.ActionDescriptor.RouteValues["controller"]};
        }

        private string DefaultSortKeySelector(ApiDescription apiDescription)
        {
            return TagsSelector(apiDescription).First();
        }
    }
}