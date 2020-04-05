using System.Linq;
using KissU.Core.Datas.Queries;
using KissU.Modules.GreatWall.Application.Abstractions;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Modules.GreatWall.Application.Dtos.Extensions;
using KissU.Modules.GreatWall.Application.Queries;
using KissU.Modules.GreatWall.Data.Pos;
using KissU.Modules.GreatWall.Data.Stores.Abstractions;
using KissU.Modules.GreatWall.Domain.Enums;
using KissU.Modules.GreatWall.Domain.Repositories;
using KissU.Modules.GreatWall.Domain.UnitOfWorks;
using KissU.Util.Applications.Trees;
using KissU.Util.Ddd.Datas.Queries;
using KissU.Util.Ddd.Domains.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KissU.Modules.GreatWall.Application.Implements
{
    /// <summary>
    /// 模块查询服务
    /// </summary>
    public class QueryModuleAppService : TreeServiceBase<ResourcePo, ModuleDto, ResourceQuery>, IQueryModuleAppService
    {
        /// <summary>
        /// 初始化资源服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="resourceStore">资源存储器</param>
        /// <param name="moduleRepository">模块仓储</param>
        public QueryModuleAppService(IGreatWallUnitOfWork unitOfWork, IResourcePoStore resourceStore,
            IModuleRepository moduleRepository)
            : base(unitOfWork, resourceStore)
        {
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
        /// <returns>IQueryBase&lt;ResourcePo&gt;.</returns>
        protected override IQueryBase<ResourcePo> CreateQuery(ResourceQuery param)
        {
            return new Query<ResourcePo>(param)
                .Where(t => t.Type == ResourceType.Module)
                .Where(t => t.ApplicationId == param.ApplicationId)
                .WhereIfNotEmpty(t => t.Name.Contains(param.Name))
                .WhereIfNotEmpty(t => t.Uri.Contains(param.Uri));
        }

        /// <summary>
        /// 过滤
        /// </summary>
        /// <param name="queryable">The queryable.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>结果</returns>
        protected override IQueryable<ResourcePo> Filter(IQueryable<ResourcePo> queryable, ResourceQuery parameter)
        {
            return base.Filter(queryable, parameter).Include(t => t.Application).Include(t => t.Parent);
        }

        /// <summary>
        /// 转成数据传输对象
        /// </summary>
        /// <param name="po">The po.</param>
        /// <returns>ModuleDto.</returns>
        protected override ModuleDto ToDto(ResourcePo po)
        {
            return po.ToModuleDto();
        }
    }
}