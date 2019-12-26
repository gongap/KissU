using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Modules.GreatWall.Application.Queries;
using KissU.Modules.GreatWall.Service.Contracts;
using KissU.Util.Domains.Repositories;

namespace KissU.Modules.GreatWall.Service {
    /// <summary>
    /// Api资源查询服务
    /// </summary>
    public class QueryApiResourceService: IQueryApiResourceService
    {
        /// <summary>
        /// 通过编号获取
        /// </summary>
        /// <param name="id">实体编号</param>
        public async Task<ApiResourceDto> GetByIdAsync(object id)
        {
            return null;
        }

        /// <summary>
        /// 通过编号列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        public async Task<List<ApiResourceDto>> GetByIdsAsync(string ids)
        {
            return null;
        }

        /// <summary>
        /// 获取全部
        /// </summary>
        public async Task<List<ApiResourceDto>> GetAllAsync()
        {
            return null;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        public async Task<List<ApiResourceDto>> QueryAsync(ResourceQuery parameter)
        {
            return null;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        public async Task<PagerList<ApiResourceDto>> PagerQueryAsync(ResourceQuery parameter)
        {
            return null;
        }

        /// <summary>
        /// 获取资源列表
        /// </summary>
        /// <param name="uri">资源标识列表</param>
        public async Task<List<ApiResourceDto>> GetResources(List<string> uri)
        {
            return null;
        }

        /// <summary>
        /// 获取资源
        /// </summary>
        /// <param name="uri">资源标识</param>
        public async Task<ApiResourceDto> GetResource(string uri)
        {
            return null;
        }
    }
}