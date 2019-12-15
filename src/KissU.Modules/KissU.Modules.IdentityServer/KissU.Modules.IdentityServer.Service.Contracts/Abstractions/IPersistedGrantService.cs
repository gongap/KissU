// <copyright file="IPersistedGrantService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace KissU.Modules.IdentityServer.Service.Contracts.Abstractions
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using KissU.Modules.IdentityServer.Service.Contracts.Dtos;
    using KissU.Modules.IdentityServer.Service.Contracts.Queries;
    using Util.Applications;
    using Util.Applications.Aspects;
    using Util.Domains.Repositories;
    using Util.Validations.Aspects;

    /// <summary>
    /// 认证操作数据服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IPersistedGrantService : IService
    {
        /// <summary>
        /// 通过编号获取
        /// </summary>
        /// <param name="id">实体编号</param>
        [HttpGet(true)]
        Task<PersistedGrantDto> GetByIdAsync(object id);

        /// <summary>
        /// 通过编号列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        [HttpGet(true)]
        Task<List<PersistedGrantDto>> GetByIdsAsync(string ids);

        /// <summary>
        /// 获取全部
        /// </summary>
        [HttpGet(true)]
        Task<List<PersistedGrantDto>> GetAllAsync();

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        [HttpGet(true)]
        Task<List<PersistedGrantDto>> QueryAsync(PersistedGrantQuery parameter);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        [HttpGet(true)]
        Task<PagerList<PersistedGrantDto>> PagerQueryAsync(PersistedGrantQuery parameter);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">创建参数</param>
        [HttpPost(true)]
        [UnitOfWork]
        Task<string> CreateAsync([Valid] PersistedGrantDto request);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">修改参数</param>
        [HttpPut(true)]
        [UnitOfWork]
        Task UpdateAsync([Valid] PersistedGrantDto request);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        [HttpPost(true)]
        Task DeleteAsync(string ids);
    }
}
