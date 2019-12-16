using System;
using KissU.Util.Domains;

namespace KissU.Util.Datas.Persistence
{
    /// <summary>
    /// 持久化对象
    /// </summary>
    public abstract class PersistentObjectBase : PersistentObjectBase<Guid>
    {
    }

    /// <summary>
    /// 持久化对象
    /// </summary>
    /// <typeparam name="TKey">标识类型</typeparam>
    public abstract class PersistentObjectBase<TKey> : PersistentEntityBase<TKey>, IVersion
    {
        /// <summary>
        /// 版本号
        /// </summary>
        public byte[] Version { get; set; }
    }
}
