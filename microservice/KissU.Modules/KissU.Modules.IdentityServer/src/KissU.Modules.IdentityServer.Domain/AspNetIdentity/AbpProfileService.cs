using System.Security.Principal;
using System.Threading.Tasks;
using IdentityServer4.AspNetIdentity;
using IdentityServer4.Models;
using KissU.Modules.Identity.Domain;
using Microsoft.AspNetCore.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;
using IdentityUser = KissU.Modules.Identity.Domain.IdentityUser;

namespace KissU.Modules.IdentityServer.Domain.AspNetIdentity
{
    public class AbpProfileService : ProfileService<IdentityUser>
    {
        protected ICurrentTenant CurrentTenant { get; }

        public AbpProfileService(
            IdentityUserManager userManager,
            IUserClaimsPrincipalFactory<IdentityUser> claimsFactory,
            ICurrentTenant currentTenant)
            : base(userManager, claimsFactory)
        {
            CurrentTenant = currentTenant;
        }

        [UnitOfWork]
        public override async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            using (CurrentTenant.Change(context.Subject.FindTenantId()))
            {
                await base.GetProfileDataAsync(context);
            }
        }

        [UnitOfWork]
        public override async Task IsActiveAsync(IsActiveContext context)
        {
            using (CurrentTenant.Change(context.Subject.FindTenantId()))
            {
                await base.IsActiveAsync(context);
            }
        }
    }
}
