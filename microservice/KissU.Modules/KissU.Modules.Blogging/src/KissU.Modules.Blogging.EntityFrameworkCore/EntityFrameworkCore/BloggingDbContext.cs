using KissU.Modules.Blogging.Domain;
using KissU.Modules.Blogging.Domain.Blogs;
using KissU.Modules.Blogging.Domain.Comments;
using KissU.Modules.Blogging.Domain.Posts;
using KissU.Modules.Blogging.Domain.Tagging;
using KissU.Modules.Blogging.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace KissU.Modules.Blogging.EntityFrameworkCore.EntityFrameworkCore
{
    [ConnectionStringName(BloggingDbProperties.ConnectionStringName)]
    public class BloggingDbContext : AbpDbContext<BloggingDbContext>, IBloggingDbContext
    {
        public DbSet<BlogUser> Users { get; set; }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<PostTag> PostTags { get; set; }

        public DbSet<Comment> Comments { get; set; }
        
        public BloggingDbContext(DbContextOptions<BloggingDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureBlogging();
        }
    }
}