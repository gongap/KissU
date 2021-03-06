using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Modules.Account.Service.Contracts;
using KissU.Modules.Account.Service.Contracts.Models;
using KissU.ServiceProxy;
using Volo.Abp.Account;
using Volo.Abp.Identity;

namespace KissU.Modules.Account.Service.Implements
{
    [ModuleName(AccountRemoteServiceConsts.RemoteServiceName)]
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

        public Task SendPasswordResetCodeAsync(SendPasswordResetCodeDto input)
        {
            return _accountAppService.SendPasswordResetCodeAsync(input);
        }

        public Task ResetPasswordAsync(ResetPasswordDto input)
        {
            return _accountAppService.ResetPasswordAsync(input);
        }

        public Task<IdentityUserDto> Authentication(AuthenticationRequestData requestData)
        {
            if (requestData.UserName == "admin" && requestData.Password == "admin")
            {
                return Task.FromResult(new IdentityUserDto() { Id = System.Guid.NewGuid(), Name = "admin" });
            }

            return Task.FromResult<IdentityUserDto>(null);
        }
    }
}