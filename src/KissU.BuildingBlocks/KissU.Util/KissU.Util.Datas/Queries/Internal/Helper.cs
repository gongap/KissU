using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using KissU.Core;
using KissU.Core.Datas;
using KissU.Core.Helpers;
using KissU.Core.Properties;

namespace KissU.Util.Ddd.Data.Queries.Internal
{
    /// <summary>
    /// 查询工具类
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// 获取查询条件表达式
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <param name="predicate">
        /// 查询条件,如果参数值为空，则忽略该查询条件，范例：t =&gt; t.Name == ""，该查询条件被忽略。
        /// 注意：一次仅能添加一个条件，范例：t =&gt; t.Name == "a" &amp;&amp; t.Mobile == "123"，不支持，将抛出异常
        /// </param>
        /// <returns>Expression&lt;Func&lt;TEntity, System.Boolean&gt;&gt;.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static Expression<Func<TEntity, bool>> GetWhereIfNotEmptyExpression<TEntity>(
            Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            if (predicate == null)
                return null;
            if (Lambda.GetConditionCount(predicate) > 1)
                throw new InvalidOperationException(string.Format(LibraryResource.OnlyOnePredicate, predicate));
            var value = predicate.Value();
            if (string.IsNullOrWhiteSpace(value.SafeString()))
                return null;
            return predicate;
        }

        /// <summary>
        /// 初始化排序
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="pager">The pager.</param>
        public static void InitOrder<TEntity>(IQueryable<TEntity> source, IPager pager)
        {
            if (string.IsNullOrWhiteSpace(pager.Order) == false)
                return;
            if (source.Expression.SafeString().Contains(".OrderBy("))
                return;
            pager.Order = "Id";
        }

        /// <summary>
        /// 获取排序查询对象
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="pager">The pager.</param>
        /// <returns>IOrderedQueryable&lt;TEntity&gt;.</returns>
        public static IOrderedQueryable<TEntity> GetOrderedQueryable<TEntity>(IQueryable<TEntity> source, IPager pager)
        {
            if (string.IsNullOrWhiteSpace(pager.Order))
                return source as IOrderedQueryable<TEntity>;
            return source.OrderBy(pager.Order);
        }
    }
}