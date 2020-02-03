namespace KissU.Core.CPlatform.Diagnostics
{
    /// <summary>
    /// Enum SpanLayer
    /// </summary>
    public enum SpanLayer
    {
        /// <summary>
        /// The database
        /// </summary>
        DB = 1,

        /// <summary>
        /// The RPC framework
        /// </summary>
        RPC_FRAMEWORK = 2,

        /// <summary>
        /// The HTTP
        /// </summary>
        HTTP = 3,

        /// <summary>
        /// The mq
        /// </summary>
        MQ = 4,

        /// <summary>
        /// The cache
        /// </summary>
        CACHE = 5,
    }
}