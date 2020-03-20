using KissU.Core.Module;
using KissU.Surging.AutoMapper.AutoMapper;
using KissU.Surging.CPlatform.Module;
using Microsoft.Extensions.Configuration;
using CPlatformAppConfig = KissU.Surging.CPlatform.AppConfig;

namespace KissU.Surging.AutoMapper
{
    /// <summary>
    /// AutoMapperModule.
    /// Implements the <see cref="EnginePartModule" />
    /// </summary>
    /// <seealso cref="EnginePartModule" />
    public class AutoMapperModule : EnginePartModule
    {
        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Initialize(AppModuleContext context)
        {
            base.Initialize(context);
            context.ServiceProvoider.GetInstances<IAutoMapperBootstrap>().Initialize();
        }

        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="builder">构建器包装</param>
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
            var configAssembliesStr = CPlatformAppConfig.GetSection("Automapper:Assemblies").Get<string>();
            if (!string.IsNullOrEmpty(configAssembliesStr))
            {
                AppConfig.AssembliesStrings = configAssembliesStr.Split(";");
            }

            builder.RegisterType<AutoMapperBootstrap>().As<IAutoMapperBootstrap>();
        }
    }
}