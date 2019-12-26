using System;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Util.Applications;
using KissU.Util.Aspects;
using KissU.Util.Validations.Aspects;

namespace KissU.Modules.GreatWall.Service.Contracts {
    /// <summary>
    /// 身份资源服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IIdentityResourceService : IService {
        /// <summary>
        /// 创建身份资源
        /// </summary>
        /// <param name="dto">身份资源参数</param>
        Task<Guid> CreateAsync(IdentityResourceDto dto );
        /// <summary>
        /// 修改身份资源
        /// </summary>
        /// <param name="dto">身份资源参数</param>
        Task UpdateAsync(IdentityResourceDto dto );
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        Task DeleteAsync( string ids );
    }
}