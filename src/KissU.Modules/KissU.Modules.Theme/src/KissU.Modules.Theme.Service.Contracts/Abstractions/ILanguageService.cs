// <copyright file="ILanguageService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace KissU.Modules.Theme.Service.Contracts.Abstractions
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using KissU.Modules.Theme.Service.Contracts.Dtos;
    using KissU.Modules.Theme.Service.Contracts.Queries;
    using Util.Applications;
    using Util.Domains.Repositories;
    using Util.Validations.Aspects;

    /// <summary>
    /// 语言国际化服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface ILanguageService : IService
    {
        /// <summary>
        /// 获取语言国际化数据
        /// </summary>
        /// <param name="lang">语言编码</param>
        [HttpGet(true)]
        Task<Dictionary<string, string>> GetLangDataAsync(string lang = "zh-CN");

        /// <summary>
        /// 通过编号获取
        /// </summary>
        /// <param name="id">实体编号</param>
        [HttpGet(true)]
        Task<LanguageDto> GetByIdAsync(object id);

        /// <summary>
        /// 通过编号列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        [HttpGet(true)]
        Task<List<LanguageDto>> GetByIdsAsync(string ids);

        /// <summary>
        /// 获取全部
        /// </summary>
        [HttpGet(true)]
        Task<List<LanguageDto>> GetAllAsync();

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        [HttpGet(true)]
        Task<List<LanguageDto>> QueryAsync(LanguageQuery parameter);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        [HttpGet(true)]
        Task<PagerList<LanguageDto>> PagerQueryAsync(LanguageQuery parameter);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">创建参数</param>
        [HttpPost(true)]
        Task<string> CreateAsync([Valid] LanguageDto request);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">修改参数</param>
        [HttpPut(true)]
        Task UpdateAsync([Valid] LanguageDto request);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        [HttpDelete(true)]
        Task DeleteAsync(string ids);
    }
}
