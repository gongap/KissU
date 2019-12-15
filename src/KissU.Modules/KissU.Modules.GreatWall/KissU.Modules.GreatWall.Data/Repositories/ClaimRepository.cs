// <copyright file="ClaimRepository.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.GreatWall.Data.Repositories
{
    using KissU.Modules.GreatWall.Domain.Models;
    using KissU.Modules.GreatWall.Domain.Repositories;
    using Util.Datas.Ef.Core;

    /// <summary>
    /// 声明仓储
    /// </summary>
    public class ClaimRepository : RepositoryBase<Claim>, IClaimRepository
    {
        /// <summary>
        /// 初始化声明仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ClaimRepository(IGreatWallUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
