using System;
using System.Collections.Generic;
using KissU.AspNetCore.Swagger.Swagger.Model;
using Microsoft.AspNetCore.Http;

namespace KissU.AspNetCore.Swagger.Swagger.Application
{
    /// <summary>
    /// SwaggerOptions.
    /// </summary>
    public class SwaggerOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwaggerOptions" /> class.
        /// </summary>
        public SwaggerOptions()
        {
            PreSerializeFilters = new List<Action<SwaggerDocument, HttpRequest>>();
        }

        /// <summary>
        /// Sets a custom route for the Swagger JSON endpoint(s). Must include the {documentName} parameter
        /// </summary>
        public string RouteTemplate { get; set; } = "swagger/{documentName}/swagger.json";

        /// <summary>
        /// Actions that can be applied SwaggerDocument's before they're serialized to JSON.
        /// Useful for setting metadata that's derived from the current request
        /// </summary>
        public List<Action<SwaggerDocument, HttpRequest>> PreSerializeFilters { get; }
    }
}