using System.Text;
using System.Threading.Tasks;
using DotNetty.Buffers;
using DotNetty.Codecs.Http;
using DotNetty.Common.Utilities;
using DotNetty.Transport.Channels;
using KissU.Serialization;
using KissU.CPlatform.Messages;
using KissU.CPlatform.Transport;
using KissU.CPlatform.Transport.Codec;
using KissU.DotNetty;

namespace KissU.Protocol.Http
{
    /// <summary>
    /// DotNettyHttpServerMessageSender.
    /// Implements the <see cref="KissU.DotNetty.DotNettyMessageSender" />
    /// Implements the <see cref="KissU.CPlatform.Transport.IMessageSender" />
    /// </summary>
    /// <seealso cref="KissU.DotNetty.DotNettyMessageSender" />
    /// <seealso cref="KissU.CPlatform.Transport.IMessageSender" />
    public class DotNettyHttpServerMessageSender : DotNettyMessageSender, IMessageSender
    {
        private readonly IChannelHandlerContext _context;
        private readonly ISerializer<string> _serializer;
        private readonly AsciiString ContentLengthEntity = HttpHeaderNames.ContentLength;
        private readonly AsciiString ContentTypeEntity = HttpHeaderNames.ContentType;
        private readonly AsciiString ServerEntity = HttpHeaderNames.Server;
        private readonly AsciiString TypeJson = AsciiString.Cached("application/json");

        /// <summary>
        /// Initializes a new instance of the <see cref="DotNettyHttpServerMessageSender" /> class.
        /// </summary>
        /// <param name="transportMessageEncoder">The transport message encoder.</param>
        /// <param name="context">The context.</param>
        /// <param name="serializer">The serializer.</param>
        public DotNettyHttpServerMessageSender(ITransportMessageEncoder transportMessageEncoder,
            IChannelHandlerContext context, ISerializer<string> serializer) : base(transportMessageEncoder)
        {
            _context = context;
            _serializer = serializer;
        }

        #region Implementation of IMessageSender

        /// <summary>
        /// 发送消息。
        /// </summary>
        /// <param name="message">消息内容。</param>
        /// <returns>一个任务。</returns>
        public async Task SendAsync(TransportMessage message)
        {
            var buffer = GetByteBuffer(message, out var contentLength);
            var response = WriteResponse(_context, buffer, TypeJson, AsciiString.Cached($"{contentLength}"));
            await _context.WriteAsync(response);
        }

        /// <summary>
        /// 发送消息并清空缓冲区。
        /// </summary>
        /// <param name="message">消息内容。</param>
        /// <returns>一个任务。</returns>
        public async Task SendAndFlushAsync(TransportMessage message)
        {
            var buffer = GetByteBuffer(message, out var contentLength);
            var response = WriteResponse(_context, buffer, TypeJson, AsciiString.Cached($"{contentLength}"));

            await _context.WriteAndFlushAsync(response);
            await _context.CloseAsync();
        }

        private IByteBuffer GetByteBuffer(TransportMessage message, out int contentLength)
        {
            contentLength = 0;
            if (!message.IsHttpResultMessage())
                return null;

            var httpResultMessage = message.GetContent<HttpResultMessage>();
            var data = Encoding.UTF8.GetBytes(_serializer.Serialize(httpResultMessage));
            contentLength = data.Length;
            return Unpooled.WrappedBuffer(data);
        }

        private DefaultFullHttpResponse WriteResponse(IChannelHandlerContext ctx, IByteBuffer buf,
            ICharSequence contentType, ICharSequence contentLength)
        {
            var response = new DefaultFullHttpResponse(HttpVersion.Http11, HttpResponseStatus.OK, buf, false);
            var headers = response.Headers;
            headers.Set(ContentTypeEntity, contentType);
            headers.Set(ContentLengthEntity, contentLength);
            return response;
        }

        #endregion Implementation of IMessageSender
    }
}