using System;
using KissU.Abp.Autofac;
using KissU.Modularity;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;

namespace KissU.Modules.TenantManagement.Service
{
    public class TenantManagementModule : BusinessModule
    {
        private IAbpApplicationWithExternalServiceProvider _application;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="context">应用模块上下文</param>
        public override void Initialize(ModuleInitializationContext context)
        {
            var serviceProvider = context.ServiceProvoider.GetInstances<IServiceProvider>();
            _application.Initialize(serviceProvider);
        }

        /// <summary>
        /// 注册第三方组件
        /// </summary>
        /// <param name="builder">容器构建器</param>
        protected override void ConfigureContainer(ContainerBuilderWrapper builder)
        {
            var services = new ServiceCollection();
            _application = AbpApplicationFactory.Create<AbpTenantManagementModule>(services);
            builder.ContainerBuilder.Populate(_application.Services);
        }
    }
}