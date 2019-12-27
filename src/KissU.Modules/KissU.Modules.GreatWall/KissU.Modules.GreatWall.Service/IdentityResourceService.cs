using System;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Modules.GreatWall.Application.Abstractions;
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
        private readonly IIdentityResourceAppService _appService;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="appService">应用服务</param>
        public IdentityResourceService(IIdentityResourceAppService appService)
        {
            _appService = appService ?? throw new ArgumentNullException(nameof(appService));
        }

        /// <summary>
        /// 创建身份资源
        /// </summary>
        /// <param name="dto">身份资源参数</param>
        public async Task<Guid> CreateAsync(IdentityResourceDto dto)
        {
            return await _appService.CreateAsync(dto);
        }

        /// <summary>
        /// 修改身份资源
        /// </summary>
        /// <param name="dto">身份资源参数</param>
        public async Task UpdateAsync(IdentityResourceDto dto)
        {
            await _appService.UpdateAsync(dto);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        public async Task DeleteAsync(string ids)
        {
            await _appService.DeleteAsync(ids);
        }
    }
}