using System;
using System.Threading.Tasks;
using KissU.Modules.Identity.Domain.Shared;
using Volo.Abp.DependencyInjection;

namespace KissU.Modules.Identity.Domain
{
    public class UserRoleFinder : IUserRoleFinder, ITransientDependency
    {
        protected IIdentityUserRepository IdentityUserRepository { get; }

        public UserRoleFinder(IIdentityUserRepository identityUserRepository)
        {
            IdentityUserRepository = identityUserRepository;
        }

        public virtual async Task<string[]> GetRolesAsync(Guid userId)
        {
            return (await IdentityUserRepository.GetRoleNamesAsync(userId)).ToArray();
        }
    }
}
