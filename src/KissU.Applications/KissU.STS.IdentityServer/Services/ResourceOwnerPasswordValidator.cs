using System.Collections.Generic;
using System.Linq;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using static IdentityModel.OidcConstants;
using IdentityServer4.Services;
using IdentityServer4.Events;
using KissU.Modules.GreatWall.Domain.Shared.Results;
using KissU.Modules.GreatWall.Service.Contracts.Abstractions;
using KissU.Modules.GreatWall.Service.Contracts.Dtos.Requests;

namespace KFNets.Microservices.IdentityServer.Services
{
    /// <summary>
    /// IResourceOwnerPasswordValidator that integrates with ASP.NET Identity.
    /// </summary>
    /// <typeparam name="TUser">The type of the user.</typeparam>
    /// <seealso cref="IdentityServer4.Validation.IResourceOwnerPasswordValidator" />
    public class ResourceOwnerPasswordValidator<TUser> : IResourceOwnerPasswordValidator
        where TUser : class
    {
        private readonly IUserService _userService;
        private readonly ISecurityService _securityService;
        private readonly IEventService _events;
        private readonly ILogger<ResourceOwnerPasswordValidator<TUser>> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceOwnerPasswordValidator{TUser}"/> class.
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="securityService"></param>
        /// <param name="events">The events.</param>
        /// <param name="logger">The logger.</param>
        public ResourceOwnerPasswordValidator(
            IUserService userService,
            ISecurityService securityService,
            IEventService events,
            ILogger<ResourceOwnerPasswordValidator<TUser>> logger)
        {
            _userService = userService;
            _securityService = securityService;
            _events = events;
            _logger = logger;
        }

        /// <summary>
        /// Validates the resource owner password credential
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public virtual async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var userName = context.UserName;
            var loginRequest = new LoginRequest { Account = userName, Password = context.Password, Remember = false, LockoutOnFailure = true };
            var result = await _securityService.SignInAsync(loginRequest);
            switch (result.State)
            {
                //登录成功
                case SignInState.Succeeded:
                    _logger.LogInformation("Credentials validated for username: {username}", userName);
                    await _events.RaiseAsync(new UserLoginSuccessEvent(userName, result.UserId, userName, interactive: false));
                    context.Result = new GrantValidationResult(result.UserId, AuthenticationMethods.Password);
                    return;
                //账号锁定
                case SignInState.IsLockedOut:
                    _logger.LogInformation("Authentication failed for username: {username}, reason: locked out", userName);
                    await _events.RaiseAsync(new UserLoginFailureEvent(userName, "locked out", interactive: false));
                    break;
                //账号禁用
                case SignInState.IsNotAllowed:
                    _logger.LogInformation("Authentication failed for username: {username}, reason: not allowed", userName);
                    await _events.RaiseAsync(new UserLoginFailureEvent(userName, "not allowed", interactive: false));
                    break;
                //登录失败
                case SignInState.Failed:
                    _logger.LogInformation("Authentication failed for username: {username}, reason: {error}", userName, result.Error);
                    await _events.RaiseAsync(new UserLoginFailureEvent(userName, result.Error, interactive: false));
                    break;
                //需要两阶段认证
                case SignInState.TwoFactor:
                    break;
            }
            context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, result.Error);
        }
    }
}
