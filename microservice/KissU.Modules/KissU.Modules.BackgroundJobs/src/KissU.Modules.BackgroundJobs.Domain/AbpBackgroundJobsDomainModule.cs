using KissU.Modules.BackgroundJobs.Domain.Shared;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace KissU.Modules.BackgroundJobs.Domain
{
    [DependsOn(
        typeof(AbpBackgroundJobsDomainSharedModule),
        typeof(AbpBackgroundJobsModule),
        typeof(AbpAutoMapperModule)
        )]
    public class AbpBackgroundJobsDomainModule : AbpModule
    {
        public override void ConfigureServices(Volo.Abp.Modularity.ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<AbpBackgroundJobsDomainModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<BackgroundJobsDomainAutoMapperProfile>(validate: true);
            });
        }
    }
}
