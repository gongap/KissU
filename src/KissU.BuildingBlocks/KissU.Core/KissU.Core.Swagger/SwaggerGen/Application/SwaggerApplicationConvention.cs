using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace KissU.Core.Swagger.SwaggerGen.Application
{
    /// <summary>
    /// SwaggerApplicationConvention.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelConvention" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelConvention" />
    public class SwaggerApplicationConvention : IApplicationModelConvention
    {
        /// <summary>
        /// Applies the specified application.
        /// </summary>
        /// <param name="application">The application.</param>
        public void Apply(ApplicationModel application)
        {
            application.ApiExplorer.IsVisible = true;
        }
    }
}