using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KissU.Modules.Blogging.Domain.Users;
using KissU.Modules.Blogging.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Users.EntityFrameworkCore;

namespace KissU.Modules.Blogging.EntityFrameworkCore.Users
{
    public class EfCoreBlogUserRepository : EfCoreUserRepositoryBase<IBloggingDbContext, BlogUser>, IBlogUserRepository
    {
        public EfCoreBlogUserRepository(IDbContextProvider<IBloggingDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {

        }

        public async Task<List<BlogUser>> GetUsersAsync(int maxCount, string filter, CancellationToken cancellationToken = default)
        {
            return await DbSet
                .WhereIf( !string.IsNullOrWhiteSpace( filter), x=>x.UserName.Contains(filter))
                .Take(maxCount).ToListAsync(cancellationToken);
        }
    }
}
