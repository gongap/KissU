using System.Threading;
using System.Threading.Tasks;
using KissU.Surging.CPlatform.Messages;

namespace KissU.Surging.CPlatform.Transport
{
    /// <summary>
    /// 一个抽象的传输客户端。
    /// </summary>
    public interface ITransportClient
    {
        /// <summary>
        /// 发送消息。
        /// </summary>
        /// <param name="message">远程调用消息模型。</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>远程调用消息的传输消息。</returns>
        Task<RemoteInvokeResultMessage> SendAsync(RemoteInvokeMessage message, CancellationToken cancellationToken);
    }
}