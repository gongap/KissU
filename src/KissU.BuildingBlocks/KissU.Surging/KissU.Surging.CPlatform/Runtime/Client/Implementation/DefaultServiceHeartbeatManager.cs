using System.Collections.Concurrent;
using System.Linq;

namespace KissU.Surging.CPlatform.Runtime.Client.Implementation
{
    /// <summary>
    /// 默认服务心跳管理器.
    /// Implements the <see cref="IServiceHeartbeatManager" />
    /// </summary>
    /// <seealso cref="IServiceHeartbeatManager" />
    public class DefaultServiceHeartbeatManager : IServiceHeartbeatManager
    {
        private readonly ConcurrentBag<string> _whitelist = new ConcurrentBag<string>();

        /// <summary>
        /// 添加白名单.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        public void AddWhitelist(string serviceId)
        {
            if (!_whitelist.Contains(serviceId))
            {
                _whitelist.Add(serviceId);
            }
        }

        /// <summary>
        /// 是否存在白名单.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ExistsWhitelist(string serviceId)
        {
            return _whitelist.Contains(serviceId);
        }
    }
}