using System.Linq;
using GreatWall.Data;
using GreatWall.Data.Pos;
using GreatWall.Data.Stores.Abstractions;
using GreatWall.Domain.Enums;
using GreatWall.Domain.Repositories;
using GreatWall.Service.Abstractions;
using GreatWall.Service.Dtos;
using GreatWall.Service.Dtos.Extensions;
using GreatWall.Service.Queries;
using Microsoft.EntityFrameworkCore;
using Util.Applications.Trees;
using Util.Datas.Queries;
using Util.Domains.Repositories;

namespace GreatWall.Service.Implements {
    /// <summary>
    /// 模块查询服务
    /// </summary>
    public class ModuleQueryService : TreeServiceBase<ResourcePo, ModuleDto, ResourceQuery>, IModuleQueryService {
        /// <summary>
        /// 初始化资源服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="resourceStore">资源存储器</param>
        /// <param name="moduleRepository">模块仓储</param>
        public ModuleQueryService( IGreatWallUnitOfWork unitOfWork, IResourcePoStore resourceStore, IModuleRepository moduleRepository )
            : base( unitOfWork, resourceStore ) {
            UnitOfWork = unitOfWork;
            ResourceStore = resourceStore;
            ModuleRepository = moduleRepository;
        }

        /// <summary>
        /// 工作单元
        /// </summary>
        public IGreatWallUnitOfWork UnitOfWork { get; set; }
        /// <summary>
        /// 资源存储器
        /// </summary>
        public IResourcePoStore ResourceStore { get; set; }
        /// <summary>
        /// 模块仓储
        /// </summary>
        public IModuleRepository ModuleRepository { get; set; }

        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<ResourcePo> CreateQuery( ResourceQuery param ) {
            return new Query<ResourcePo>( param )
                .Where( t => t.Type == ResourceType.Module )
                .Where( t => t.ApplicationId == param.ApplicationId )
                .WhereIfNotEmpty( t => t.Name.Contains( param.Name ) )
                .WhereIfNotEmpty( t => t.Uri.Contains( param.Uri ) );
        }

        /// <summary>
        /// 过滤
        /// </summary>
        protected override IQueryable<ResourcePo> Filter( IQueryable<ResourcePo> queryable, ResourceQuery parameter ) {
            return base.Filter( queryable, parameter ).Include( t => t.Application ).Include( t => t.Parent );
        }

        /// <summary>
        /// 转成数据传输对象
        /// </summary>
        protected override ModuleDto ToDto( ResourcePo po ) {
            return po.ToModuleDto();
        }
    }
}