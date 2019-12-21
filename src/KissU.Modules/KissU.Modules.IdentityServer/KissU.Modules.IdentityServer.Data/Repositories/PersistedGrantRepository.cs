// <copyright file="PersistedGrantRepository.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Modules.IdentityServer.Data.UnitOfWorks;
using KissU.Modules.IdentityServer.Domain;
using KissU.Modules.IdentityServer.Domain.Models;
using KissU.Modules.IdentityServer.Domain.Repositories;
using KissU.Util.Datas.Ef.Core;

namespace KissU.Modules.IdentityServer.Data.Repositories
{
    /// <summary>
    /// 认证操作数据仓储
    /// </summary>
    public class PersistedGrantRepository : RepositoryBase<PersistedGrant, int>, IPersistedGrantRepository
    {
        /// <summary>
        /// 初始化认证操作数据仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public PersistedGrantRepository(IIdentityServerUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
