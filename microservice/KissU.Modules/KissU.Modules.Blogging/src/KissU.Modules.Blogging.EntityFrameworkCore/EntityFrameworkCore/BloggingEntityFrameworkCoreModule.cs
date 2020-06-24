using KissU.Modules.Blogging.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace KissU.Modules.Blogging.EntityFrameworkCore.EntityFrameworkCore
{
    [DependsOn(
        typeof(BloggingDomainModule),
        typeof(AbpEntityFrameworkCoreModule))]
    public class BloggingEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(Volo.Abp.Modularity.ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<BloggingDbContext>();
        }
    }
}
