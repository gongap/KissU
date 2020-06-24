using KissU.Modules.Identity.Domain;
using KissU.Modules.Users.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace KissU.Modules.Identity.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpIdentityDomainModule), 
        typeof(AbpUsersEntityFrameworkCoreModule))]
    public class AbpIdentityEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(Volo.Abp.Modularity.ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<IdentityDbContext>(options =>
            {
                options.AddRepository<IdentityUser, EfCoreIdentityUserRepository>();
                options.AddRepository<IdentityRole, EfCoreIdentityRoleRepository>();
                options.AddRepository<IdentityClaimType, EfCoreIdentityClaimTypeRepository>();
                options.AddRepository<OrganizationUnit, EfCoreOrganizationUnitRepository>();
            });
        }
    }
}
