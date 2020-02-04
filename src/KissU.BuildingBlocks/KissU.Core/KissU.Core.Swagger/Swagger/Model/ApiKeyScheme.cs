namespace KissU.Core.Swagger.Swagger.Model
{
    /// <summary>
    /// ApiKeyScheme.
    /// Implements the <see cref="KissU.Core.Swagger.Swagger.Model.SecurityScheme" />
    /// </summary>
    /// <seealso cref="KissU.Core.Swagger.Swagger.Model.SecurityScheme" />
    public class ApiKeyScheme : SecurityScheme
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiKeyScheme" /> class.
        /// </summary>
        public ApiKeyScheme()
        {
            Type = "apiKey";
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the in.
        /// </summary>
        public string In { get; set; }
    }
}