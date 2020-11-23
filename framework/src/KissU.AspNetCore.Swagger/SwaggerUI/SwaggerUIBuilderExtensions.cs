using System;
using Microsoft.AspNetCore.Builder;

namespace KissU.Kestrel.Swagger.SwaggerUI
{
    /// <summary>
    /// SwaggerUIBuilderExtensions.
    /// </summary>
    public static class SwaggerUIBuilderExtensions
    {
        /// <summary>
        /// Uses the swagger UI.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="setupAction">The setup action.</param>
        /// <returns>IApplicationBuilder.</returns>
        public static IApplicationBuilder UseSwaggerUI(
            this IApplicationBuilder app,
            Action<SwaggerUIOptions> setupAction = null)
        {
            if (setupAction == null)
            {
                // Don't pass options so it can be configured/injected via DI container instead
                app.UseMiddleware<SwaggerUIMiddleware>();
            }
            else
            {
                // Configure an options instance here and pass directly to the middleware
                var options = new SwaggerUIOptions();
                setupAction.Invoke(options);

                app.UseMiddleware<SwaggerUIMiddleware>(options);
            }

            return app;
        }
    }
}