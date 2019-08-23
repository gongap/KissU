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
    /// ��������
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// ��ʼ����������
        /// </summary>
        /// <param name="env">����</param>
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
        /// ����
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// ����
        /// </summary>
        public IHostingEnvironment Environment { get; }

        /// <summary>
        /// ���÷���
        /// </summary>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //ע��Razor��ͼ����·��
            services.AddRazorViewLocationExpander();

            //���Mvc����
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddRazorPageConventions();

            //���Spa��ҳ����
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "Typings/dist"; });

            //���NLog��־����
            services.AddNLog();

            //���Swagger
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new Info { Title = "��ҽϵͳ�ӿ��ĵ�", Version = "v1" });
            });

            //���Util������ʩ����
            return services.AddUtil();
        }

        /// <summary>
        /// ���ÿ�����������ܵ�
        /// </summary>
        public void ConfigureDevelopment(IApplicationBuilder app)
        {
            app.UseBrowserLink();
            app.UseDeveloperExceptionPage();
            app.UseSwaggerX();
            CommonConfig(app);
        }

        /// <summary>
        /// ������ʾ��������ܵ�
        /// </summary>
        public void ConfigureStaging(IApplicationBuilder app)
        {
            app.UseExceptionHandler("/Home/Error");
            CommonConfig(app);
        }

        /// <summary>
        /// ����������������ܵ�
        /// </summary>
        public void ConfigureProduction(IApplicationBuilder app)
        {
            app.UseExceptionHandler("/Home/Error");
            CommonConfig(app);
        }

        /// <summary>
        /// ��������
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
        /// ·������,֧������
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