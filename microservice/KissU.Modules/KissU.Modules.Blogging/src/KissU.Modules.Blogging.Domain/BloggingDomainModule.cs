using KissU.Modules.Blogging.Domain.Blogs;
using KissU.Modules.Blogging.Domain.Comments;
using KissU.Modules.Blogging.Domain.Posts;
using KissU.Modules.Blogging.Domain.Shared;
using KissU.Modules.Blogging.Domain.Shared.Blogs;
using KissU.Modules.Blogging.Domain.Shared.Comments;
using KissU.Modules.Blogging.Domain.Shared.Posts;
using KissU.Modules.Blogging.Domain.Shared.Tagging;
using KissU.Modules.Blogging.Domain.Tagging;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Domain;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Modularity;

namespace KissU.Modules.Blogging.Domain
{
    [DependsOn(
        typeof(BloggingDomainSharedModule),
        typeof(AbpDddDomainModule),
        typeof(AbpAutoMapperModule))]
    public class BloggingDomainModule : AbpModule
    {
        public override void ConfigureServices(Volo.Abp.Modularity.ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<BloggingDomainModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<BloggingDomainMappingProfile>(validate: true);
            });

            Configure<AbpDistributedEntityEventOptions>(options =>
            {
                options.EtoMappings.Add<Blog, BlogEto>(typeof(BloggingDomainModule));
                options.EtoMappings.Add<Comment, CommentEto>(typeof(BloggingDomainModule));
                options.EtoMappings.Add<Post, PostEto>(typeof(BloggingDomainModule));
                options.EtoMappings.Add<Tag, TagEto>(typeof(BloggingDomainModule));
            });
        }
    }
}
