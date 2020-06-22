using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using IdentityUser = KissU.Modules.Identity.Domain.IdentityUser;

namespace KissU.Modules.Identity.AspNetCore.Extensions
{
    public static class AbpIdentityServiceCollectionExtensions
    {
        public static IServiceCollection AddAbpSecurityStampValidator(this IServiceCollection services)
        {
            services.AddScoped<AbpSecurityStampValidator>();
            services.AddScoped(typeof(SecurityStampValidator<IdentityUser>), provider => provider.GetService(typeof(AbpSecurityStampValidator)));
            services.AddScoped(typeof(ISecurityStampValidator), provider => provider.GetService(typeof(AbpSecurityStampValidator)));
            return services;
        }
    }
}
