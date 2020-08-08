using System;
using System.Threading.Tasks;

namespace KissU.Modules.Identity.Domain.Shared
{
    public interface IUserRoleFinder
    {
        Task<string[]> GetRolesAsync(Guid userId);
    }
}
