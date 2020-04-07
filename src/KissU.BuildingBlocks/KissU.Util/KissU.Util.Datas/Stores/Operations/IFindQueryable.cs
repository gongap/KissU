using System;
using System.Linq;
using System.Linq.Expressions;
using KissU.Util.Ddd.Data.Repositories;
using KissU.Util.Ddd.Domain;

namespace KissU.Util.Ddd.Data.Stores.Operations
{
    /// <summary>
    /// 获取查询对象
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    /// <typeparam name="TKey">对象标识类型</typeparam>
    public interface IFindQueryable<TEntity, in TKey> where TEntity : class, IKey<TKey>
    {
        /// <summary>
        /// 获取未跟踪查询对象
        /// </summary>
        /// <returns>IQueryable&lt;TEntity&gt;.</returns>
        IQueryable<TEntity> FindAsNoTracking();

        /// <summary>
        /// 获取查询对象
        /// </summary>
        /// <returns>IQueryable&lt;TEntity&gt;.</returns>
        IQueryable<TEntity> Find();

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="criteria">条件</param>
        /// <returns>IQueryable&lt;TEntity&gt;.</returns>
        IQueryable<TEntity> Find(ICriteria<TEntity> criteria);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <returns>IQueryable&lt;TEntity&gt;.</returns>
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}