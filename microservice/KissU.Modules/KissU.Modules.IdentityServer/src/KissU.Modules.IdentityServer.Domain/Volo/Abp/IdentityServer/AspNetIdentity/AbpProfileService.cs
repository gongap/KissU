﻿using System.Threading.Tasks;
using System.Security.Principal;
using IdentityServer4.AspNetIdentity;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;
using IdentityUser = Volo.Abp.Identity.IdentityUser;

namespace KissU.Modules.IdentityServer.AspNetIdentity
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