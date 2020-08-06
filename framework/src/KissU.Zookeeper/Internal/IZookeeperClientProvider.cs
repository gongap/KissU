using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using org.apache.zookeeper;

namespace KissU.Zookeeper.Internal
{
    /// <summary>
    /// Interface IZookeeperClientProvider
    /// </summary>
    public interface IZookeeperClientProvider
    {
        /// <summary>
        /// Gets the zoo keeper.
        /// </summary>
        /// <returns>ValueTask&lt;System.ValueTuple&lt;ManualResetEvent, ZooKeeper&gt;&gt;.</returns>
        ValueTask<(ManualResetEvent, ZooKeeper)> GetZooKeeper();

        /// <summary>
        /// Gets the zoo keepers.
        /// </summary>
        /// <returns>ValueTask&lt;IEnumerable&lt;System.ValueTuple&lt;ManualResetEvent, ZooKeeper&gt;&gt;&gt;.</returns>
        ValueTask<IEnumerable<(ManualResetEvent, ZooKeeper)>> GetZooKeepers();

        /// <summary>
        /// Checks this instance.
        /// </summary>
        /// <returns>ValueTask.</returns>
        ValueTask Check();
    }
}