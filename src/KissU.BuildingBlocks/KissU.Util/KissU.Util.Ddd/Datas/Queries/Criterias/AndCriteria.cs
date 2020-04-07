using System;
using System.Linq.Expressions;
using KissU.Core;
using KissU.Util.Ddd.Domain.Domains.Repositories;

namespace KissU.Util.Ddd.Domain.Datas.Queries.Criterias
{
    /// <summary>
    /// 与查询条件
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public class AndCriteria<TEntity> : ICriteria<TEntity> where TEntity : class
    {
        /// <summary>
        /// 初始化查询条件
        /// </summary>
        /// <param name="left">查询条件1</param>
        /// <param name="right">查询条件2</param>
        public AndCriteria(Expression<Func<TEntity, bool>> left, Expression<Func<TEntity, bool>> right)
        {
            Predicate = left.And(right);
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