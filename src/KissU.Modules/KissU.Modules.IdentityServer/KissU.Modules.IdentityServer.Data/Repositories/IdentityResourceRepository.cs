using KissU.Modules.IdentityServer.Domain;
using KissU.Modules.IdentityServer.Domain.Models;
using KissU.Modules.IdentityServer.Domain.Repositories;
using KissU.Util.Datas.Ef.Core;

namespace KissU.Modules.IdentityServer.Data.Repositories
{
    /// <summary>
    /// 身份资源仓储
    /// </summary>
    public class IdentityResourceRepository : RepositoryBase<IdentityResource>, IIdentityResourceRepository
    {
        /// <summary>
        /// 初始化身份资源仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public IdentityResourceRepository(IIdentityServerUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}