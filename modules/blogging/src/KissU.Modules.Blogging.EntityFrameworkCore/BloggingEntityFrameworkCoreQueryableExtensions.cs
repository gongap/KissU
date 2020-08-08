using System.Linq;
using KissU.Modules.Blogging.Domain.Posts;
using Microsoft.EntityFrameworkCore;

namespace KissU.Modules.Blogging.EntityFrameworkCore
{
    public static class BloggingEntityFrameworkCoreQueryableExtensions
    {
        public static IQueryable<Post> IncludeDetails(this IQueryable<Post> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(x => x.Tags);
        }
    }
}
