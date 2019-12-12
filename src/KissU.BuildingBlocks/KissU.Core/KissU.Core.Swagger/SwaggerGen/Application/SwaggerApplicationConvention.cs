using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace KissU.Core.Swagger.SwaggerGen.Application
{
    public class SwaggerApplicationConvention : IApplicationModelConvention
    {
        public void Apply(ApplicationModel application)
        {
            application.ApiExplorer.IsVisible = true;
        }
    }
}