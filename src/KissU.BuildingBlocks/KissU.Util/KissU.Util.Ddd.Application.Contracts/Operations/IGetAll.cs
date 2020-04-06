using System.Collections.Generic;

namespace KissU.Util.Ddd.Applications.Operations
{
    /// <summary>
    /// 获取全部数据
    /// </summary>
    /// <typeparam name="TDto">The type of the t dto.</typeparam>
    public interface IGetAll<TDto> where TDto : new()
    {
        /// <summary>
        /// 获取全部
        /// </summary>
        /// <returns>List&lt;TDto&gt;.</returns>
        List<TDto> GetAll();
    }
}