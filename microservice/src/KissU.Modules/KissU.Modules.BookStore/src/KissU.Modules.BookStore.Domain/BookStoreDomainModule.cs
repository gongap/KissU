using Volo.Abp.Modularity;

namespace KissU.Modules.BookStore
{
    [DependsOn(
        typeof(BookStoreDomainSharedModule)
        )]
    public class BookStoreDomainModule : AbpModule
    {

    }
}
