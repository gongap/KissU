using System.Threading.Tasks;

namespace KissU.Core.Consul.WatcherProvider.Implementation
{
    public abstract class WatcherBase : Watcher
    {

        protected WatcherBase()
        {
         
        }
        
        public override async Task Process()
        {
                await ProcessImpl();
        }

        protected abstract Task ProcessImpl();
    }
}
