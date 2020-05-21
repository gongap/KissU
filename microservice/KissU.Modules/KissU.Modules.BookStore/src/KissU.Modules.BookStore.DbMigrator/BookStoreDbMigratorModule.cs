using KissU.Abp.Autofac;
using KissU.Modules.BookStore.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace KissU.Modules.BookStore.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(BookStoreEntityFrameworkCoreDbMigrationsModule),
        typeof(BookStoreApplicationContractsModule)
        )]
    public class BookStoreDbMigratorModule : AbpModule
    {
        
    }
}
