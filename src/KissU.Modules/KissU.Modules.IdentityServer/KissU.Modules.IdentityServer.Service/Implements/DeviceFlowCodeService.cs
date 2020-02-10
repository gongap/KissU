using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.IdentityServer.Application.Abstractions;
using KissU.Modules.IdentityServer.Application.Dtos;
using KissU.Modules.IdentityServer.Application.Queries;
using KissU.Modules.IdentityServer.Service.Contracts;
using KissU.Util.Domains.Repositories;

namespace KissU.Modules.IdentityServer.Service.Implements
{
    /// <summary>
    /// 设备流代码服务
    /// </summary>
    public class DeviceFlowCodeService : IDeviceFlowCodeService
    {
        private readonly IDeviceFlowCodeAppService _appService;

        /// <summary>
        /// 初始化应用服务
        /// </summary>
        /// <param name="appService">应用服务</param>
        public DeviceFlowCodeService(IDeviceFlowCodeAppService appService)
        {
            _appService = appService;
        }

        /// <summary>
        /// 通过编号获取
        /// </summary>
        /// <param name="id">实体编号</param>
        /// <returns>Task&lt;DeviceFlowCodeDto&gt;.</returns>
        public async Task<DeviceFlowCodeDto> GetByIdAsync(int id)
        {
            return await _appService.GetByIdAsync(id);
        }

        /// <summary>
        /// 通过编号列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        /// <returns>Task&lt;List&lt;DeviceFlowCodeDto&gt;&gt;.</returns>
        public async Task<List<DeviceFlowCodeDto>> GetByIdsAsync(string ids)
        {
            return await _appService.GetByIdsAsync(ids);
        }

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <returns>Task&lt;List&lt;DeviceFlowCodeDto&gt;&gt;.</returns>
        public async Task<List<DeviceFlowCodeDto>> GetAllAsync()
        {
            return await _appService.GetAllAsync();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        /// <returns>Task&lt;List&lt;DeviceFlowCodeDto&gt;&gt;.</returns>
        public async Task<List<DeviceFlowCodeDto>> QueryAsync(DeviceFlowCodeQuery parameter)
        {
            return await _appService.QueryAsync(parameter);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        /// <returns>Task&lt;PagerList&lt;DeviceFlowCodeDto&gt;&gt;.</returns>
        public async Task<PagerList<DeviceFlowCodeDto>> PagerQueryAsync(DeviceFlowCodeQuery parameter)
        {
            return await _appService.PagerQueryAsync(parameter);
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