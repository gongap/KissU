using System.Collections.Generic;

namespace KissU.Surging.CPlatform.Runtime.Server
{
    /// <summary>
    /// 一个抽象的服务条目管理者。
    /// </summary>
    public interface IServiceEntryManager
    {
        /// <summary>
        /// 获取服务条目集合。
        /// </summary>
        /// <returns>服务条目集合。</returns>
        IEnumerable<ServiceEntry> GetEntries();

        /// <summary>
        /// 更新条目.
        /// </summary>
        /// <param name="providers">The providers.</param>
        void UpdateEntries(IEnumerable<IServiceEntryProvider> providers);

        /// <summary>
        /// 获取所有条目.
        /// </summary>
        /// <returns>IEnumerable&lt;ServiceEntry&gt;.</returns>
        IEnumerable<ServiceEntry> GetAllEntries();
    }
}