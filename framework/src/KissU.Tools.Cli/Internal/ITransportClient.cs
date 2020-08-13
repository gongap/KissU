using System.Threading;
using System.Threading.Tasks;
using KissU.CPlatform.Messages;

namespace KissU.Tools.Cli.Internal
{
  public  interface ITransportClient
    {
        Task<RemoteInvokeResultMessage> SendAsync(CancellationToken cancellationToken);
    }
}
