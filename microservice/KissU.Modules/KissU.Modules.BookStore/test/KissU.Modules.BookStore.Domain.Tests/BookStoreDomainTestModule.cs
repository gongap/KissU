using KissU.Modules.BookStore.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace KissU.Modules.BookStore
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(BookStoreEntityFrameworkCoreTestModule)
        )]
    public class BookStoreDomainTestModule : AbpModule
    {
        
    }
}
