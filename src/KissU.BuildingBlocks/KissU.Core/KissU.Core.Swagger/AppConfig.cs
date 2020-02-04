using KissU.Core.Swagger.Swagger.Model;

namespace KissU.Core.Swagger
{
    /// <summary>
    /// AppConfig.
    /// </summary>
    public class AppConfig
    {
        /// <summary>
        /// Gets the swagger options.
        /// </summary>
        public static Info SwaggerOptions { get; internal set; }

        /// <summary>
        /// Gets the swagger configuration.
        /// </summary>
        public static DocumentConfiguration SwaggerConfig { get; internal set; }
    }
}