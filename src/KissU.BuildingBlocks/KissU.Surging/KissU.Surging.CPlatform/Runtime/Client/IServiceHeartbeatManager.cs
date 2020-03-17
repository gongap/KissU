namespace KissU.Surging.CPlatform.Runtime.Client
{
    /// <summary>
    /// 服务心跳管理器
    /// </summary>
    public interface IServiceHeartbeatManager
    {
        /// <summary>
        /// 添加白名单.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        void AddWhitelist(string serviceId);

        /// <summary>
        /// 是否存在白名单.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool ExistsWhitelist(string serviceId);
    }
}