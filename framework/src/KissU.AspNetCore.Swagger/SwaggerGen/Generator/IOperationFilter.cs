using System.Reflection;
using KissU.AspNetCore.Swagger.Swagger.Model;
using KissU.CPlatform.Runtime.Server;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace KissU.AspNetCore.Swagger.SwaggerGen.Generator
{
    /// <summary>
    /// Interface IOperationFilter
    /// </summary>
    public interface IOperationFilter
    {
        /// <summary>
        /// Applies the specified operation.
        /// </summary>
        /// <param name="operation">The operation.</param>
        /// <param name="context">The context.</param>
        void Apply(Operation operation, OperationFilterContext context);
    }

    /// <summary>
    /// OperationFilterContext.
    /// </summary>
    public class OperationFilterContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OperationFilterContext" /> class.
        /// </summary>
        /// <param name="apiDescription">The API description.</param>
        /// <param name="schemaRegistry">The schema registry.</param>
        /// <param name="methodInfo">The method information.</param>
        public OperationFilterContext(
            ApiDescription apiDescription,
            ISchemaRegistry schemaRegistry,
            MethodInfo methodInfo) : this(apiDescription, schemaRegistry, methodInfo, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationFilterContext" /> class.
        /// </summary>
        /// <param name="apiDescription">The API description.</param>
        /// <param name="schemaRegistry">The schema registry.</param>
        /// <param name="methodInfo">The method information.</param>
        /// <param name="serviceEntry">The service entry.</param>
        public OperationFilterContext(
            ApiDescription apiDescription,
            ISchemaRegistry schemaRegistry,
            MethodInfo methodInfo, ServiceEntry serviceEntry)
        {
            ApiDescription = apiDescription;
            SchemaRegistry = schemaRegistry;
            MethodInfo = methodInfo;
            ServiceEntry = serviceEntry;
        }

        /// <summary>
        /// Gets or sets the service entry.
        /// </summary>
        public ServiceEntry ServiceEntry { get; set; }

        /// <summary>
        /// Gets the API description.
        /// </summary>
        public ApiDescription ApiDescription { get; }

        /// <summary>
        /// Gets the schema registry.
        /// </summary>
        public ISchemaRegistry SchemaRegistry { get; }

        /// <summary>
        /// Gets the method information.
        /// </summary>
        public MethodInfo MethodInfo { get; }
    }
}