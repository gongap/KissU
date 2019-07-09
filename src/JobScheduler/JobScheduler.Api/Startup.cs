using System;
using System.IO;
using JobScheduler.Data;
using JobScheduler.Data.UnitOfWorks.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Util;
using Util.Datas.Ef;
using Util.Logs.Extensions;
using Util.Webs.Extensions;

namespace JobScheduler.Api
{
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
            //添加Api服务
            services.AddMvc().SetCompatibilityVersion( CompatibilityVersion.Version_2_2 );

            //添加NLog日志操作
            services.AddNLog();

            //添加EF工作单元
            services.AddUnitOfWork<IJobSchedulerUnitOfWork, JobSchedulerUnitOfWork>(Configuration.GetConnectionString("DefaultConnection"));

            //添加Swagger
            services.AddSwaggerGen( options => {
                options.SwaggerDoc( "v1", new Info { Title = "JobScheduler.Api", Version = "v1" } );
                options.IncludeXmlComments( Path.Combine( AppContext.BaseDirectory, "JobScheduler.Api.xml") );
            } );

            //添加Util基础设施服务
            return services.AddUtil();
        }

        /// <summary>
        /// 配置开发环境请求管道
        /// </summary>
        public void ConfigureDevelopment( IApplicationBuilder app ) {
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();
            app.UseSwaggerX();
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
            app.UseMvc();
        }
    }
}
