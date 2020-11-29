using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace KissU.AspNetCore.Swagger.SwaggerGen.Generator
{
    /// <summary>
    /// ApiParameterDescriptionExtensions.
    /// </summary>
    public static class ApiParameterDescriptionExtensions
    {
        /// <summary>
        /// Tries the get parameter information.
        /// </summary>
        /// <param name="apiParameterDescription">The API parameter description.</param>
        /// <param name="apiDescription">The API description.</param>
        /// <param name="parameterInfo">The parameter information.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        internal static bool TryGetParameterInfo(
            this ApiParameterDescription apiParameterDescription,
            ApiDescription apiDescription,
            out ParameterInfo parameterInfo)
        {
            var controllerParameterDescriptor = apiDescription.ActionDescriptor.Parameters
                .OfType<ControllerParameterDescriptor>()
                .FirstOrDefault(descriptor =>
                {
                    return apiParameterDescription.Name == descriptor.BindingInfo?.BinderModelName
                           || apiParameterDescription.Name == descriptor.Name;
                });

            parameterInfo = controllerParameterDescriptor?.ParameterInfo;

            return parameterInfo != null;
        }

        /// <summary>
        /// Tries the get property information.
        /// </summary>
        /// <param name="apiParameterDescription">The API parameter description.</param>
        /// <param name="propertyInfo">The property information.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        internal static bool TryGetPropertyInfo(
            this ApiParameterDescription apiParameterDescription,
            out PropertyInfo propertyInfo)
        {
            var modelMetadata = apiParameterDescription.ModelMetadata;

            propertyInfo = modelMetadata?.ContainerType != null
                ? modelMetadata.ContainerType.GetProperty(modelMetadata.PropertyName)
                : null;

            return propertyInfo != null;
        }
    }
}