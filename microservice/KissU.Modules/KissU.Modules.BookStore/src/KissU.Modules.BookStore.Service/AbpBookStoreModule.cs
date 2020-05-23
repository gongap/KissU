using KissU.Abp.Autofac;
using KissU.Modules.BookStore.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace KissU.Modules.BookStore.Service
{
    [DependsOn(
        typeof(BookStoreApplicationModule),
        typeof(BookStoreEntityFrameworkCoreDbMigrationsModule),
        typeof(AbpAutofacModule)
    )]
    public class AbpBookStoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });

            context.Services.AddAutoMapperObjectMapper<AbpBookStoreModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<AbpBookStoreAutoMapperProfile>(validate: true);
            });
        }
    }
}