using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.Datas;
using KissU.Modules.IdentityServer.Application.Contracts.Abstractions;
using KissU.Modules.IdentityServer.Application.Contracts.Dtos;
using KissU.Modules.IdentityServer.Application.Contracts.Queries;
using KissU.Modules.IdentityServer.Service.Contracts;
using KissU.Surging.ProxyGenerator;

namespace KissU.Modules.IdentityServer.Service.Implements
{
    /// <summary>
    /// 认证操作数据服务
    /// </summary>
    public class PersistedGrantService : ProxyServiceBase, IPersistedGrantService
    {
        private readonly IPersistedGrantAppService _appService;

        /// <summary>
        /// 初始化应用服务
        /// </summary>
        /// <param name="appService">应用服务</param>
        public PersistedGrantService(IPersistedGrantAppService appService)
        {
            _appService = appService;
        }

        /// <summary>
        /// 通过标识获取
        /// </summary>
        /// <param name="id">实体编号</param>
        /// <returns>Task&lt;PersistedGrantDto&gt;.</returns>
        public async Task<PersistedGrantDto> GetByIdAsync(int id)
        {
            return await _appService.GetByIdAsync(id);
        }

        /// <summary>
        /// 通过标识列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        /// <returns>Task&lt;List&lt;PersistedGrantDto&gt;&gt;.</returns>
        public async Task<List<PersistedGrantDto>> GetByIdsAsync(string ids)
        {
            return await _appService.GetByIdsAsync(ids);
        }

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <returns>Task&lt;List&lt;PersistedGrantDto&gt;&gt;.</returns>
        public async Task<List<PersistedGrantDto>> GetAllAsync()
        {
            return await _appService.GetAllAsync();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        /// <returns>Task&lt;List&lt;PersistedGrantDto&gt;&gt;.</returns>
        public async Task<List<PersistedGrantDto>> QueryAsync(PersistedGrantQuery parameter)
        {
            return await _appService.QueryAsync(parameter);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        /// <returns>Task&lt;PagerList&lt;PersistedGrantDto&gt;&gt;.</returns>
        public async Task<PagerList<PersistedGrantDto>> PagerQueryAsync(PersistedGrantQuery parameter)
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