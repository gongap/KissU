using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Modules.Account.Application.Contracts;
using KissU.Modules.Account.Service.Contracts;
using KissU.Modules.Identity.Application.Contracts;
using KissU.Surging.ProxyGenerator;
using Volo.Abp.Account;

namespace KissU.Modules.Account.Service.Implements
{
    [ModuleName(AccountRemoteServiceConsts.RemoteServiceName)]
    public class AccountService : ProxyServiceBase, IAccountService
    {
        protected IAccountAppService AccountAppService { get; }

        public AccountService(IAccountAppService accountAppService)
        {
            AccountAppService = accountAppService;
        }

        public virtual Task<IdentityUserDto> RegisterAsync(RegisterDto input)
        {
            return AccountAppService.RegisterAsync(input);
        }
    }
}