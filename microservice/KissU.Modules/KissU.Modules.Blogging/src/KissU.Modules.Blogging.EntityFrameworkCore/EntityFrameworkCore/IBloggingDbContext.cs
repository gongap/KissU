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
    public interface IBloggingDbContext : IEfCoreDbContext
    {
        DbSet<BlogUser> Users { get; }

        DbSet<Blog> Blogs { get; set; }

        DbSet<Post> Posts { get; set; }

        DbSet<Comment> Comments { get; set; }

        DbSet<PostTag> PostTags { get; set; }

        DbSet<Tag> Tags { get; set; }
    }
}