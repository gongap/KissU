using KissU.Modularity;
using KissU.Caching.Interceptors;
using KissU.ProxyGenerator;
using KissU.ProxyGenerator.Interceptors;

namespace KissU.Modules.SampleA.Service.Contracts
{
    public class IntercepteModule : SystemModule
    {
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