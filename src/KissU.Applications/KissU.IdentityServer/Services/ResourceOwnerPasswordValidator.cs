using System;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using KissU.Modules.GreatWall.Application.Abstractions;
using KissU.Modules.GreatWall.Application.Dtos.Requests;
using KissU.Modules.GreatWall.Domain.Results;
using KissU.Util;

namespace KissU.IdentityServer.Services
{
    /// <summary>
    /// 资源密码验证器
    /// </summary>
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        /// <summary>
        /// 安全服务
        /// </summary>
        private readonly ISecurityAppService _securityService;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="securityService">安全服务</param>
        public ResourceOwnerPasswordValidator(ISecurityAppService securityService)
        {
            _securityService = securityService;
        }

        /// <summary>
        /// 验证
        /// </summary>
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var request = new LoginRequest();
            request.Account = context.UserName;
            request.Password = context.Password;
            //request.ClientId = context.Request.Client.ClientId;
            try
            {
                var result = await _securityService.SignInAsync(request);
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