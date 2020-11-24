namespace KissU.AspNetCore.Swagger.Swagger.Model
{
    /// <summary>
    /// BasicAuthScheme.
    /// Implements the <see cref="SecurityScheme" />
    /// </summary>
    /// <seealso cref="SecurityScheme" />
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