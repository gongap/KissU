using System.IO;
using System.Text;
using System.Threading.Tasks;
using KissU.AspNetCore.Swagger.Swagger.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace KissU.AspNetCore.Swagger.Swagger.Application
{
    /// <summary>
    /// SwaggerMiddleware.
    /// </summary>
    public class SwaggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly SwaggerOptions _options;
        private readonly TemplateMatcher _requestMatcher;
        private readonly JsonSerializer _swaggerSerializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="SwaggerMiddleware" /> class.
        /// </summary>
        /// <param name="next">The next.</param>
        /// <param name="mvcJsonOptionsAccessor">The MVC json options accessor.</param>
        /// <param name="optionsAccessor">The options accessor.</param>
        public SwaggerMiddleware(
            RequestDelegate next,
            IOptions<MvcNewtonsoftJsonOptions> mvcJsonOptionsAccessor,
            IOptions<SwaggerOptions> optionsAccessor)
            : this(next, mvcJsonOptionsAccessor, optionsAccessor.Value)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SwaggerMiddleware" /> class.
        /// </summary>
        /// <param name="next">The next.</param>
        /// <param name="mvcJsonOptions">The MVC json options.</param>
        /// <param name="options">The options.</param>
        public SwaggerMiddleware(
            RequestDelegate next,
            IOptions<MvcNewtonsoftJsonOptions> mvcJsonOptions,
            SwaggerOptions options)
        {
            _next = next;
            _swaggerSerializer = SwaggerSerializerFactory.Create(mvcJsonOptions);
            _options = options ?? new SwaggerOptions();
            _requestMatcher =
                new TemplateMatcher(TemplateParser.Parse(options.RouteTemplate), new RouteValueDictionary());
        }

        /// <summary>
        /// Invokes the specified HTTP context.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <param name="swaggerProvider">The swagger provider.</param>
        public async Task Invoke(HttpContext httpContext, ISwaggerProvider swaggerProvider)
        {
            if (!RequestingSwaggerDocument(httpContext.Request, out var documentName))
            {
                await _next(httpContext);
                return;
            }

            var basePath = string.IsNullOrEmpty(httpContext.Request.PathBase)
                ? null
                : httpContext.Request.PathBase.ToString();

            try
            {
                var swagger = swaggerProvider.GetSwagger(documentName, null, basePath);

                // One last opportunity to modify the Swagger Document - this time with request context
                foreach (var filter in _options.PreSerializeFilters)
                {
                    filter(swagger, httpContext.Request);
                }

                await RespondWithSwaggerJson(httpContext.Response, swagger);
            }
            catch (UnknownSwaggerDocument)
            {
                RespondWithNotFound(httpContext.Response);
            }
        }

        private bool RequestingSwaggerDocument(HttpRequest request, out string documentName)
        {
            documentName = null;
            if (request.Method != "GET") return false;

            var routeValues = new RouteValueDictionary();
            if (!_requestMatcher.TryMatch(request.Path, routeValues) ||
                !routeValues.ContainsKey("documentName")) return false;

            documentName = routeValues["documentName"].ToString();
            return true;
        }

        private void RespondWithNotFound(HttpResponse response)
        {
            response.StatusCode = 404;
        }

        private async Task RespondWithSwaggerJson(HttpResponse response, SwaggerDocument swagger)
        {
            response.StatusCode = 200;
            response.ContentType = "application/json;charset=utf-8";

            var jsonBuilder = new StringBuilder();
            using (var writer = new StringWriter(jsonBuilder))
            {
                _swaggerSerializer.Serialize(writer, swagger);
                await response.WriteAsync(jsonBuilder.ToString(), new UTF8Encoding(false));
            }
        }
    }
}