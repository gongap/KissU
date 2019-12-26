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
    /// 应用程序服务
    /// </summary>
    public class ApplicationService : IApplicationService
    {
        /// <summary>
        /// 创建应用程序
        /// </summary>
        /// <param name="dto">应用程序参数</param>
        public async Task<Guid> CreateAsync(ApplicationDto dto)
        {
            return default;
        }

        /// <summary>
        /// 修改应用程序
        /// </summary>
        /// <param name="dto">应用程序参数</param>
        public async Task UpdateAsync(ApplicationDto dto)
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