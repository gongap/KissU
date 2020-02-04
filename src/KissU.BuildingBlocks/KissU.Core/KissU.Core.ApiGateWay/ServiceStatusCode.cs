namespace KissU.Core.ApiGateWay
{
    /// <summary>
    /// Enum ServiceStatusCode
    /// </summary>
    public enum ServiceStatusCode
    {
        /// <summary>
        /// The success
        /// </summary>
        Success = 200,

        /// <summary>
        /// The request error
        /// </summary>
        RequestError = 400,

        /// <summary>
        /// The authorization failed
        /// </summary>
        AuthorizationFailed = 401,

        /// <summary>
        /// The HTTP405 endpoint
        /// </summary>
        Http405Endpoint = 405
    }
}