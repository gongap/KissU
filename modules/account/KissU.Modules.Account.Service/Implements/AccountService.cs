using System;
using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Modules.Account.Service.Contracts;
using KissU.ServiceProxy;
using Microsoft.Extensions.Localization;
using Volo.Abp.Account;
using Volo.Abp.Account.Localization;
using Volo.Abp.Identity;

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
        private readonly IStringLocalizer<AccountResource> _localizer;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountService"/> class.
        /// </summary>
        /// <param name="accountAppService">The account application service.</param>
        public AccountService(IAccountAppService accountAppService, IStringLocalizer<AccountResource> stringLocalizer)
        {
            _accountAppService = accountAppService;
            _localizer = stringLocalizer;
        }

        /// <inheritdoc />
        public virtual Task<IdentityUserDto> Register(RegisterDto parameters)
        {
            Console.WriteLine(_localizer["UserNameOrEmailAddress"]);
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