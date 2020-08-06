using KissU.Kestrel.Swagger.Swagger.Model;

namespace KissU.Kestrel.Swagger
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