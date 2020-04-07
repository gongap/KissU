using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Contracts.Abstractions;
using KissU.Modules.GreatWall.Application.Contracts.Dtos;
using KissU.Modules.GreatWall.Application.Contracts.Dtos.Requests;
using KissU.Modules.GreatWall.Application.Contracts.Queries;
using KissU.Modules.GreatWall.Service.Contracts;
using KissU.Surging.ProxyGenerator;
using KissU.Util.Ddd.Domains.Repositories;

namespace KissU.Modules.GreatWall.Service.Implements
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public class UserService : ProxyServiceBase, IUserService
    {
        private readonly IUserAppService _appService;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="appService">应用服务</param>
        /// <exception cref="ArgumentNullException">appService</exception>
        public UserService(IUserAppService appService)
        {
            _appService = appService ?? throw new ArgumentNullException(nameof(appService));
        }

        /// <summary>
        /// 通过标识获取
        /// </summary>
        /// <param name="id">实体编号</param>
        /// <returns>Task&lt;UserDto&gt;.</returns>
        public async Task<UserDto> GetByIdAsync(string id)
        {
            return await _appService.GetByIdAsync(id);
        }

        /// <summary>
        /// 通过标识列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        /// <returns>Task&lt;List&lt;UserDto&gt;&gt;.</returns>
        public async Task<List<UserDto>> GetByIdsAsync(string ids)
        {
            return await _appService.GetByIdsAsync(ids);
        }

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <returns>Task&lt;List&lt;UserDto&gt;&gt;.</returns>
        public async Task<List<UserDto>> GetAllAsync()
        {
            return await _appService.GetAllAsync();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        /// <returns>Task&lt;List&lt;UserDto&gt;&gt;.</returns>
        public async Task<List<UserDto>> QueryAsync(UserQuery parameter)
        {
            return await _appService.QueryAsync(parameter);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        /// <returns>Task&lt;PagerList&lt;UserDto&gt;&gt;.</returns>
        public async Task<PagerList<UserDto>> PagerQueryAsync(UserQuery parameter)
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

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="request">创建用户参数</param>
        /// <returns>Task&lt;Guid&gt;.</returns>
        public async Task<Guid> CreateAsync(CreateUserRequest request)
        {
            return await _appService.CreateAsync(request);
        }
    }
}