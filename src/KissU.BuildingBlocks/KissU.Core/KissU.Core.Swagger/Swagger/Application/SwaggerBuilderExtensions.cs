using System;
using Microsoft.AspNetCore.Builder;

namespace KissU.Core.Swagger.Swagger.Application
{
    /// <summary>
    /// SwaggerBuilderExtensions.
    /// </summary>
    public static class SwaggerBuilderExtensions
    {
        /// <summary>
        /// Uses the swagger.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="setupAction">The setup action.</param>
        /// <returns>IApplicationBuilder.</returns>
        public static IApplicationBuilder UseSwagger(
            this IApplicationBuilder app,
            Action<SwaggerOptions> setupAction = null)
        {
            if (setupAction == null)
            {
                // Don't pass options so it can be configured/injected via DI container instead
                app.UseMiddleware<SwaggerMiddleware>();
            }
            else
            {
                // Configure an options instance here and pass directly to the middleware
                var options = new SwaggerOptions();
                setupAction.Invoke(options);

                app.UseMiddleware<SwaggerMiddleware>(options);
            }

            return app;
        }
    }
}