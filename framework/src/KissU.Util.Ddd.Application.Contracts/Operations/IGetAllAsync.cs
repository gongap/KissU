using System.Collections.Generic;
using System.Threading.Tasks;

namespace KissU.Util.Ddd.Application.Contracts.Operations
{
    /// <summary>
    /// 获取全部数据
    /// </summary>
    /// <typeparam name="TDto">The type of the t dto.</typeparam>
    public interface IGetAllAsync<TDto> where TDto : new()
    {
        /// <summary>
        /// 获取全部
        /// </summary>
        /// <returns>Task&lt;List&lt;TDto&gt;&gt;.</returns>
        Task<List<TDto>> GetAllAsync();
    }
}