using System;
using KissU.AuthenticationServer.Authentications;
using KissU.AuthenticationServer.Configs;
using KissU.Modules.GreatWall.Data;
using KissU.Modules.GreatWall.Data.UnitOfWorks.SqlServer;
using KissU.Modules.GreatWall.Domain.Models;
using KissU.Modules.GreatWall.Service.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Util;
using Util.Datas.Ef;
using Util.Logs.Extensions;
using Util.Webs.Extensions;

namespace KissU.AuthenticationServer
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
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //添加Mvc服务
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //添加NLog日志操作
            services.AddNLog();

            //添加SqlServer工作单元
            services.AddUnitOfWork<IGreatWallUnitOfWork, GreatWallUnitOfWork>(
                Configuration.GetConnectionString("DefaultConnection"));
            //添加PgSql工作单元
            //services.AddUnitOfWork<IGreatWallUnitOfWork, Data.UnitOfWorks.PgSql.GreatWallUnitOfWork>( Configuration.GetConnectionString( "PgSqlConnection" ) );

            //添加权限服务
            services.AddPermission();

            //配置Identity Server
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryClients(Config.GetClients())
                .AddAspNetIdentity<User>()
                .AddResourceOwnerValidator<ResourceValidator>()
                .AddProfileService<ProfileService>();

            //添加Util基础设施服务
            return services.AddUtil();
        }

        /// <summary>
        /// 配置开发环境请求管道
        /// </summary>
        public void ConfigureDevelopment(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();
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
            app.UseIdentityServer();
            app.UseMvcWithDefaultRoute();
        }
    }
}