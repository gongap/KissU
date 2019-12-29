using System;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Abstractions;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Modules.GreatWall.Service.Contracts;

namespace KissU.Modules.GreatWall.Service.Implements
{
    /// <summary>
    /// Api资源服务
    /// </summary>
    public class ApiResourceService : IApiResourceService
    {
        private readonly IApiResourceAppService _appService;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="appService">应用服务</param>
        public ApiResourceService(IApiResourceAppService appService)
        {
            _appService = appService ?? throw new ArgumentNullException(nameof(appService));
        }

        /// <summary>
        /// 创建Api资源
        /// </summary>
        /// <param name="dto">Api资源参数</param>
        public async Task<Guid> CreateAsync(ApiResourceDto dto)
        {
            return await _appService.CreateAsync(dto);
        }

        /// <summary>
        /// 修改Api资源
        /// </summary>
        /// <param name="dto">Api资源参数</param>
        public async Task UpdateAsync(ApiResourceDto dto)
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