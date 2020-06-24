using KissU.Modules.Identity.AspNetCore.Extensions;
using KissU.Modules.Identity.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace KissU.Modules.Identity.AspNetCore
{
    [DependsOn(
        typeof(AbpIdentityDomainModule)
    )]
    public class AbpIdentityAspNetCoreModule : AbpModule
    {
        public override void ConfigureServices(Volo.Abp.Modularity.ServiceConfigurationContext context)
        {
            context.Services
                .GetObject<IdentityBuilder>()
                .AddDefaultTokenProviders()
                .AddSignInManager();

            context.Services.AddAbpSecurityStampValidator();

            var options = context.Services.ExecutePreConfiguredActions(new AbpIdentityAspNetCoreOptions());

            if (options.ConfigureAuthentication)
            {
                context.Services
                    .AddAuthentication(o =>
                    {
                        o.DefaultScheme = IdentityConstants.ApplicationScheme;
                        o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
                    })
                    .AddIdentityCookies();
            }
        }
    }
}