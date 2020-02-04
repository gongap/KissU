using System.Threading.Tasks;
using DotNetty.Buffers;
using DotNetty.Transport.Channels;
using KissU.Core.CPlatform.Messages;
using KissU.Core.CPlatform.Transport;
using KissU.Core.CPlatform.Transport.Codec;

namespace KissU.Core.Protocol.Udp
{
    /// <summary>
    /// DotNettyUdpMessageSender.
    /// </summary>
    public abstract class DotNettyUdpMessageSender
    {
        private readonly ITransportMessageEncoder _transportMessageEncoder;

        /// <summary>
        /// Initializes a new instance of the <see cref="DotNettyUdpMessageSender"/> class.
        /// </summary>
        /// <param name="transportMessageEncoder">The transport message encoder.</param>
        protected DotNettyUdpMessageSender(ITransportMessageEncoder transportMessageEncoder)
        {
            _transportMessageEncoder = transportMessageEncoder;
        }

        /// <summary>
        /// Gets the byte buffer.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>IByteBuffer.</returns>
        protected IByteBuffer GetByteBuffer(TransportMessage message)
        {
            var data =  message.GetContent<byte []>(); 
            return Unpooled.WrappedBuffer(data);
        }
    }

    /// <summary>
    /// 基于DotNetty服务端的消息发送者。
    /// </summary>
    public class DotNettyUdpServerMessageSender : DotNettyUdpMessageSender, IMessageSender
    {
        private readonly IChannelHandlerContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="DotNettyUdpServerMessageSender"/> class.
        /// </summary>
        /// <param name="transportMessageEncoder">The transport message encoder.</param>
        /// <param name="context">The context.</param>
        public DotNettyUdpServerMessageSender(ITransportMessageEncoder transportMessageEncoder, IChannelHandlerContext context) : base(transportMessageEncoder)
        {
            _context = context;
        }

        #region Implementation of IMessageSender

        /// <summary>
        /// 发送消息。
        /// </summary>
        /// <param name="message">消息内容。</param>
        /// <returns>一个任务。</returns>
        public async Task SendAsync(TransportMessage message)
        {
            var buffer = GetByteBuffer(message);
            await _context.WriteAsync(buffer);
        }

        /// <summary>
        /// 发送消息并清空缓冲区。
        /// </summary>
        /// <param name="message">消息内容。</param>
        /// <returns>一个任务。</returns>
        public async Task SendAndFlushAsync(TransportMessage message)
        {
            var buffer = GetByteBuffer(message);
            if( _context.Channel.RemoteAddress !=null)
            await _context.WriteAndFlushAsync(buffer);
        }

        #endregion Implementation of IMessageSender
    }
}
