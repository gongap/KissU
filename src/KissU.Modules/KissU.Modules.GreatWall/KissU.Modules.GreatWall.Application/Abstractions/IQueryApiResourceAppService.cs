using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Modules.GreatWall.Application.Queries;
using KissU.Util.Applications;

namespace KissU.Modules.GreatWall.Application.Abstractions
{
    /// <summary>
    /// Api资源查询服务
    /// </summary>
    public interface IQueryApiResourceAppService : IQueryService<ApiResourceDto, ResourceQuery>
    {
        /// <summary>
        /// 获取资源列表
        /// </summary>
        /// <param name="uri">资源标识列表</param>
        Task<List<ApiResourceDto>> GetResources(List<string> uri);

        /// <summary>
        /// 获取资源
        /// </summary>
        /// <param name="uri">资源标识</param>
        Task<ApiResourceDto> GetResource(string uri);
    }
}