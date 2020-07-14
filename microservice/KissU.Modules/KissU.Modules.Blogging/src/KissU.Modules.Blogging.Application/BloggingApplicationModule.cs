using KissU.Modules.Blogging.Application.Comments;
using KissU.Modules.Blogging.Application.Contracts;
using KissU.Modules.Blogging.Application.Posts;
using KissU.Modules.Blogging.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace KissU.Modules.Blogging.Application
{
    [DependsOn(
        typeof(BloggingDomainModule),
        typeof(BloggingApplicationContractsModule),
        typeof(AbpCachingModule),
        typeof(AbpAutoMapperModule))]
    public class BloggingApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<BloggingApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<BloggingApplicationAutoMapperProfile>(validate: true);
            });

            Configure<AuthorizationOptions>(options =>
            {
                //TODO: Rename UpdatePolicy/DeletePolicy since it's candidate to conflicts with other modules!
                options.AddPolicy("BloggingUpdatePolicy", policy => policy.Requirements.Add(CommonOperations.Update));
                options.AddPolicy("BloggingDeletePolicy", policy => policy.Requirements.Add(CommonOperations.Delete));
            });

            context.Services.AddSingleton<IAuthorizationHandler, CommentAuthorizationHandler>();
            context.Services.AddSingleton<IAuthorizationHandler, PostAuthorizationHandler>();

        }
    }
}
