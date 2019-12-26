using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Abstractions;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Modules.GreatWall.Application.Dtos.Extensions;
using KissU.Modules.GreatWall.Application.Queries;
using KissU.Modules.GreatWall.Data.Pos;
using KissU.Modules.GreatWall.Data.Stores.Abstractions;
using KissU.Modules.GreatWall.Domain.Shared.Enums;
using KissU.Util.Applications;
using KissU.Util.Datas.Queries;
using KissU.Util.Domains.Repositories;

namespace KissU.Modules.GreatWall.Application.Implements {
    /// <summary>
    /// 身份资源查询服务
    /// </summary>
    public class QueryIdentityResourceAppService : QueryServiceBase<ResourcePo, IdentityResourceDto, ResourceQuery>, IQueryIdentityResourceAppService {
        /// <summary>
        /// 初始化身份资源服务
        /// </summary>
        /// <param name="resourceStore">资源存储器</param>
        public QueryIdentityResourceAppService( IResourcePoStore resourceStore )
            : base( resourceStore ) {
            ResourceStore = resourceStore;
        }
        
        /// <summary>
        /// 身份资源存储器
        /// </summary>
        public IResourcePoStore ResourceStore { get; set; }

        /// <summary>
        /// 转成身份资源参数
        /// </summary>
        protected override IdentityResourceDto ToDto( ResourcePo po ) {
            return po.ToIdentityResourceDto();
        }

        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<ResourcePo> CreateQuery( ResourceQuery param ) {
            return new Query<ResourcePo>( param )
                .Where( t => t.Type == ResourceType.Identity )
                .WhereIfNotEmpty( t => t.Uri.Contains( param.Uri ) )
                .WhereIfNotEmpty( t => t.Name.Contains( param.Name ) );
        }

        /// <summary>
        /// 获取全部
        /// </summary>
        public override async Task<List<IdentityResourceDto>> GetAllAsync() {
            var entities = await ResourceStore.FindAllAsync( t => t.Type == ResourceType.Identity );
            return entities.Select( ToDto ).ToList();
        }

        /// <summary>
        /// 获取资源列表
        /// </summary>
        /// <param name="uri">资源标识列表</param>
        public async Task<List<IdentityResourceDto>> GetResources( List<string> uri ) {
            if( uri == null || uri.Count == 0 )
                return new List<IdentityResourceDto>();
            var resources = await ResourceStore.FindAllAsync( t => uri.Contains( t.Uri ) && t.Type == ResourceType.Identity );
            if( resources == null )
                return new List<IdentityResourceDto>();
            return resources.Select( t => t.ToIdentityResourceDto() ).ToList();
        }
    }
}