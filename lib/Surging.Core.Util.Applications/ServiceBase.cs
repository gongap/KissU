using Surging.Core.ProxyGenerator;
using Util.Logs;
using Util.Sessions;

namespace KissU.Applications {
    /// <summary>
    /// 应用服务
    /// </summary>
    public abstract class ServiceBase : ProxyServiceBase, IService
    {
        /// <summary>
        /// 日志
        /// </summary>
        private ILog _log;

        /// <summary>
        /// 日志
        /// </summary>
        public ILog Log => _log ?? (_log = GetLog() );

        /// <summary>
        /// 获取日志操作
        /// </summary>
        protected virtual ILog GetLog() {
            try {
                return Util.Logs.Log.GetLog( this );
            }
            catch {
                return Util.Logs.Log.Null;
            }
        }

        /// <summary>
        /// 用户会话
        /// </summary>
        public virtual ISession Session => Util.Security.Sessions.Session.Instance;
    }
}
