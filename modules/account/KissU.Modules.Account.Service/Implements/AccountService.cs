using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Modules.Account.Service.Contracts;
using KissU.Modules.Account.Service.Contracts.Models;
using KissU.ServiceProxy;
using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace KissU.Modules.Account.Service.Implements
{
    /// <summary>
    /// 账号服务
    /// Implements the <see cref="ProxyServiceBase" />
    /// Implements the <see cref="IAccountService" />
    /// </summary>
    /// <seealso cref="ProxyServiceBase" />
    /// <seealso cref="IAccountService" />
    [ModuleName("Account")]
    public class AccountService : ProxyServiceBase, IAccountService
    {
        private readonly IAccountAppService _accountAppService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountService"/> class.
        /// </summary>
        /// <param name="accountAppService">The account application service.</param>
        public AccountService(IAccountAppService accountAppService)
        {
            _accountAppService = accountAppService;
        }

        /// <inheritdoc />
        public Task<UserData> Login(LoginDto parameters)
        {
            return Task.FromResult(new UserData
            {
                Id = System.Guid.Parse("33ABC3EE-F993-CB34-D04E-39F7278885BA"), 
                UserName = "admin",
                PhoneNumber = parameters.Mobile
            });
        }

        /// <inheritdoc />
        public virtual Task<IdentityUserDto> Register(RegisterDto parameters)
        {
            return _accountAppService.RegisterAsync(parameters);
        }

        /// <inheritdoc />
        public Task SendPasswordResetCode(SendPasswordResetCodeDto parameters)
        {
            return _accountAppService.SendPasswordResetCodeAsync(parameters);
        }

        /// <inheritdoc />
        public Task ResetPassword(ResetPasswordDto parameters)
        {
            return _accountAppService.ResetPasswordAsync(parameters);
        }
    }
}