using System.Threading.Tasks;
using KissU.Modules.IdentityServer.Domain.Clients;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;

namespace KissU.Modules.IdentityServer.Domain
{
    public class AllowedCorsOriginsCacheItemInvalidator : 
        ILocalEventHandler<EntityChangedEventData<Client>>,
        ILocalEventHandler<EntityChangedEventData<ClientCorsOrigin>>,
        ITransientDependency
    {
        protected IDistributedCache<AllowedCorsOriginsCacheItem> Cache { get; }

        public AllowedCorsOriginsCacheItemInvalidator(IDistributedCache<AllowedCorsOriginsCacheItem> cache)
        {
            Cache = cache;
        }
        
        public virtual async Task HandleEventAsync(EntityChangedEventData<Client> eventData)
        {
            await Cache.RemoveAsync(AllowedCorsOriginsCacheItem.AllOrigins);
        }

        public virtual async Task HandleEventAsync(EntityChangedEventData<ClientCorsOrigin> eventData)
        {
            await Cache.RemoveAsync(AllowedCorsOriginsCacheItem.AllOrigins);
        }
    }
}