// <copyright file="PersistedGrantRepository.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.IdentityServer.Data.Repositories
{
    using KissU.Modules.IdentityServer.Data.UnitOfWorks;
    using KissU.Modules.IdentityServer.Domain.Models.PersistedGrantAggregate;
    using KissU.Modules.IdentityServer.Domain.Repositories;
    using Util.Datas.Ef.Core;

    /// <summary>
    /// 认证操作数据仓储
    /// </summary>
    public class PersistedGrantRepository : RepositoryBase<PersistedGrant>, IPersistedGrantRepository
    {
        /// <summary>
        /// 初始化身份资源仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public PersistedGrantRepository(IIdentityServerUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
