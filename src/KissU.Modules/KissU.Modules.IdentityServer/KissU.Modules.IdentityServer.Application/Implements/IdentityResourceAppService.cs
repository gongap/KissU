using System.Linq;
using System.Threading.Tasks;
using KissU.Modules.IdentityServer.Application.Abstractions;
using KissU.Modules.IdentityServer.Application.Dtos;
using KissU.Modules.IdentityServer.Application.Dtos.Requests;
using KissU.Modules.IdentityServer.Application.Queries;
using KissU.Modules.IdentityServer.Domain.Models;
using KissU.Modules.IdentityServer.Domain.Repositories;
using KissU.Modules.IdentityServer.Domain.UnitOfWorks;
using KissU.Util.Applications;
using KissU.Util.Datas.Queries;
using KissU.Util.Domains.Repositories;
using KissU.Util.Exceptions;

namespace KissU.Modules.IdentityServer.Application.Implements
{
    /// <summary>
    /// 应用程序服务
    /// </summary>
    public class IdentityResourceAppService :
        CrudServiceBase<IdentityResource, IdentityResourceDto, IdentityResourceDto, IdentityResourceCreateRequest,
            IdentityResourceDto, IdentityResourceQuery, int>, IIdentityResourceAppService
    {
        /// <summary>
        /// 初始化应用程序服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="identityResourceRepository">应用程序仓储</param>
        public IdentityResourceAppService(IIdentityServerUnitOfWork unitOfWork,
            IIdentityResourceRepository identityResourceRepository)
            : base(unitOfWork, identityResourceRepository)
        {
            IdentityResourceRepository = identityResourceRepository;
            UnitOfWork = unitOfWork;
        }

        /// <summary>
        /// 应用程序仓储
        /// </summary>
        public IIdentityResourceRepository IdentityResourceRepository { get; set; }

        /// <summary>
        /// 工作单元
        /// </summary>
        public IIdentityServerUnitOfWork UnitOfWork { get; set; }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">修改参数</param>
        /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> representing the asynchronous operation.</returns>
        public override async Task UpdateAsync(IdentityResourceDto request)
        {
            await base.UpdateAsync(request);
            await UnitOfWork.CommitAsync();
        }

        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">应用程序查询实体</param>
        /// <returns>IQueryBase&lt;IdentityResource&gt;.</returns>
        protected override IQueryBase<IdentityResource> CreateQuery(IdentityResourceQuery param)
        {
            var query = new Query<IdentityResource>(param).Or(t => t.Name.Contains(param.Keyword),
                t => t.DisplayName.Contains(param.Keyword));

            if (param.Enabled.HasValue)
            {
                query.And(t => t.Enabled == param.Enabled.Value);
            }

            if (string.IsNullOrWhiteSpace(param.Order))
            {
                query.OrderBy(x => x.Id, true);
            }

            return query;
        }

        /// <summary>
        /// 创建前操作
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected override void CreateBefore(IdentityResource entity)
        {
            base.CreateBefore(entity);
            if (IdentityResourceRepository.Exists(t => t.Name == entity.Name))
            {
                ThrowDuplicateNameException(entity.Name);
            }
        }

        /// <summary>
        /// 创建后操作
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> representing the asynchronous operation.</returns>
        protected override async Task CreateAfterAsync(IdentityResource entity)
        {
            await base.CreateAfterAsync(entity);
            await UnitOfWork.CommitAsync();
        }

        /// <summary>
        /// 抛出Name重复异常
        /// </summary>
        private void ThrowDuplicateNameException(string name)
        {
            throw new Warning(string.Format("名称{0} 重复", name));
        }

        /// <summary>
        /// 修改前操作
        /// </summary>
        /// <param name="entity">实体</param>
        protected override void UpdateBefore(IdentityResource entity)
        {
            base.UpdateBefore(entity);
            if (IdentityResourceRepository.Exists(t => t.Id != entity.Id && t.Name == entity.Name))
            {
                ThrowDuplicateNameException(entity.Name);
            }
        }

        /// <summary>
        /// 过滤
        /// </summary>
        /// <param name="queryable">The queryable.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>IQueryable&lt;IdentityResource&gt;.</returns>
        protected override IQueryable<IdentityResource> Filter(IQueryable<IdentityResource> queryable,
            IdentityResourceQuery parameter)
        {
            return base.Filter(queryable, parameter);
        }
    }
}