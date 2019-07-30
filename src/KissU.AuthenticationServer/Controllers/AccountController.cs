using System;
using System.Linq;
using System.Threading.Tasks;
using GreatWall.Attributes;
using GreatWall.Configs;
using GreatWall.Models;
using GreatWall.Results;
using GreatWall.Service.Abstractions;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Util;

namespace GreatWall.Controllers {
    /// <summary>
    /// 用户认证控制器
    /// </summary>
    [SecurityHeaders]
    [AllowAnonymous]
    public class AccountController : Controller {
        /// <summary>
        /// 初始化用户认证控制器
        /// </summary>
        /// <param name="interaction">交互服务</param>
        /// <param name="schemeProvider">认证方案提供器</param>
        /// <param name="securityService">安全服务</param>
        /// <param name="userService">用户服务</param>
        public AccountController( IIdentityServerInteractionService interaction, IAuthenticationSchemeProvider schemeProvider,
            ISecurityService securityService, IUserService userService ) {
            InteractionService = interaction;
            AuthenticationSchemeProvider = schemeProvider;
            SecurityService = securityService;
            UserService = userService;
        }

        /// <summary>
        /// 交互服务
        /// </summary>
        public IIdentityServerInteractionService InteractionService { get; set; }
        /// <summary>
        /// 认证方案提供器
        /// </summary>
        public IAuthenticationSchemeProvider AuthenticationSchemeProvider { get; set; }
        /// <summary>
        /// 安全服务
        /// </summary>
        public ISecurityService SecurityService { get; set; }
        /// <summary>
        /// 用户服务
        /// </summary>
        public IUserService UserService { get; set; }

        /// <summary>
        /// 进入登录页面
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Login( string returnUrl ) {
            var model = await BuildLoginViewModelAsync( returnUrl );
            if( model.IsExternalLoginOnly ) {
                return RedirectToAction( "Challenge", "External", new { provider = model.ExternalLoginScheme, returnUrl } );
            }
            return View( model );
        }

        private async Task<LoginViewModel> BuildLoginViewModelAsync( string returnUrl ) {
            var context = await InteractionService.GetAuthorizationContextAsync( returnUrl );
            if( context?.IdP != null ) {
                var local = context.IdP == IdentityServerConstants.LocalIdentityProvider;

                var vm = new LoginViewModel {
                    EnableLocalLogin = local,
                    ReturnUrl = returnUrl,
                    UserName = context?.LoginHint,
                };

                if( !local ) {
                    vm.ExternalProviders = new[] { new ExternalProvider { AuthenticationScheme = context.IdP } };
                }

                return vm;
            }

            var schemes = await AuthenticationSchemeProvider.GetAllSchemesAsync();

            var providers = schemes
                .Where( x => x.DisplayName != null ||
                             ( x.Name.Equals( AccountOptions.WindowsAuthenticationSchemeName, StringComparison.OrdinalIgnoreCase ) )
                )
                .Select( x => new ExternalProvider {
                    DisplayName = x.DisplayName,
                    AuthenticationScheme = x.Name
                } ).ToList();

            var allowLocal = true;
            if( context?.ClientId != null ) {
                //var client = await _clientStore.FindEnabledClientByIdAsync( context.ClientId );
                //if( client != null ) {
                //    allowLocal = client.EnableLocalLogin;

                //    if( client.IdentityProviderRestrictions != null && client.IdentityProviderRestrictions.Any() ) {
                //        providers = providers.Where( provider => client.IdentityProviderRestrictions.Contains( provider.AuthenticationScheme ) ).ToList();
                //    }
                //}
            }

            return new LoginViewModel {
                AllowRemember = AccountOptions.AllowRemember,
                EnableLocalLogin = allowLocal && AccountOptions.AllowLocalLogin,
                ReturnUrl = returnUrl,
                UserName = context?.LoginHint,
                ExternalProviders = providers.ToArray()
            };
        }

        private async Task<LoginViewModel> BuildLoginViewModelAsync( LoginViewModel model ) {
            var result = await BuildLoginViewModelAsync( model.ReturnUrl );
            result.UserName = model.UserName;
            result.Remember = model.Remember;
            return result;
        }

        /// <summary>
        /// 登录
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login( LoginViewModel model, string button ) {
            var context = await InteractionService.GetAuthorizationContextAsync( model.ReturnUrl );
            if ( button != "login" )
                return await Cancel( context, model );
            if ( ModelState.IsValid == false ) {
                var viewModel = await BuildLoginViewModelAsync( model );
                return View( viewModel );
            }
            return await Login( context,model );
        }

        /// <summary>
        /// 取消操作
        /// </summary>
        private async Task<IActionResult> Cancel( AuthorizationRequest context, LoginViewModel model ) {
            if( context == null )
                return Redirect( "~/" );
            await InteractionService.GrantConsentAsync( context, ConsentResponse.Denied );
            return Redirect( model.ReturnUrl );
        }

        /// <summary>
        /// 取消操作
        /// </summary>
        private async Task<IActionResult> Login( AuthorizationRequest context, LoginViewModel model ) {
            var result = await SecurityService.SignInAsync( model.ToLoginRequest() );
            if ( result.State == SignInState.Failed ) {
                var viewModel = await BuildLoginViewModelAsync( model );
                viewModel.Message = result.Message;
                return View( viewModel );
            }
            if( context != null )
                return Redirect( model.ReturnUrl );
            if ( Url.IsLocalUrl( model.ReturnUrl ) )
                return Redirect( model.ReturnUrl );
            if ( model.ReturnUrl.IsEmpty() )
                return Redirect( "~/" );
            throw new Exception( "返回地址无效" );
        }

        /// <summary>
        /// 显示登出页面
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Logout( string logoutId ) {
            var model = await BuildLogoutViewModelAsync( logoutId );
            return await Logout( model );
        }

        /// <summary>
        /// 创建登出参数
        /// </summary>
        private async Task<LogoutViewModel> BuildLogoutViewModelAsync( string logoutId ) {
            var model = new LogoutViewModel { LogoutId = logoutId, ShowLogoutPrompt = AccountOptions.ShowLogoutPrompt };
            if( User?.Identity.IsAuthenticated != true ) {
                model.ShowLogoutPrompt = false;
                return model;
            }
            var context = await InteractionService.GetLogoutContextAsync( logoutId );
            if( context?.ShowSignoutPrompt == false ) {
                model.ShowLogoutPrompt = false;
                return model;
            }
            return model;
        }

        /// <summary>
        /// 登出
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout( LogoutViewModel model ) {
            var result = await BuildLoggedOutViewModelAsync( model.LogoutId );
            if( User?.Identity.IsAuthenticated == true )
                await SecurityService.SignOutAsync();
            if( result.TriggerExternalSignout ) {
                string url = Url.Action( "Logout", new { logoutId = result.LogoutId } );
                return SignOut( new AuthenticationProperties { RedirectUri = url }, result.ExternalAuthenticationScheme );
            }
            if( result.PostLogoutRedirectUri.IsEmpty() )
                return View();
            return Redirect( result.PostLogoutRedirectUri );
        }

        /// <summary>
        /// 创建登出参数
        /// </summary>
        private async Task<LoggedOutViewModel> BuildLoggedOutViewModelAsync( string logoutId ) {
            var logout = await InteractionService.GetLogoutContextAsync( logoutId );
            var result = new LoggedOutViewModel {
                AutomaticRedirectAfterSignOut = AccountOptions.AutomaticRedirectAfterSignOut,
                PostLogoutRedirectUri = logout?.PostLogoutRedirectUri,
                ClientName = string.IsNullOrEmpty( logout?.ClientName ) ? logout?.ClientId : logout?.ClientName,
                SignOutIframeUrl = logout?.SignOutIFrameUrl,
                LogoutId = logoutId
            };
            if( User?.Identity.IsAuthenticated != true )
                return result;
            var idp = User.FindFirst( JwtClaimTypes.IdentityProvider )?.Value;
            if ( idp == null || idp == IdentityServerConstants.LocalIdentityProvider )
                return result;
            var providerSupportsSignout = await HttpContext.GetSchemeSupportsSignOutAsync( idp );
            if ( providerSupportsSignout == false )
                return result;
            if( result.LogoutId == null )
                result.LogoutId = await InteractionService.CreateLogoutContextAsync();
            result.ExternalAuthenticationScheme = idp;
            return result;
        }
    }
}
