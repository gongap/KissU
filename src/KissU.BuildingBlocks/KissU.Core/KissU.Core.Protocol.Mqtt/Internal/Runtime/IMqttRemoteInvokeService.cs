using System.Threading;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Runtime.Client;

namespace KissU.Core.Protocol.Mqtt.Internal.Runtime
{
    public interface IMqttRemoteInvokeService
    {
      
        Task InvokeAsync(RemoteInvokeContext context);
        
        Task InvokeAsync(RemoteInvokeContext context, CancellationToken cancellationToken);
        
        Task InvokeAsync(RemoteInvokeContext context, int requestTimeout);
    }
}
