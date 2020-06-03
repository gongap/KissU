using System;
using KissU.Abp.Autofac.Extensions.DependencyInjection;
using KissU.Core.Module;
using KissU.Surging.KestrelHttpServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;

namespace KissU.Modules.IdentityServer.Web
{
    public class IdentityServerModule : KestrelHttpModule
    {
        private IAbpApplicationWithExternalServiceProvider _application;

        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Initialize(KissU.Surging.KestrelHttpServer.ApplicationInitializationContext context)
        {
            base.Initialize(context);
            context.Builder.UseIdentityServer();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="moduleContext">应用模块上下文</param>
        public override void Initialize(AppModuleContext moduleContext)
        {
            base.Initialize(moduleContext);
            var serviceProvider = moduleContext.ServiceProvoider.GetInstances<IServiceProvider>();
            _application.Initialize(serviceProvider);
        }

        /// <summary>
        /// 注册第三方组件
        /// </summary>
        /// <param name="builder">容器构建器</param>
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
            base.RegisterBuilder(builder);
            var services = new ServiceCollection();
            _application = AbpApplicationFactory.Create<AbpIdentityServerModule>(services);
            builder.ContainerBuilder.Populate(_application.Services);
        }
    }
}