using System;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Util.Applications;
using KissU.Util.Aspects;
using KissU.Util.Validations.Aspects;

namespace KissU.Modules.GreatWall.Application.Abstractions {
    /// <summary>
    /// 身份资源服务
    /// </summary>
    public interface IIdentityResourceService : IService {
        /// <summary>
        /// 创建身份资源
        /// </summary>
        /// <param name="dto">身份资源参数</param>
        Task<Guid> CreateAsync( [NotNull] [Valid] IdentityResourceDto dto );
        /// <summary>
        /// 修改身份资源
        /// </summary>
        /// <param name="dto">身份资源参数</param>
        Task UpdateAsync( [NotNull] [Valid] IdentityResourceDto dto );
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        Task DeleteAsync( string ids );
    }
}