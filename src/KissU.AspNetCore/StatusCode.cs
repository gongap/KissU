namespace KissU.AspNetCore
{
    /// <summary>
    /// Enum StatusCode
    /// </summary>
    public enum StatusCode
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
        Unauthorized = 401,

        /// <summary>
        /// The authorization failed
        /// </summary>
        Forbidden = 403,

        /// <summary>
        /// HTTP Method Not Supported
        /// </summary>
        MethodNotSupported = 405,

        /// <summary>
        /// The Internal Server Error
        /// </summary>
        ServerError = 500
    }
}