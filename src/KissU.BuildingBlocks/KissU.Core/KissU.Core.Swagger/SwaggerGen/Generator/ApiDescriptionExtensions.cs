using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace KissU.Core.Swagger.SwaggerGen.Generator
{
    /// <summary>
    /// ApiDescriptionExtensions.
    /// </summary>
    public static class ApiDescriptionExtensions
    {
        /// <summary>
        /// Controllers the attributes.
        /// </summary>
        /// <param name="apiDescription">The API description.</param>
        /// <returns>IEnumerable&lt;System.Object&gt;.</returns>
        [Obsolete("Deprecated: Use TryGetMethodInfo")]
        public static IEnumerable<object> ControllerAttributes(this ApiDescription apiDescription)
        {
            var controllerActionDescriptor = apiDescription.ActionDescriptor as ControllerActionDescriptor;
            return (controllerActionDescriptor == null)
                ? Enumerable.Empty<object>()
                : controllerActionDescriptor.ControllerTypeInfo.GetCustomAttributes(true);
        }

        /// <summary>
        /// Actions the attributes.
        /// </summary>
        /// <param name="apiDescription">The API description.</param>
        /// <returns>IEnumerable&lt;System.Object&gt;.</returns>
        [Obsolete("Deprecated: Use TryGetMethodInfo")]
        public static IEnumerable<object> ActionAttributes(this ApiDescription apiDescription)
        {
            var controllerActionDescriptor = apiDescription.ActionDescriptor as ControllerActionDescriptor;
            return (controllerActionDescriptor == null)
                ? Enumerable.Empty<object>()
                : controllerActionDescriptor.MethodInfo.GetCustomAttributes(true);
        }

        /// <summary>
        /// Tries the get method information.
        /// </summary>
        /// <param name="apiDescription">The API description.</param>
        /// <param name="methodInfo">The method information.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool TryGetMethodInfo(this ApiDescription apiDescription, out MethodInfo methodInfo)
        {
            var controllerActionDescriptor = apiDescription.ActionDescriptor as ControllerActionDescriptor;

            methodInfo = controllerActionDescriptor?.MethodInfo;

            return (methodInfo != null);
        }

        /// <summary>
        /// Relatives the path sans query string.
        /// </summary>
        /// <param name="apiDescription">The API description.</param>
        /// <returns>System.String.</returns>
        internal static string RelativePathSansQueryString(this ApiDescription apiDescription)
        {
            return apiDescription.RelativePath.Split('?').First();
        }

        /// <summary>
        /// Determines whether the specified API description is obsolete.
        /// </summary>
        /// <param name="apiDescription">The API description.</param>
        /// <returns><c>true</c> if the specified API description is obsolete; otherwise, <c>false</c>.</returns>
        internal static bool IsObsolete(this ApiDescription apiDescription)
        {
            if (!apiDescription.TryGetMethodInfo(out MethodInfo methodInfo))
                return false;

            return methodInfo.GetCustomAttributes(true)
                .Union(methodInfo.DeclaringType.GetTypeInfo().GetCustomAttributes(true))
                .Any(attr => attr.GetType() == typeof(ObsoleteAttribute));
        }
    }
}
