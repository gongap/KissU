using System;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Util.Applications;
using KissU.Util.Aspects;
using KissU.Util.Validations.Aspects;

namespace KissU.Modules.GreatWall.Service.Contracts
{
    /// <summary>
    /// Api资源服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IApiResourceService : IService
    {
        /// <summary>
        /// 创建Api资源
        /// </summary>
        /// <param name="dto">Api资源参数</param>
        Task<Guid> CreateAsync(ApiResourceDto dto);

        /// <summary>
        /// 修改Api资源
        /// </summary>
        /// <param name="dto">Api资源参数</param>
        Task UpdateAsync(ApiResourceDto dto);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        Task DeleteAsync(string ids);
    }
}