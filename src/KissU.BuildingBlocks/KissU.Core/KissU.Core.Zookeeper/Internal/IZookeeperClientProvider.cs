using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using org.apache.zookeeper;

namespace KissU.Core.Zookeeper.Internal
{
   public interface IZookeeperClientProvider
    {
        ValueTask<(ManualResetEvent, ZooKeeper)> GetZooKeeper();

        ValueTask<IEnumerable<(ManualResetEvent, ZooKeeper)>> GetZooKeepers();

        ValueTask Check();
    }
}
