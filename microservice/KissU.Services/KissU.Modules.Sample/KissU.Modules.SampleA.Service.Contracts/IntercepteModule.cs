using KissU.Module;
using KissU.Surging.Caching.Interceptors;
using KissU.Surging.ProxyGenerator;
using KissU.Surging.ProxyGenerator.Interceptors;

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
        protected override void ConfigureContainer(ContainerBuilderWrapper builder)
        {
            base.ConfigureContainer(builder);
            builder.AddClientIntercepted(typeof(CacheProviderInterceptor));
            builder.AddClientIntercepted(typeof(LogProviderInterceptor));
        }
    }
}