// <copyright file="IUserService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.GreatWall.Service.Contracts.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using KissU.Modules.GreatWall.Service.Contracts.Dtos;
    using KissU.Modules.GreatWall.Service.Contracts.Dtos.Requests;
    using KissU.Modules.GreatWall.Service.Contracts.Queries;
    using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
    using Util.Applications;
    using Util.Aspects;
    using Util.Domains.Repositories;
    using Util.Validations.Aspects;

    /// <summary>
    ///     用户服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IUserService : IService
    {
        /// <summary>
        ///     通过编号获取
        /// </summary>
        /// <param name="id">实体编号</param>
        [HttpGet(true)]
        Task<UserDto> GetByIdAsync(object id);

        /// <summary>
        ///     通过编号列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        [HttpGet(true)]
        Task<List<UserDto>> GetByIdsAsync(string ids);

        /// <summary>
        ///     获取全部
        /// </summary>
        [HttpGet(true)]
        Task<List<UserDto>> GetAllAsync();

        /// <summary>
        ///     查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        [HttpGet(true)]
        Task<List<UserDto>> QueryAsync(UserQuery parameter);

        /// <summary>
        ///     分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        [HttpGet(true)]
        Task<PagerList<UserDto>> PagerQueryAsync(UserQuery parameter);

        /// <summary>
        ///     删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        [HttpPost(true)]
        Task DeleteAsync(string ids);

        /// <summary>
        ///     创建用户
        /// </summary>
        /// <param name="request">创建用户参数</param>
        [HttpPost(true)]
        Task<Guid> CreateAsync([NotNull] [Valid] CreateUserRequest request);
    }
}
