using System;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Contracts.Abstractions;
using KissU.Modules.GreatWall.Application.Contracts.Dtos;
using KissU.Modules.GreatWall.Service.Contracts;
using KissU.Surging.ProxyGenerator;

namespace KissU.Modules.GreatWall.Service.Implements
{
    /// <summary>
    /// 应用程序服务
    /// </summary>
    public class ApplicationService : ProxyServiceBase, IApplicationService
    {
        private readonly IApplicationAppService _appService;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="appService">应用服务</param>
        /// <exception cref="ArgumentNullException">appService</exception>
        public ApplicationService(IApplicationAppService appService)
        {
            _appService = appService ?? throw new ArgumentNullException(nameof(appService));
        }

        /// <summary>
        /// 创建应用程序
        /// </summary>
        /// <param name="dto">应用程序参数</param>
        /// <returns>Task&lt;Guid&gt;.</returns>
        public async Task<Guid> CreateAsync(ApplicationDto dto)
        {
            return await _appService.CreateAsync(dto);
        }

        /// <summary>
        /// 修改应用程序
        /// </summary>
        /// <param name="dto">应用程序参数</param>
        public async Task UpdateAsync(ApplicationDto dto)
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