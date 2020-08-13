using System.Net;
using System.Threading.Tasks;

namespace KissU.Tools.Cli.Internal
{
    public interface ITransportClientFactory
    {

        Task<ITransportClient> CreateClientAsync(EndPoint endPoint);
    }
}
