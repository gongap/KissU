using System.Reflection;
using KissU.Kestrel.Swagger.Swagger.Model;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace KissU.Kestrel.Swagger.SwaggerGen.Generator
{
    /// <summary>
    /// Interface IParameterFilter
    /// </summary>
    public interface IParameterFilter
    {
        /// <summary>
        /// Applies the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <param name="context">The context.</param>
        void Apply(IParameter parameter, ParameterFilterContext context);
    }

    /// <summary>
    /// ParameterFilterContext.
    /// </summary>
    public class ParameterFilterContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterFilterContext" /> class.
        /// </summary>
        /// <param name="apiParameterDescription">The API parameter description.</param>
        /// <param name="schemaRegistry">The schema registry.</param>
        /// <param name="parameterInfo">The parameter information.</param>
        /// <param name="propertyInfo">The property information.</param>
        public ParameterFilterContext(
            ApiParameterDescription apiParameterDescription,
            ISchemaRegistry schemaRegistry,
            ParameterInfo parameterInfo,
            PropertyInfo propertyInfo)
        {
            ApiParameterDescription = apiParameterDescription;
            SchemaRegistry = schemaRegistry;
            ParameterInfo = parameterInfo;
            PropertyInfo = propertyInfo;
        }

        /// <summary>
        /// Gets the API parameter description.
        /// </summary>
        public ApiParameterDescription ApiParameterDescription { get; }

        /// <summary>
        /// Gets the schema registry.
        /// </summary>
        public ISchemaRegistry SchemaRegistry { get; }

        /// <summary>
        /// Gets the parameter information.
        /// </summary>
        public ParameterInfo ParameterInfo { get; }

        /// <summary>
        /// Gets the property information.
        /// </summary>
        public PropertyInfo PropertyInfo { get; }
    }
}