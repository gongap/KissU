using System;
using KissU.Abp.Autofac;
using KissU.Abp.Autofac.Extensions;
using KissU.Module;
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
            _application.Initialize(context.Builder.ApplicationServices);
        }

        /// <summary>
        /// Registers the builder.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void RegisterBuilder(ConfigurationContext context)
        {
            base.RegisterBuilder(context);
            _application = AbpApplicationFactory.Create<AbpIdentityServerModule>(context.Services);
           var containerBuilder = context.Services.GetContainerBuilder();
           containerBuilder.Populate(context.Services);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="moduleContext">应用模块上下文</param>
        public override void Initialize(AppModuleContext moduleContext)
        {
            base.Initialize(moduleContext);
            //var serviceProvider = moduleContext.ServiceProvoider.GetInstances<IServiceProvider>();
            //_application.Initialize(serviceProvider);
        }

        /// <summary>
        /// 注册第三方组件
        /// </summary>
        /// <param name="builder">容器构建器</param>
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
            base.RegisterBuilder(builder);
            //var services = new ServiceCollection();
            //_application = AbpApplicationFactory.Create<AbpIdentityServerModule>(services);
            //builder.ContainerBuilder.Populate(_application.Services);
        }
    }
}