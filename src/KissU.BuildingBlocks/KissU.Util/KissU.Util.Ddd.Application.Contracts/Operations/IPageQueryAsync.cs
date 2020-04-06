using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Util.Ddd.Datas.Queries;
using KissU.Util.Ddd.Domains.Repositories;

namespace KissU.Util.Ddd.Applications.Operations
{
    /// <summary>
    /// 分页查询
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQueryParameter">查询参数类型</typeparam>
    public interface IPageQueryAsync<TDto, in TQueryParameter>
        where TDto : new()
        where TQueryParameter : IQueryParameter
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        /// <returns>Task&lt;List&lt;TDto&gt;&gt;.</returns>
        Task<List<TDto>> QueryAsync(TQueryParameter parameter);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        /// <returns>Task&lt;PagerList&lt;TDto&gt;&gt;.</returns>
        Task<PagerList<TDto>> PagerQueryAsync(TQueryParameter parameter);
    }
}