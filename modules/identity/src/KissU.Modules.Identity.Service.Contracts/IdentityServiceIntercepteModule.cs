using KissU.Caching.Interceptors;
using KissU.Modularity;
using KissU.ServiceProxy;

namespace Hrst.Spark.Modules.Identity.Service.Contracts
{
    public class IdentityServiceIntercepteModule : SystemModule
    {
        /// <summary>
        /// Configures the container.
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void ConfigureContainer(ContainerBuilderWrapper builder)
        {
            builder.AddClientIntercepted(typeof(CacheProviderInterceptor));
        }
    }
}