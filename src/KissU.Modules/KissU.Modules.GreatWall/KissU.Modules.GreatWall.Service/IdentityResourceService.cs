using System;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Modules.GreatWall.Service.Contracts;
using KissU.Util.Applications;
using KissU.Util.Aspects;
using KissU.Util.Validations.Aspects;

namespace KissU.Modules.GreatWall.Service {
    /// <summary>
    /// 身份资源服务
    /// </summary>
    public class IdentityResourceService : IIdentityResourceService
    {
        /// <summary>
        /// 创建身份资源
        /// </summary>
        /// <param name="dto">身份资源参数</param>
        public async Task<Guid> CreateAsync(IdentityResourceDto dto)
        {
            return default;
        }

        /// <summary>
        /// 修改身份资源
        /// </summary>
        /// <param name="dto">身份资源参数</param>
        public async Task UpdateAsync(IdentityResourceDto dto)
        {
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        public async Task DeleteAsync(string ids)
        {
        }
    }
}