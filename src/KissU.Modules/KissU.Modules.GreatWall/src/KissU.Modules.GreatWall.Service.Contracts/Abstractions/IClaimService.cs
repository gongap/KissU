// <copyright file="IClaimService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.GreatWall.Service.Contracts.Abstractions
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using KissU.Modules.GreatWall.Service.Contracts.Dtos;
    using KissU.Modules.GreatWall.Service.Contracts.Queries;
    using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
    using Util.Applications;
    using Util.Applications.Aspects;
    using Util.Domains.Repositories;
    using Util.Validations.Aspects;

    /// <summary>
    /// 声明服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IClaimService : IService
    {
        /// <summary>
        /// 通过编号获取
        /// </summary>
        /// <param name="id">实体编号</param>
        [HttpGet(true)]
        Task<ClaimDto> GetByIdAsync(object id);

        /// <summary>
        /// 通过编号列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        [HttpGet(true)]
        Task<List<ClaimDto>> GetByIdsAsync(string ids);

        /// <summary>
        /// 获取全部
        /// </summary>
        [HttpGet(true)]
        Task<List<ClaimDto>> GetAllAsync();

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        [HttpGet(true)]
        Task<List<ClaimDto>> QueryAsync(ClaimQuery parameter);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        [HttpGet(true)]
        Task<PagerList<ClaimDto>> PagerQueryAsync(ClaimQuery parameter);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">创建参数</param>
        [HttpPost(true)]
        [UnitOfWork]
        Task<string> CreateAsync([Valid] ClaimDto request);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">修改参数</param>
        [HttpPut(true)]
        [UnitOfWork]
        Task UpdateAsync([Valid] ClaimDto request);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        [HttpPost(true)]
        Task DeleteAsync(string ids);
    }
}
