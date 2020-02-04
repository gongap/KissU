namespace KissU.Core.Swagger.Swagger.Model
{
    /// <summary>
    /// BasicAuthScheme.
    /// Implements the <see cref="KissU.Core.Swagger.Swagger.Model.SecurityScheme" />
    /// </summary>
    /// <seealso cref="KissU.Core.Swagger.Swagger.Model.SecurityScheme" />
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