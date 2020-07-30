using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Services.SampleA.Contract.Dtos;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace KissU.Services.SampleA.Contract
{
    /// <summary>
    /// Interface IWorkService
    /// Implements the <see cref="IServiceKey" />
    /// </summary>
    /// <seealso cref="IServiceKey" />
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