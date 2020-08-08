using System;
using System.Threading.Tasks;
using KissU.Modules.Blogging.Domain.Blogs;
using KissU.Modules.Blogging.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace KissU.Modules.Blogging.EntityFrameworkCore.Blogs
{
    public class EfCoreBlogRepository : EfCoreRepository<IBloggingDbContext, Blog, Guid>, IBlogRepository
    {
        public EfCoreBlogRepository(IDbContextProvider<IBloggingDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<Blog> FindByShortNameAsync(string shortName)
        {
            return await DbSet.FirstOrDefaultAsync(p => p.ShortName == shortName);
        }
    }
}
