using System;
using KissU.Abp.Autofac;
using KissU.Module;
using KissU.Surging.KestrelHttpServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;

namespace KissU.Modules.Account.Service
{
    public class AccountModule : KestrelHttpModule
    {
        private IAbpApplicationWithExternalServiceProvider _application;

        /// <summary>
        /// Initializes the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public override void Configure(Surging.KestrelHttpServer.ApplicationInitializationContext builder)
        {
            _application.Initialize(builder.Builder.ApplicationServices);
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            _application = context.Services.AddApplication<AbpAccountModule>();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="moduleContext">应用模块上下文</param>
        public override void Initialize(AppModuleContext moduleContext)
        {
            //var serviceProvider = moduleContext.ServiceProvoider.GetInstances<IServiceProvider>();
            //_application.Initialize(serviceProvider);
        }

        /// <summary>
        /// 注册第三方组件
        /// </summary>
        /// <param name="builder">容器构建器</param>
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
            //var services = new ServiceCollection();
            //_application = AbpApplicationFactory.Create<AbpAccountModule>(services);
            //builder.ContainerBuilder.Populate(_application.Services);
        }
    }
}