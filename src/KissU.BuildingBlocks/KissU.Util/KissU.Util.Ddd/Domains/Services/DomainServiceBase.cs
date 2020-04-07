using KissU.Core.Logs;
using KissU.Core.Logs.Core;

namespace KissU.Util.Ddd.Domain.Domains.Services
{
    /// <summary>
    /// 领域服务
    /// </summary>
    public abstract class DomainServiceBase : IDomainService
    {
        /// <summary>
        /// 初始化领域服务
        /// </summary>
        protected DomainServiceBase()
        {
            Log = NullLog.Instance;
        }

        /// <summary>
        /// 日志
        /// </summary>
        public ILog Log { get; set; }
    }
}