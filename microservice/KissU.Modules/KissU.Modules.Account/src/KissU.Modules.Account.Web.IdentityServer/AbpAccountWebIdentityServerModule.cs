using KissU.Modules.Identity.AspNetCore;
using KissU.Modules.IdentityServer.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace KissU.Modules.Account.Web.IdentityServer
{
    [DependsOn(
        typeof(AbpAccountWebModule),
        typeof(AbpIdentityServerDomainModule)
        )]
    public class AbpAccountWebIdentityServerModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpIdentityAspNetCoreOptions>(options =>
            {
                options.ConfigureAuthentication = false;
            });

            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(AbpAccountWebIdentityServerModule).Assembly);
            });
        }

        public override void ConfigureServices(Volo.Abp.Modularity.ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpAccountWebIdentityServerModule>("KissU.Modules.Account.Web.IdentityServer");
            });

            //TODO: Try to reuse from AbpIdentityAspNetCoreModule
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
