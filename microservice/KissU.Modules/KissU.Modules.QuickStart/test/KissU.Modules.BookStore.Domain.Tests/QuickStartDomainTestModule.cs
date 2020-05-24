using KissU.Modules.QuickStart.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace KissU.Modules.QuickStart
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(QuickStartEntityFrameworkCoreTestModule)
        )]
    public class QuickStartDomainTestModule : AbpModule
    {
        
    }
}
