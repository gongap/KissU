using KissU.Modularity;
using KissU.Surging.Caching.Interceptors;
using KissU.Surging.ProxyGenerator;
using KissU.Surging.ProxyGenerator.Interceptors;

namespace KissU.Services.SampleA.Contract
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