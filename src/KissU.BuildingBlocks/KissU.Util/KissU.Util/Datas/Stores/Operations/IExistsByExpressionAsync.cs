using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KissU.Util.Domains;

namespace KissU.Util.Datas.Stores.Operations
{
    /// <summary>
    /// 通过表达式判断是否存在
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    /// <typeparam name="TKey">对象标识类型</typeparam>
    public interface IExistsByExpressionAsync<TEntity, in TKey> where TEntity : class, IKey<TKey>
    {
        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
    }
}