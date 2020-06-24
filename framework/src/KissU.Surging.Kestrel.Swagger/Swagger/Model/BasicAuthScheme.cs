namespace KissU.Surging.Swagger.Swagger.Model
{
    /// <summary>
    /// BasicAuthScheme.
    /// Implements the <see cref="KissU.Surging.Swagger.Swagger.Model.SecurityScheme" />
    /// </summary>
    /// <seealso cref="KissU.Surging.Swagger.Swagger.Model.SecurityScheme" />
    public class BasicAuthScheme : SecurityScheme
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasicAuthScheme" /> class.
        /// </summary>
        public BasicAuthScheme()
        {
            Type = "basic";
        }
    }
}