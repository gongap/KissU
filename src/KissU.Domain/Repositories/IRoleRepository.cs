using System;
using Util.Domains.Trees;
using KissU.Domain.Models;

namespace KissU.Domain.Repositories {
    /// <summary>
    /// 角色仓储
    /// </summary>
    public interface IRoleRepository : ITreeRepository<Role,Guid,Guid?> {
    }
}