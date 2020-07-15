using System;
using KissU.Abp.Autofac;
using KissU.Modules.Blogging.Web;
using KissU.MultiTenancy;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Volo.Abp;
using Volo.Abp.AspNetCore.Authentication.OAuth;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.Http.Client.IdentityModel.Web;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.UI.Navigation;

namespace KissU.PublicWebSite.Host
{
    [DependsOn(
        typeof(AbpAutofacModule)
        , typeof(AbpAspNetCoreAuthenticationOAuthModule)
        , typeof(AbpHttpClientIdentityModelWebModule)
        , typeof(AbpAspNetCoreMvcUiBasicThemeModule)
        , typeof(BloggingWebModule)
        )]
    public class PublicWebSiteHostModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Languages.Add(new LanguageInfo("en", "en", "English"));
            });

            Configure<AbpMultiTenancyOptions>(options =>
            {
                options.IsEnabled = IsEnabledMultiTenancy();
            });

            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new PublicWebSiteMenuContributor());
            });

            context.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
                .AddCookie("Cookies", options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromDays(365);
                })
                .AddOpenIdConnect("oidc", options =>
                {
                    options.Authority = configuration["AuthServer:Authority"];
                    options.ClientId = configuration["AuthServer:ClientId"];
                    options.ClientSecret = configuration["AuthServer:ClientSecret"];
                    options.RequireHttpsMetadata = false;
                    options.ResponseType = OpenIdConnectResponseType.CodeIdToken;
                    options.SaveTokens = true;
                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.Scope.Add("role");
                    options.Scope.Add("email");
                    options.Scope.Add("phone");
                    options.Scope.Add("PublicWebSiteGateway");
                    options.Scope.Add("ProductService");
                    options.Scope.Add("BloggingService");
                    options.ClaimActions.MapAbpClaimTypes();
                });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();

            app.UseCorrelationId();
            app.UseVirtualFiles();
            app.UseRouting();
            app.UseAuthentication();

            if (IsEnabledMultiTenancy())
            {
                app.UseMultiTenancy();
            }

            app.UseAbpRequestLocalization();
            app.UseAuthorization();
            app.UseConfiguredEndpoints();
        }

        private bool IsEnabledMultiTenancy()
        {
            return MultiTenancyConsts.IsEnabled;
        }
    }
}
