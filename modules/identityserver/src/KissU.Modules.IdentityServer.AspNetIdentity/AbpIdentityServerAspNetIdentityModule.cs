using KissU.Modules.Identity.Domain;
using KissU.Modules.IdentityServer.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace KissU.Modules.IdentityServer.AspNetIdentity
{
    [DependsOn(
        typeof(AbpIdentityDomainModule),
        typeof(AbpIdentityServerDomainModule)
        )]
    public class AbpIdentityServerAspNetIdentityModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IIdentityServerBuilder>(builder =>
            {
                var builderOptions = context.Services.ExecutePreConfiguredActions<AbpIdentityServerBuilderOptions>();
                builder.AddAspNetIdentity(builderOptions);
            });
        }
    }
}
