using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.Datas;
using KissU.Util.Ddd.Domain.Datas.Repositories;

namespace KissU.Util.Ddd.Domain.Datas.Stores.Operations
{
    /// <summary>
    /// 分页查询
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    /// <typeparam name="TKey">对象标识类型</typeparam>
    public interface IPageQueryAsync<TEntity, in TKey> where TEntity : class, IKey<TKey>
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>Task&lt;List&lt;TEntity&gt;&gt;.</returns>
        Task<List<TEntity>> QueryAsync(IQueryBase<TEntity> query);

        /// <summary>
        /// 查询，不跟踪实体
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>Task&lt;List&lt;TEntity&gt;&gt;.</returns>
        Task<List<TEntity>> QueryAsNoTrackingAsync(IQueryBase<TEntity> query);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>Task&lt;PagerList&lt;TEntity&gt;&gt;.</returns>
        Task<PagerList<TEntity>> PagerQueryAsync(IQueryBase<TEntity> query);

        /// <summary>
        /// 分页查询，不跟踪实体
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>Task&lt;PagerList&lt;TEntity&gt;&gt;.</returns>
        Task<PagerList<TEntity>> PagerQueryAsNoTrackingAsync(IQueryBase<TEntity> query);
    }
}