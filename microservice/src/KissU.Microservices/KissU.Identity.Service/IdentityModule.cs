using System;
using Autofac.Extensions.DependencyInjection;
using KissU.Core.Module;
using KissU.Surging.CPlatform;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace KissU.Identity.Service
{
    [DependsOn(typeof(AbpIdentityApplicationContractsModule))]
    public class IdentityModule : BusinessModule
    {
        private IAbpApplicationWithExternalServiceProvider application = null;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="moduleContext">应用模块上下文</param>
        public override void Initialize(AppModuleContext moduleContext)
        {
            base.Initialize(moduleContext);
            var serviceProvoider = moduleContext.ServiceProvoider.GetInstances<IServiceProvider>();
            application.Initialize(serviceProvoider);
        }

        /// <summary>
        /// 注册第三方组件
        /// </summary>
        /// <param name="builder">容器构建器</param>
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
            var services = new ServiceCollection();
            services.AddObjectAccessor<IdentityModule>();
            application = AbpApplicationFactory.Create<AbpIdentityApplicationModule>(services);
            services.Configure<AbpDbContextOptions>(options =>
            {
                options.Configure(abpDbContextConfigurationContext =>
                {
                    abpDbContextConfigurationContext.DbContextOptions.UseSqlServer(AppConfig
                        .GetSection("ConnectionStringSection").GetSection("ConnectionStringName").Value);
                });
            });
            builder.ContainerBuilder.Populate(services);
        }
    }
}