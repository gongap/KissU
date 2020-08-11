using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace KissU.Modules.Blogging.Domain.Blogs
{
    public interface IBlogRepository : IBasicRepository<Blog, Guid>
    {
        Task<Blog> FindByShortNameAsync(string shortName);
    }
}
