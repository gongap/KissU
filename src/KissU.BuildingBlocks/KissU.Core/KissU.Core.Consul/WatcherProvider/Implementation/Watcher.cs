using System.Threading.Tasks;

namespace KissU.Core.Consul.WatcherProvider.Implementation
{
    public abstract class Watcher
    {
        protected Watcher()
        {
        }
        
        public abstract Task Process();

        public static class Event
        {
            public enum KeeperState
            {
                Disconnected = 0,
                SyncConnected = 3,
            }
        }
    }
}
