using KissU.Util.Ddd.Domain;

namespace KissU.Util.Ddd.Data.Stores.Operations
{
    /// <summary>
    /// 通过标识判断是否存在
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    /// <typeparam name="TKey">对象标识类型</typeparam>
    public interface IExists<TEntity, in TKey> where TEntity : class, IKey<TKey>
    {
        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="ids">标识列表</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool Exists(params TKey[] ids);
    }
}