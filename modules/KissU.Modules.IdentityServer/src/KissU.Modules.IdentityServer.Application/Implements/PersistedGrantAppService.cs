using KissU.Modules.IdentityServer.Application.Contracts.Abstractions;
using KissU.Modules.IdentityServer.Application.Contracts.Dtos;
using KissU.Modules.IdentityServer.Application.Contracts.Queries;
using KissU.Modules.IdentityServer.Domain.Models;
using KissU.Modules.IdentityServer.Domain.Repositories;
using KissU.Modules.IdentityServer.Domain.UnitOfWorks;
using KissU.Util.Ddd.Application;
using KissU.Util.Ddd.Domain.Datas.Queries;
using KissU.Util.Ddd.Domain.Datas.Repositories;

namespace KissU.Modules.IdentityServer.Application.Implements
{
    /// <summary>
    /// 认证操作数据服务
    /// </summary>
    public class PersistedGrantAppService :
        DeleteServiceBase<PersistedGrant, PersistedGrantDto, PersistedGrantQuery, int>,
        IPersistedGrantAppService
    {
        /// <summary>
        /// 初始化认证操作数据服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="persistedGrantRepository">认证操作数据仓储</param>
        public PersistedGrantAppService(IIdentityServerUnitOfWork unitOfWork,
            IPersistedGrantRepository persistedGrantRepository)
            : base(unitOfWork, persistedGrantRepository)
        {
            PersistedGrantRepository = persistedGrantRepository;
            UnitOfWork = unitOfWork;
        }

        /// <summary>
        /// 认证操作数据仓储
        /// </summary>
        public IPersistedGrantRepository PersistedGrantRepository { get; set; }

        /// <summary>
        /// 工作单元
        /// </summary>
        public IIdentityServerUnitOfWork UnitOfWork { get; set; }

        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">认证操作数据查询实体</param>
        /// <returns>IQueryBase&lt;PersistedGrant&gt;.</returns>
        protected override IQueryBase<PersistedGrant> CreateQuery(PersistedGrantQuery param)
        {
            var query = new Query<PersistedGrant>(param);

            if (string.IsNullOrWhiteSpace(param.Order))
            {
                query.OrderBy(x => x.CreationTime, true);
            }

            return query;
        }
    }
}