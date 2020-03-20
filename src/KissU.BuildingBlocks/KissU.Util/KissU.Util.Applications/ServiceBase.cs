using KissU.Core.Applications;
using KissU.Core.Logs;
using KissU.Core.Sessions;

namespace KissU.Util.Applications
{
    /// <summary>
    /// 应用服务
    /// </summary>
    public abstract class ServiceBase : IService
    {
        /// <summary>
        /// 日志
        /// </summary>
        private ILog _log;

        /// <summary>
        /// 日志
        /// </summary>
        public ILog Log => _log ??= GetLog();

        /// <summary>
        /// 用户会话
        /// </summary>
        public virtual ISession Session => NullSession.Instance;

        /// <summary>
        /// 获取日志操作
        /// </summary>
        /// <returns>结果</returns>
        protected virtual ILog GetLog()
        {
            try
            {
                return Core.Logs.Log.GetLog(this);
            }
            catch
            {
                return Core.Logs.Log.Null;
            }
        }
    }
}