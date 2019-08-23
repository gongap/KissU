using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Util.Logs.Extensions;
using Util.Ui.Extensions;
using Util.Webs.Extensions;
using Util;
using Util.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.SpaServices.AngularCli;

namespace KissU.AdminConsole
{
    /// <summary>
    /// 启动配置
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 初始化启动配置
        /// </summary>
        /// <param name="env">环境</param>
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }
            Configuration = builder.Build();
            Environment = env;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 环境
        /// </summary>
        public IHostingEnvironment Environment { get; }

        /// <summary>
        /// 配置服务
        /// </summary>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //注册Razor视图解析路径
            services.AddRazorViewLocationExpander();

            //添加Mvc服务
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddRazorPageConventions();

            //添加Spa单页服务
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "Typings/dist"; });

            //添加NLog日志操作
            services.AddNLog();

            //添加Swagger
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new Info { Title = "兽医系统接口文档", Version = "v1" });
            });

            //添加Util基础设施服务
            return services.AddUtil();
        }

        /// <summary>
        /// 配置开发环境请求管道
        /// </summary>
        public void ConfigureDevelopment(IApplicationBuilder app)
        {
            app.UseBrowserLink();
            app.UseDeveloperExceptionPage();
            app.UseSwaggerX();
            CommonConfig(app);
        }

        /// <summary>
        /// 配置演示环境请求管道
        /// </summary>
        public void ConfigureStaging(IApplicationBuilder app)
        {
            app.UseExceptionHandler("/Home/Error");
            CommonConfig(app);
        }

        /// <summary>
        /// 配置生产环境请求管道
        /// </summary>
        public void ConfigureProduction(IApplicationBuilder app)
        {
            app.UseExceptionHandler("/Home/Error");
            CommonConfig(app);
        }

        /// <summary>
        /// 公共配置
        /// </summary>
        private void CommonConfig(IApplicationBuilder app)
        {
            app.UseErrorLog();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseAuthentication();
            ConfigRoute(app);
        }

        /// <summary>
        /// 路由配置,支持区域
        /// </summary>
        private void ConfigRoute(IApplicationBuilder app)
        {
            app.UseMvc(routes => {
                routes.MapSpaFallbackRoute("spa-fallback", new { controller = "Home", action = "Index" });
            });
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "Typings";
                //if (Environment.IsDevelopment()) spa.UseAngularCliServer("start");
            });
        }
    }
}