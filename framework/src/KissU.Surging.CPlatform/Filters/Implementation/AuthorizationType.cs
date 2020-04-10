namespace KissU.Surging.CPlatform.Filters.Implementation
{
    /// <summary>
    /// 授权类型
    /// </summary>
    public enum AuthorizationType
    {
        /// <summary>
        /// The JWT
        /// </summary>
        JWT,

        /// <summary>
        /// The application secret
        /// </summary>
        AppSecret,

        /// <summary>
        /// The JWT bearer
        /// </summary>
        JWTBearer
    }
}