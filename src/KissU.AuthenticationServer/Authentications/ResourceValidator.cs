using System;
using System.Threading.Tasks;
using GreatWall.Results;
using GreatWall.Service.Abstractions;
using GreatWall.Service.Dtos.Requests;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Util;

namespace GreatWall.Authentications {
    /// <summary>
    /// 资源密码验证器
    /// </summary>
    public class ResourceValidator : IResourceOwnerPasswordValidator {
        /// <summary>
        /// 安全服务
        /// </summary>
        private readonly ISecurityService _securityService;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="securityService">安全服务</param>
        public ResourceValidator( ISecurityService securityService ) {
            _securityService = securityService;
        }

        /// <summary>
        /// 验证
        /// </summary>
        public async Task ValidateAsync( ResourceOwnerPasswordValidationContext context ) {
            LoginRequest request = new LoginRequest();
            request.Account = context.UserName;
            request.Password = context.Password;
            //request.ApplicationCode = context.Request.Client.ClientId;
            try {
                var result = await _securityService.SignInAsync( request );
                if( result.State == SignInState.Succeeded ) {
                    context.Result = new GrantValidationResult( result.UserId, OidcConstants.AuthenticationMethods.Password );
                    return;
                }
                if( result.State == SignInState.Failed )
                    context.Result = new GrantValidationResult( TokenRequestErrors.InvalidGrant );
            }
            catch( Exception ex ) {
                context.Result = new GrantValidationResult( TokenRequestErrors.InvalidGrant,ex.GetPrompt() );
            }
        }
    }
}
