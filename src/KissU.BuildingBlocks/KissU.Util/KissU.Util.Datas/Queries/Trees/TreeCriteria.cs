using System;
using System.Linq.Expressions;
using KissU.Core;
using KissU.Core.Datas.Queries.Trees;
using KissU.Util.Ddd.Data.Repositories;
using KissU.Util.Ddd.Domain.Trees;

namespace KissU.Util.Ddd.Data.Queries.Trees
{
    /// <summary>
    /// 树形查询条件
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    public class TreeCriteria<TEntity> : TreeCriteria<TEntity, Guid?> where TEntity : IPath, IEnabled, IParentId<Guid?>
    {
        /// <summary>
        /// 初始化树形查询条件
        /// </summary>
        /// <param name="parameter">查询参数</param>
        public TreeCriteria(ITreeQueryParameter parameter) : base(parameter)
        {
            if (parameter.ParentId != null)
                Predicate = Predicate.And(t => t.ParentId == parameter.ParentId);
        }
    }

    /// <summary>
    /// 树形查询条件
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <typeparam name="TParentId">The type of the t parent identifier.</typeparam>
    public class TreeCriteria<TEntity, TParentId> : ICriteria<TEntity> where TEntity : IPath, IEnabled
    {
        /// <summary>
        /// 初始化树形查询条件
        /// </summary>
        /// <param name="parameter">查询参数</param>
        public TreeCriteria(ITreeQueryParameter<TParentId> parameter)
        {
            if (!string.IsNullOrWhiteSpace(parameter.Path))
                Predicate = Predicate.And(t => t.Path.StartsWith(parameter.Path));
            if (parameter.Level != null)
                Predicate = Predicate.And(t => t.Level == parameter.Level);
            if (parameter.Enabled != null)
                Predicate = Predicate.And(t => t.Enabled == parameter.Enabled);
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        protected Expression<Func<TEntity, bool>> Predicate { get; set; }

        /// <summary>
        /// 获取查询条件
        /// </summary>
        /// <returns>Expression&lt;Func&lt;TEntity, System.Boolean&gt;&gt;.</returns>
        public Expression<Func<TEntity, bool>> GetPredicate()
        {
            return Predicate;
        }
    }
}