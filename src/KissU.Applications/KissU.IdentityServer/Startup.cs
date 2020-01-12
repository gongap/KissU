using Autofac;
using KissU.IdentityServer.Extensions;
using KissU.Modules.GreatWall.Application.Extensions;
using KissU.Modules.GreatWall.Data;
using KissU.Modules.GreatWall.Data.UnitOfWorks.SqlServer;
using KissU.Modules.GreatWall.Domain.UnitOfWorks;
using KissU.Modules.IdentityServer.Data;
using KissU.Modules.IdentityServer.Data.UnitOfWorks.SqlServer;
using KissU.Modules.IdentityServer.Domain.UnitOfWorks;
using KissU.Util.Datas.SqlServer;
using KissU.Util.Logs.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KissU.IdentityServer
{
    /// <summary>
    /// 启动配置
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 初始化启动配置
        /// </summary>
        /// <param name="configuration">配置</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <returns></returns>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // 添加SqlServer工作单元
            services.AddUnitOfWork<IIdentityServerUnitOfWork, IdentityServerUnitOfWork>(Configuration.GetConnectionString(IdentityServerDataConstants.ConnectionStringName));
            services.AddUnitOfWork<IGreatWallUnitOfWork, GreatWallUnitOfWork>(Configuration.GetConnectionString(GreatWallDataConstants.ConnectionStringName));

            // 添加AspNetIdentity
            services.AspNetIdentity(options =>
            {
                options.Password.MinLength = 6;
                options.Password.NonAlphanumeric = true;
                options.Password.Uppercase = true;
                options.Password.Digit = true;
            });

            // 添加IdentityServer4
            services.AddIdentityServer4(options =>
            {
                options.EnableTokenCleanup = true;
                options.TokenCleanupInterval = 600;
            });

            // 添加NLog日志操作
            services.AddNLog();
        }

        /// <summary>
        /// 配置容器
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
        }

        /// <summary>
        /// 配置请求管道
        /// </summary>
        /// <param name="app">应用生成器</param>
        /// <param name="env">web主机环境</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}