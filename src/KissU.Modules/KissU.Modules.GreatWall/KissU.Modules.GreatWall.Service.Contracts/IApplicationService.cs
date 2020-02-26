using System;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Ioc;
using KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Modules.GreatWall.Application.Dtos;

namespace KissU.Modules.GreatWall.Service.Contracts
{
    /// <summary>
    /// 应用程序服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IApplicationService : IServiceKey
    {
        /// <summary>
        /// 创建应用程序
        /// </summary>
        /// <param name="dto">应用程序参数</param>
        /// <returns>Task&lt;Guid&gt;.</returns>
        Task<Guid> CreateAsync(ApplicationDto dto);

        /// <summary>
        /// 修改应用程序
        /// </summary>
        /// <param name="dto">应用程序参数</param>
        /// <returns>Task.</returns>
        Task UpdateAsync(ApplicationDto dto);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        /// <returns>Task.</returns>
        Task DeleteAsync(string ids);
    }
}