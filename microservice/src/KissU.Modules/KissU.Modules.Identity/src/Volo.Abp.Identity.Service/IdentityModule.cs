using System;
using Autofac.Extensions.DependencyInjection;
using KissU.Core.Module;
using Microsoft.Extensions.DependencyInjection;

namespace Volo.Abp.Identity.Service
{
    public class IdentityModule : BusinessModule
    {
        private IAbpApplicationWithExternalServiceProvider application;

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
            builder.ContainerBuilder.Populate(services);
        }
    }
}