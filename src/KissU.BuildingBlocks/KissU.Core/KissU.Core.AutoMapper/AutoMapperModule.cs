using KissU.Core.AutoMapper.AutoMapper;
using KissU.Core.CPlatform.Module;
using Microsoft.Extensions.Configuration;
using CPlatformAppConfig = KissU.Core.CPlatform.AppConfig;

namespace KissU.Core.AutoMapper
{
    public class AutoMapperModule : EnginePartModule
    {

        public override void Initialize(AppModuleContext context)
        {
            base.Initialize(context);
            context.ServiceProvoider.GetInstances<IAutoMapperBootstrap>().Initialize();
        }

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
