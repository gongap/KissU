using System.Threading;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Runtime.Client;

namespace KissU.Core.Protocol.Mqtt.Internal.Runtime
{
    /// <summary>
    /// Interface IMqttRemoteInvokeService
    /// </summary>
    public interface IMqttRemoteInvokeService
    {
        /// <summary>
        /// Invokes the asynchronous.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Task.</returns>
        Task InvokeAsync(RemoteInvokeContext context);

        /// <summary>
        /// Invokes the asynchronous.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        Task InvokeAsync(RemoteInvokeContext context, CancellationToken cancellationToken);

        /// <summary>
        /// Invokes the asynchronous.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="requestTimeout">The request timeout.</param>
        /// <returns>Task.</returns>
        Task InvokeAsync(RemoteInvokeContext context, int requestTimeout);
    }
}