namespace KissU.Surging.CPlatform.Diagnostics
{
    /// <summary>
    /// 组件.
    /// </summary>
    public static class Components
    {
        /// <summary>
        /// RPC传输
        /// </summary>
        public static readonly StringOrIntValue RpcTransport = new StringOrIntValue("RPCTransport");

        /// <summary>
        /// 缓存拦截
        /// </summary>
        public static readonly StringOrIntValue CacheIntercept = new StringOrIntValue("CacheIntercept");

        /// <summary>
        /// 拦截
        /// </summary>
        public static readonly StringOrIntValue Intercept = new StringOrIntValue("Intercept");
    }
}