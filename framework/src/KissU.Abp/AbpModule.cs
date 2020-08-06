using System;
using KissU.Helpers;
using KissU.Modularity;
using KissU.CPlatform;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Modularity.PlugIns;

namespace KissU.Abp
{
    public class AbpModule : EnginePartModule
    {
        private IAbpApplicationWithExternalServiceProvider _application;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="moduleContext">应用模块上下文</param>
        public override void Initialize(ModuleInitializationContext moduleContext)
        {
            var serviceProvider = moduleContext.ServiceProvoider.GetInstances<IServiceProvider>();
            _application.Initialize(serviceProvider);
        }

        /// <summary>
        /// 注册第三方组件
        /// </summary>
        /// <param name="builder">容器构建器</param>
        protected override void ConfigureContainer(ContainerBuilderWrapper builder)
        {
            base.ConfigureContainer(builder);
            var services = new ServiceCollection();
            _application = AbpApplicationFactory.Create<AbpStartupModule>(services, options =>
            {
                var assemblies = ModuleHelper.GetAssemblies();
                var moduleTypes = ReflectionHelper.FindTypes<IAbpServiceModule>(assemblies.ToArray());
                options.PlugInSources.AddTypes(moduleTypes.ToArray());
            });
            builder.ContainerBuilder.Populate(_application.Services);
        }
    }
}