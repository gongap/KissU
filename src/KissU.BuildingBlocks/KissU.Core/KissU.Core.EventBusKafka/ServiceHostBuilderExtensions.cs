using Autofac;
using KissU.Core.CPlatform.EventBus;
using KissU.Core.ServiceHosting.Internal;

namespace KissU.Core.EventBusKafka
{
   public static  class ServiceHostBuilderExtensions
    {
        public static IServiceHostBuilder SubscribeAt(this IServiceHostBuilder hostBuilder)
        {
            return hostBuilder.MapServices(mapper =>
            {
                mapper.Resolve<ISubscriptionAdapt>().SubscribeAt();
            });
        }
    }
}
