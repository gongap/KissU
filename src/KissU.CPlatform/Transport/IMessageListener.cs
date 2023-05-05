using System.Net;
using System.Threading.Tasks;
using KissU.CPlatform.Messages;

namespace KissU.CPlatform.Transport
{
    /// <summary>
    /// 接受到消息的委托。
    /// </summary>
    /// <param name="sender">消息发送者。</param>
    /// <param name="message">接收到的消息。</param>
    /// <returns>Task.</returns>
    public delegate Task ReceivedDelegate(IMessageSender sender, TransportMessage message);

    /// <summary>
    /// 新的客户端连接
    /// </summary>
    /// <param name="remoteAddress">远程地址</param>
    public delegate void NewClientAcceptHandler(EndPoint remoteAddress);

    /// <summary>
    /// 一个抽象的消息监听者。
    /// </summary>
    public interface IMessageListener
    {
        /// <summary>
        /// 接收到消息的事件。
        /// </summary>
        event ReceivedDelegate Received;

        /// <summary>
        /// 新的客户端连接事件
        /// </summary>
        event NewClientAcceptHandler NewClientAccepted;

        /// <summary>
        /// 触发接收到消息事件。
        /// </summary>
        /// <param name="sender">消息发送者。</param>
        /// <param name="message">接收到的消息。</param>
        /// <returns>一个任务。</returns>
        Task OnReceived(IMessageSender sender, TransportMessage message);

        /// <summary>
        /// 触发新的客户端连接事件。
        /// </summary>
        /// <param name="remoteAddress">远程地址</param>
        void OnNewClientAccepted(EndPoint remoteAddress);
    }
}
