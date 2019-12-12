using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Messages;

namespace KissU.Core.CPlatform.Support
{
    public interface IBreakeRemoteInvokeService
    {
        Task<RemoteInvokeResultMessage> InvokeAsync(IDictionary<string, object> parameters, string serviceId, string _serviceKey, bool decodeJOject);
    }
}
