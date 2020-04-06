using System.Collections.Generic;
using System.Threading.Tasks;

namespace KissU.Util.Ddd.Applications.Operations
{
    /// <summary>
    /// 获取指定标识实体
    /// </summary>
    /// <typeparam name="TDto">The type of the t dto.</typeparam>
    public interface IGetByIdAsync<TDto> where TDto : new()
    {
        /// <summary>
        /// 通过标识获取
        /// </summary>
        /// <param name="id">实体编号</param>
        /// <returns>Task&lt;TDto&gt;.</returns>
        Task<TDto> GetByIdAsync(object id);

        /// <summary>
        /// 通过标识列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        /// <returns>Task&lt;List&lt;TDto&gt;&gt;.</returns>
        Task<List<TDto>> GetByIdsAsync(string ids);
    }
}