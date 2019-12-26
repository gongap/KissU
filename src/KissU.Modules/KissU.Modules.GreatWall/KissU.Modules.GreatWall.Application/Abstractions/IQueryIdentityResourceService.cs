using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Modules.GreatWall.Application.Queries;
using KissU.Util.Applications;

namespace KissU.Modules.GreatWall.Application.Abstractions {
    /// <summary>
    /// 身份资源查询服务
    /// </summary>
    public interface IQueryIdentityResourceService : IQueryService<IdentityResourceDto, ResourceQuery> {
        /// <summary>
        /// 获取资源列表
        /// </summary>
        /// <param name="uri">资源标识列表</param>
        Task<List<IdentityResourceDto>> GetResources( List<string> uri );
    }
}