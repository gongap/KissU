using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Modules.Identity.Application.Contracts;
using KissU.Modules.Identity.Application.Contracts.Dtos;
using KissU.Modules.Identity.Service.Contracts;
using KissU.ServiceProxy;
using Volo.Abp.Account;
using Volo.Abp.Identity;

namespace KissU.Modules.Identity.Service.Implements
{
    /// <summary>
    /// 账号服务
    /// Implements the <see cref="ProxyServiceBase" />
    /// Implements the <see cref="IAccountService" />
    /// </summary>
    /// <seealso cref="ProxyServiceBase" />
    /// <seealso cref="IAccountService" />
    public class AccountService : ProxyServiceBase, IAccountService
    {
        private readonly IMyAccountAppService _accountAppService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountService"/> class.
        /// </summary>
        /// <param name="accountAppService">The account application service.</param>
        public AccountService(IMyAccountAppService accountAppService)
        {
            _accountAppService = accountAppService;
        }

        /// <inheritdoc />
        public async Task<Dictionary<string, List<string>>> SignIn(SignInDto parameters)
        {
            var claimsPrincipal = await _accountAppService.SignInAsync(parameters);
            return claimsPrincipal?.Identities.SelectMany(x => x.Claims).GroupBy(x => x.Type).ToDictionary(y => y.Key, m => m.Select(n => n.Value).ToList());
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