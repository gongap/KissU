using System.IO;
using KissU.AuthServer.Host.Modules.Account;
using KissU.Modules.Account.Application;
using KissU.Modules.Account.Application.Contracts;
using KissU.Modules.Account.Application.Contracts.Localization;
using KissU.Modules.AuditLogging.EntityFrameworkCore.EntityFrameworkCore;
using KissU.Modules.Identity.Application.Contracts;
using KissU.Modules.Identity.AspNetCore;
using KissU.Modules.Identity.EntityFrameworkCore;
using KissU.Modules.IdentityServer.Domain;
using KissU.Modules.IdentityServer.EntityFrameworkCore.EntityFrameworkCore;
using KissU.Modules.PermissionManagement.EntityFrameworkCore;
using KissU.Modules.SettingManagement.EntityFrameworkCore;
using KissU.Modules.TenantManagement.Application.Contracts;
using KissU.Modules.TenantManagement.EntityFrameworkCore;
using Localization.Resources.AbpUi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.Auditing;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Threading;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;

namespace KissU.AuthServer.Host
{
    [DependsOn(
        typeof(AbpAutofacModule),
        //typeof(AbpEventBusRabbitMqModule),,
        typeof(AbpAutoMapperModule),
        typeof(AbpPermissionManagementEntityFrameworkCoreModule),
        typeof(AbpAuditLoggingEntityFrameworkCoreModule),
        typeof(AbpSettingManagementEntityFrameworkCoreModule),
        typeof(AbpTenantManagementEntityFrameworkCoreModule),
        typeof(AbpIdentityEntityFrameworkCoreModule),
        typeof(AbpIdentityServerEntityFrameworkCoreModule),
        typeof(AbpIdentityApplicationContractsModule),
        typeof(AbpAccountApplicationModule),
        typeof(AbpEntityFrameworkCoreSqlServerModule),
        typeof(AbpIdentityServerDomainModule),
        typeof(AbpAspNetCoreMvcUiThemeSharedModule),
        typeof(AbpIdentityAspNetCoreModule),
        typeof(AbpAccountApplicationContractsModule),
        typeof(AbpAspNetCoreMvcUiBasicThemeModule),
        typeof(AbpTenantManagementApplicationContractsModule)
    )]
    public class AuthServerHostModule : AbpModule
    {
        private bool isMultiTenancyEnabled = true;

        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(typeof(AccountResource), typeof(AuthServerHostModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            Configure<AbpMultiTenancyOptions>(options =>
            {
                options.IsEnabled = isMultiTenancyEnabled;
            });

            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });

            Configure<AbpAuditingOptions>(options =>
            {
                options.IsEnabledForGetRequests = true;
                options.ApplicationName = "AuthServer";
            });

            Configure<AbpToolbarOptions>(options =>
            {
                options.Contributors.Add(new AccountModuleToolbarContributor());
            });

            Configure<RazorPagesOptions>(options =>
            {
                options.Conventions.AuthorizePage("/Account/Manage");
            });

            ConfigureVirtualFileSystem(hostingEnvironment);
            ConfigureLocalizationServices();
            ConfigureAutoMapper(context.Services);
            ConfigureNavigationServices();
            ConfigureSwaggerServices(context.Services);

            //context.Services.AddStackExchangeRedisCache(options =>
            //{
            //    options.Configuration = configuration["Redis:Configuration"];
            //});

            //TODO: ConnectionMultiplexer.Connect call has problem since redis may not be ready when this service has started!
            //var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
            //context.Services.AddDataProtection().PersistKeysToStackExchangeRedis(redis, "MsDemo-DataProtection-Keys");
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            app.UseCorrelationId();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseErrorPage();
            }

            app.UseVirtualFiles();
            app.UseRouting();
            app.UseAbpRequestLocalization();

            if (isMultiTenancyEnabled)
            {
                app.UseMultiTenancy();
            }

            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "AuthServer API");
            });

            app.UseAuditing();
            app.UseConfiguredEndpoints();

            //TODO: Problem on a clustered environment
            RunDataSeeder(context);
        }

        /// <summary>
        /// 运行种子数据
        /// </summary>
        /// <param name="context">The context.</param>
        private static void RunDataSeeder(ApplicationInitializationContext context)
        {
            AsyncHelper.RunSync(async () =>
            {
                using var scope = context.ServiceProvider.CreateScope();
                await scope.ServiceProvider
                    .GetRequiredService<IDataSeeder>()
                    .SeedAsync();
            });
        }

        /// <summary>
        /// 配置本地化服务
        /// </summary>
        private void ConfigureLocalizationServices()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<AccountResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
                options.Languages.Add(new LanguageInfo("cs", "cs", "Čeština"));
                options.Languages.Add(new LanguageInfo("en", "en", "English"));
                options.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Português"));
                options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
            });
        }

        /// <summary>
        /// 配置AutoMapper映射
        /// </summary>
        private void ConfigureAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapperObjectMapper<AuthServerHostModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<AccountWebAutoMapperProfile>(validate: true);
            });
        }

        /// <summary>
        /// 配置虚拟文件系统
        /// </summary>
        /// <param name="hostingEnvironment">主机环境</param>
        private void ConfigureVirtualFileSystem(IWebHostEnvironment hostingEnvironment)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AuthServerHostModule>("KissU.AuthServer.Host");
            });
        }

        /// <summary>
        /// 配置导航服务
        /// </summary>
        private void ConfigureNavigationServices()
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new AccountUserMenuContributor());
            });
        }

        /// <summary>
        /// 配置Swagger文档服务
        /// </summary>
        /// <param name="services">服务集合</param>
        private void ConfigureSwaggerServices(IServiceCollection services)
        {
            services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "SpectrumMonitoring API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => type.FullName);
                });
        }
    }
}