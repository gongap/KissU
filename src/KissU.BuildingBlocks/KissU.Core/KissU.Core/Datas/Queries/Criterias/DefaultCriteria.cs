using System;
using System.Linq.Expressions;
using KissU.Core.Domains.Repositories;

namespace KissU.Core.Datas.Queries.Criterias
{
    /// <summary>
    /// 默认查询条件
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public class DefaultCriteria<TEntity> : ICriteria<TEntity> where TEntity : class
    {
        /// <summary>
        /// 初始化查询条件
        /// </summary>
        /// <param name="predicate">查询条件</param>
        public DefaultCriteria(Expression<Func<TEntity, bool>> predicate)
        {
            Predicate = predicate;
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        protected Expression<Func<TEntity, bool>> Predicate { get; set; }

        /// <summary>
        /// 获取查询条件
        /// </summary>
        /// <returns>Expression&lt;Func&lt;TEntity, System.Boolean&gt;&gt;.</returns>
        public virtual Expression<Func<TEntity, bool>> GetPredicate()
        {
            return Predicate;
        }
    }
}