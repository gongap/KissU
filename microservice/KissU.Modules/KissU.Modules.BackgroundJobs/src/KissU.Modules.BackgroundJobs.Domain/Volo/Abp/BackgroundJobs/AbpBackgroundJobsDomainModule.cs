using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace KissU.Modules.BackgroundJobs
{
    [DependsOn(
        typeof(AbpBackgroundJobsDomainSharedModule),
        typeof(AbpBackgroundJobsModule),
        typeof(AbpAutoMapperModule)
        )]
    public class AbpBackgroundJobsDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<AbpBackgroundJobsDomainModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<BackgroundJobsDomainAutoMapperProfile>(validate: true);
            });
        }
    }
}
