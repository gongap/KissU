using KissU.Modularity;
using KissU.Modules.Identity.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.Users.EntityFrameworkCore;

namespace KissU.Modules.Identity.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpIdentityDomainModule), 
        typeof(AbpUsersEntityFrameworkCoreModule))]
    public class AbpIdentityEntityFrameworkCoreModule : AbpBusunessModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
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
