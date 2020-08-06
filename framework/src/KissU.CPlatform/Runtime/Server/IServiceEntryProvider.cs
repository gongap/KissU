using System;
using System.Collections.Generic;

namespace KissU.CPlatform.Runtime.Server
{
    /// <summary>
    /// 一个抽象的服务条目提供程序。
    /// </summary>
    public interface IServiceEntryProvider
    {
        /// <summary>
        /// 获取服务条目集合。
        /// </summary>
        /// <returns>服务条目集合。</returns>
        IEnumerable<ServiceEntry> GetEntries();

        /// <summary>
        /// 获取所有条目.
        /// </summary>
        /// <returns>IEnumerable&lt;ServiceEntry&gt;.</returns>
        IEnumerable<ServiceEntry> GetALLEntries();

        /// <summary>
        /// 获取类型.
        /// </summary>
        /// <returns>IEnumerable&lt;Type&gt;.</returns>
        IEnumerable<Type> GetTypes();
    }
}