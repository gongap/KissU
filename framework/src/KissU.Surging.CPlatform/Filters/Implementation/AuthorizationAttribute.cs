namespace KissU.Surging.CPlatform.Filters.Implementation
{
    /// <summary>
    /// 授权属性.
    /// Implements the <see cref="AuthorizationFilterAttribute" />
    /// </summary>
    /// <seealso cref="AuthorizationFilterAttribute" />
    public class AuthorizationAttribute : AuthorizationFilterAttribute
    {
        /// <summary>
        /// Gets or sets the type of the authentication.
        /// </summary>
        public AuthorizationType AuthType { get; set; }
    }
}