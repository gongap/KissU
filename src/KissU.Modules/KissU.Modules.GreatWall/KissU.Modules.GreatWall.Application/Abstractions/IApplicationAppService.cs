using System;
using System.Threading.Tasks;
using KissU.Core.Applications;
using KissU.Core.Aspects;
using KissU.Core.Validations.Aspects;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Util.Applications;

namespace KissU.Modules.GreatWall.Application.Abstractions
{
    /// <summary>
    /// 应用程序服务
    /// </summary>
    public interface IApplicationAppService : IService
    {
        /// <summary>
        /// 创建应用程序
        /// </summary>
        /// <param name="dto">应用程序参数</param>
        /// <returns>Task&lt;Guid&gt;.</returns>
        Task<Guid> CreateAsync([NotNull] [Valid] ApplicationDto dto);

        /// <summary>
        /// 修改应用程序
        /// </summary>
        /// <param name="dto">应用程序参数</param>
        /// <returns>Task.</returns>
        Task UpdateAsync([NotNull] [Valid] ApplicationDto dto);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        /// <returns>Task.</returns>
        Task DeleteAsync(string ids);
    }
}