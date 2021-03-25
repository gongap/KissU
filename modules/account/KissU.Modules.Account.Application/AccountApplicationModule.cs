using KissU.Modules.Account.Application.Contracts;
using Volo.Abp.Account;
using Volo.Abp.Modularity;

namespace KissU.Modules.Account.Application
{
    [DependsOn(typeof(AccountApplicationContractsModule), typeof(AbpAccountApplicationModule)
    )]
    public class AccountApplicationModule : AbpModule
    {
    }
}