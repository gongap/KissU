using System;
using GreatWall.Data;
using GreatWall.Data.UnitOfWorks.SqlServer;
using GreatWall.Service.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Util;
using Util.Datas.Ef;
using Util.Logs.Extensions;
using Util.Ui.Extensions;
using Util.Webs.Extensions;

namespace GreatWall {
    /// <summary>
    /// 启动配置
    /// </summary>
    public class Startup {
        /// <summary>
        /// 初始化启动配置
        /// </summary>
        /// <param name="configuration">配置</param>
        public Startup( IConfiguration configuration ) {
            Configuration = configuration;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 配置服务
        /// </summary>
        public IServiceProvider ConfigureServices( IServiceCollection services ) {
            //配置Cookie策略
            services.Configure<CookiePolicyOptions>( options => {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            } );

            //注册Razor视图解析路径
            services.AddRazorViewLocationExpander();

            //添加Mvc服务
            services.AddMvc().SetCompatibilityVersion( CompatibilityVersion.Version_2_2 ).AddRazorPageConventions();

            //添加NLog日志操作
            services.AddNLog();

            //添加EF工作单元
            services.AddUnitOfWork<IGreatWallUnitOfWork, GreatWallUnitOfWork>( Configuration.GetConnectionString( "DefaultConnection" ) );

            //添加权限服务
            services.AddPermission( t => { t.Lockout.MaxFailedAccessAttempts = 2; } );

            //添加Util基础设施服务
            return services.AddUtil();
        }

        /// <summary>
        /// 配置开发环境请求管道
        /// </summary>
        public void ConfigureDevelopment( IApplicationBuilder app ) {
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();
            app.UseWebpackDevMiddleware( new WebpackDevMiddlewareOptions {
                HotModuleReplacement = true
            } );
            CommonConfig( app );
        }

        /// <summary>
        /// 配置生产环境请求管道
        /// </summary>
        public void ConfigureProduction( IApplicationBuilder app ) {
            app.UseExceptionHandler( "/Home/Error" );
            CommonConfig( app );
        }

        /// <summary>
        /// 公共配置
        /// </summary>
        private void CommonConfig( IApplicationBuilder app ) {
            app.UseErrorLog();
            app.UseStaticFiles();
            app.UseAuthentication();
            ConfigRoute( app );
        }

        /// <summary>
        /// 路由配置,支持区域
        /// </summary>
        private void ConfigRoute( IApplicationBuilder app ) {
            app.UseMvc( routes => {
                routes.MapSpaFallbackRoute( "spa-fallback", new { controller = "Home", action = "Index" } );
            } );
        }
    }
}