using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Modules.Identity.Application.Contracts;
using KissU.Modules.Identity.Application.Contracts.Account;
using KissU.Modules.Identity.Service.Contracts;
using KissU.Surging.ProxyGenerator;

namespace KissU.Modules.Identity.Service.Implements
{
    [ModuleName("Account")]
    public class AccountService : ProxyServiceBase, IAccountService
    {
        private readonly IAccountAppService _accountAppService;

        public AccountService(IAccountAppService accountAppService)
        {
            _accountAppService = accountAppService;
        }

        public virtual Task<IdentityUserDto> RegisterAsync(RegisterDto input)
        {
            return _accountAppService.RegisterAsync(input);
        }

        public Task<AbpLoginResult> Login(UserLoginInfo login)
        {
            return _accountAppService.Login(login);
        }

        public Task Logout()
        {
            return _accountAppService.Logout();
        }

        public Task<AbpLoginResult> CheckPassword(UserLoginInfo login)
        {
            return _accountAppService.CheckPassword(login);
        }
    }
}