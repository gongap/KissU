using System.Threading.Tasks;
using KissU.CPlatform.Messages;

namespace KissU.CPlatform.Ioc
{
    public delegate Task ServerReceivedDelegate(TransportMessage message);

    /// <summary>
    /// 服务行为
    /// </summary>
    public interface IServiceBehavior
    {
        public string MessageId { get; }
        event ServerReceivedDelegate Received;
    }
}