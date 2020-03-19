using System.Collections.Generic;

namespace KissU.Util.Applications.Operations
{
    /// <summary>
    /// 获取指定标识实体
    /// </summary>
    /// <typeparam name="TDto">The type of the t dto.</typeparam>
    public interface IGetById<TDto> where TDto : new()
    {
        /// <summary>
        /// 通过标识获取
        /// </summary>
        /// <param name="id">实体编号</param>
        /// <returns>TDto.</returns>
        TDto GetById(object id);

        /// <summary>
        /// 通过标识列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        /// <returns>List&lt;TDto&gt;.</returns>
        List<TDto> GetByIds(string ids);
    }
}