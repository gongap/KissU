using KissU.Abp.Autofac;
using KissU.Modules.Blogging.Application;
using KissU.Modules.Blogging.EntityFrameworkCore.EntityFrameworkCore;
using KissU.Modules.Blogging.Service.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace KissU.Modules.Blogging.Service
{
    [DependsOn(
        typeof(BloggingServiceContractsModule),
        typeof(BloggingApplicationModule),
        typeof(BloggingEntityFrameworkCoreModule),
        typeof(AbpAutofacModule)
    )]
    public class BloggingServiceModule : AbpModule
    {
        public override void ConfigureServices(Volo.Abp.Modularity.ServiceConfigurationContext context)
        {
            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });

            context.Services.AddAlwaysAllowAuthorization();
        }
    }
}