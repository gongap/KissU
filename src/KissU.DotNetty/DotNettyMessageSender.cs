using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using DotNetty.Buffers;
using DotNetty.Transport.Channels;
using KissU.CPlatform.Diagnostics;
using KissU.CPlatform.Messages;
using KissU.CPlatform.Transport;
using KissU.CPlatform.Transport.Codec;

namespace KissU.DotNetty
{
    /// <summary>
    /// 基于DotNetty的消息发送者基类。
    /// </summary>
    public abstract class DotNettyMessageSender
    {
        private readonly ITransportMessageEncoder _transportMessageEncoder;

        /// <summary>
        /// Initializes a new instance of the <see cref="DotNettyMessageSender" /> class.
        /// </summary>
        /// <param name="transportMessageEncoder">The transport message encoder.</param>
        protected DotNettyMessageSender(ITransportMessageEncoder transportMessageEncoder)
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
            var data = _transportMessageEncoder.Encode(message);
            //var buffer = PooledByteBufferAllocator.Default.Buffer();
            return Unpooled.WrappedBuffer(data);
        }
    }

    /// <summary>
    /// 基于DotNetty客户端的消息发送者。
    /// </summary>
    public class DotNettyMessageClientSender : DotNettyMessageSender, IMessageSender, IDisposable
    {
        private readonly IChannel _channel;

        public EndPoint RemoteAddress => _channel.RemoteAddress;

        /// <summary>
        /// Initializes a new instance of the <see cref="DotNettyMessageClientSender" /> class.
        /// </summary>
        /// <param name="transportMessageEncoder">The transport message encoder.</param>
        /// <param name="channel">The channel.</param>
        public DotNettyMessageClientSender(ITransportMessageEncoder transportMessageEncoder, IChannel channel) : base(
            transportMessageEncoder)
        {
            _channel = channel;
        }

        #region Implementation of IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Task.Run(async () => { await _channel.DisconnectAsync(); }).Wait();
        }

        #endregion Implementation of IDisposable

        #region Implementation of IMessageSender

        /// <summary>
        /// 发送消息。
        /// </summary>
        /// <param name="message">消息内容。</param>
        /// <returns>一个任务。</returns>
        public async Task SendAsync(TransportMessage message)
        {
            var buffer = GetByteBuffer(message);
            await _channel.WriteAndFlushAsync(buffer);
        }

        /// <summary>
        /// 发送消息并清空缓冲区。
        /// </summary>
        /// <param name="message">消息内容。</param>
        /// <returns>一个任务。</returns>
        public async Task SendAndFlushAsync(TransportMessage message)
        {
            var buffer = GetByteBuffer(message);
            await _channel.WriteAndFlushAsync(buffer);
        }

        #endregion Implementation of IMessageSender
    }

    /// <summary>
    /// 基于DotNetty服务端的消息发送者。
    /// </summary>
    public class DotNettyServerMessageSender : DotNettyMessageSender, IMessageSender
    {
        private readonly IChannelHandlerContext _context;
        private readonly DiagnosticListener _diagnosticListener;

        public EndPoint RemoteAddress => _context.Channel.RemoteAddress;

        /// <summary>
        /// Initializes a new instance of the <see cref="DotNettyServerMessageSender" /> class.
        /// </summary>
        /// <param name="transportMessageEncoder">The transport message encoder.</param>
        /// <param name="context">The context.</param>
        public DotNettyServerMessageSender(ITransportMessageEncoder transportMessageEncoder,
            IChannelHandlerContext context) : base(transportMessageEncoder)
        {
            _context = context;
            _diagnosticListener = new DiagnosticListener(string.Format(DiagnosticListenerExtensions.DiagnosticListenerName, TransportType.Rpc));
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
            WirteDiagnostic(message);
        }

        /// <summary>
        /// 发送消息并清空缓冲区。
        /// </summary>
        /// <param name="message">消息内容。</param>
        /// <returns>一个任务。</returns>
        public async Task SendAndFlushAsync(TransportMessage message)
        {
            var buffer = GetByteBuffer(message);
            await _context.WriteAndFlushAsync(buffer);
            WirteDiagnostic(message);
        }

        #endregion Implementation of IMessageSender

        private void WirteDiagnostic(TransportMessage message)
        {
            if (!CPlatform.AppConfig.ServerOptions.DisableDiagnostic)
            {
                var remoteInvokeResultMessage = message.GetContent<RemoteInvokeResultMessage>();
                if (remoteInvokeResultMessage.StatusCode == 200)
                {
                    _diagnosticListener.WriteTransportAfter(TransportType.Rpc, new ReceiveEventData(new DiagnosticMessage
                    {
                        Content = message.Content,
                        ContentType = message.ContentType,
                        Id = message.Id
                    }));
                }
                else
                {
                    _diagnosticListener.WriteTransportError(TransportType.Rpc, new TransportErrorEventData(new DiagnosticMessage
                    {
                        Content = message.Content,
                        ContentType = message.ContentType,
                        Id = message.Id
                    }, new Exception(remoteInvokeResultMessage.Message)));
                }
            }
        }
    }
}