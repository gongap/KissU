using System;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using KissU.Core;
using KissU.Core.Utilities;
using KissU.Modules.GreatWall.Application.Contracts.Abstractions;
using KissU.Modules.GreatWall.Application.Contracts.Dtos.Requests;
using KissU.Modules.GreatWall.Domain.Shared.Results;
using KissU.Surging.ProxyGenerator;

namespace KissU.Modules.IdentityServer.Service.Services
{
    /// <summary>
    /// 资源密码验证器
    /// </summary>
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="context">The context.</param>
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var securityService = ServiceLocator.GetService<IServiceProxyFactory>().CreateProxy<ISecurityAppService>();
            var request = new LoginRequest();
            request.Account = context.UserName;
            request.Password = context.Password;
            try
            {
                var result = await securityService.SignInAsync(request);
                if (result.State == SignInState.Succeeded)
                {
                    context.Result = new GrantValidationResult(result.UserId, OidcConstants.AuthenticationMethods.Password);
                    return;
                }

                if (result.State == SignInState.Failed)
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant);
            }
            catch (Exception ex)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, ex.GetPrompt());
            }
        }
    }
}