using System.Threading.Tasks;
using KissU.Surging.CPlatform.Ioc;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Modules.SampleA.Service.Contracts.Dtos;

namespace KissU.Modules.SampleA.Service.Contracts
{
    /// <summary>
    /// Interface IWorkService
    /// Implements the <see cref="KissU.Surging.CPlatform.Ioc.IServiceKey" />
    /// </summary>
    /// <seealso cref="KissU.Surging.CPlatform.Ioc.IServiceKey" />
    [ServiceBundle("Background/{Service}")]
    public interface IWorkService : IServiceKey
    {
        /// <summary>
        /// Adds the work.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> AddWork(Message message);

        /// <summary>
        /// Starts the asynchronous.
        /// </summary>
        /// <returns>Task.</returns>
        Task StartAsync();

        /// <summary>
        /// Stops the asynchronous.
        /// </summary>
        /// <returns>Task.</returns>
        Task StopAsync();
    }
}