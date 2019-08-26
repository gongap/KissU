using System.Collections.Generic;
using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Surging.Core.CPlatform.Support;
using Surging.Core.CPlatform.Support.Attributes;
using System.Threading.Tasks;
using KissU.IModuleServices.Admin.Dtos;
using KissU.IModuleServices.Admin.Dtos.NgAlain;
using KissU.IModuleServices.Admin.Queries;
using Microsoft.AspNetCore.Authorization;
using Surging.Core.CPlatform.Filters.Implementation;
using Util.Applications.Aspects;
using Util.Domains.Repositories;
using Util.Validations.Aspects;

namespace KissU.IModuleServices.Admin.Abstractions
{
    /// <summary>
    /// 语言国际化服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface ILanguageService : IServiceKey
    {
        /// <summary>通过编码获取</summary>
        /// <param name="code">编码</param>
        Task<Dictionary<string, string>> GetByCodeAsync(string code);

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
        [UnitOfWork]
        Task<string> CreateAsync([Valid] LanguageDto request);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">修改参数</param>
        [HttpPut(true)]
        [UnitOfWork]
        Task UpdateAsync([Valid] LanguageDto request);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        [HttpPost(true)]
        Task DeleteAsync(string ids);
    }
}