using System;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Contracts.Abstractions;
using KissU.Modules.GreatWall.Application.Contracts.Dtos;
using KissU.Modules.GreatWall.Application.Contracts.Dtos.Requests;
using KissU.Modules.GreatWall.Service.Contracts;
using KissU.Surging.ProxyGenerator;

namespace KissU.Modules.GreatWall.Service.Implements
{
    /// <summary>
    /// 模块服务
    /// </summary>
    public class ModuleService : ProxyServiceBase, IModuleService
    {
        private readonly IModuleAppService _appService;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="appService">应用服务</param>
        /// <exception cref="ArgumentNullException">appService</exception>
        public ModuleService(IModuleAppService appService)
        {
            _appService = appService ?? throw new ArgumentNullException(nameof(appService));
        }

        /// <summary>
        /// 创建模块
        /// </summary>
        /// <param name="request">创建模块参数</param>
        /// <returns>Task&lt;Guid&gt;.</returns>
        public async Task<Guid> CreateAsync(CreateModuleRequest request)
        {
            return await _appService.CreateAsync(request);
        }

        /// <summary>
        /// 修改模块
        /// </summary>
        /// <param name="request">模块参数</param>
        public async Task UpdateAsync(ModuleDto request)
        {
            await _appService.UpdateAsync(request);
        }
    }
}