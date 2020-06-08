using KissU.Abp.Autofac;
using KissU.Modules.Identity.Domain;
using KissU.Modules.IdentityServer.DbMigrations.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;
using Volo.Abp.Settings;

namespace KissU.Modules.IdentityServer.Web
{
    [DependsOn(typeof(AbpAspNetCoreMvcModule),
        typeof(EntityFrameworkCoreDbMigrationsModule),
        typeof(AbpAutofacModule)
    )]
    public class AbpIdentityServerModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpSettingOptions>(options =>
            {
                options.DefinitionProviders.Add<AbpIdentitySettingDefinitionProvider>();
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseConfiguredEndpoints();
        }
    }
}