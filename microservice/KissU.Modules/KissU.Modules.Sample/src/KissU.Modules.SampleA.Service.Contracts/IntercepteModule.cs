using KissU.Core.Module;
using KissU.Surging.ProxyGenerator;
using KissU.Surging.System.Intercept;

namespace KissU.Modules.SampleA.Service.Contracts
{
    public class IntercepteModule : SystemModule
    {
        public override void Initialize(AppModuleContext context)
        {
            base.Initialize(context);
        }

        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder"></param>
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
            base.RegisterBuilder(builder);
            builder.AddClientIntercepted(typeof(CacheProviderInterceptor));
            builder.AddClientIntercepted(typeof(LogProviderInterceptor));
        }
    }
}