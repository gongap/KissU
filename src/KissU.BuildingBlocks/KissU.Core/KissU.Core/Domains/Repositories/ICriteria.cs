using System;
using System.Linq.Expressions;

namespace KissU.Core.Domains.Repositories
{
    /// <summary>
    /// 查询条件
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public interface ICriteria<TEntity>
    {
        /// <summary>
        /// 获取查询条件
        /// </summary>
        /// <returns>Expression&lt;Func&lt;TEntity, System.Boolean&gt;&gt;.</returns>
        Expression<Func<TEntity, bool>> GetPredicate();
    }
}