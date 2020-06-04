using DotNetty.Buffers;
using DotNetty.Common.Utilities;
using DotNetty.Transport.Channels;
using KissU.Surging.CPlatform.Transport.Codec;

namespace KissU.Surging.DotNetty.Adapter
{
    /// <summary>
    /// TransportMessageChannelHandlerAdapter.
    /// Implements the <see cref="ChannelHandlerAdapter" />
    /// </summary>
    /// <seealso cref="ChannelHandlerAdapter" />
    internal class TransportMessageChannelHandlerAdapter : ChannelHandlerAdapter
    {
        private readonly ITransportMessageDecoder _transportMessageDecoder;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportMessageChannelHandlerAdapter" /> class.
        /// </summary>
        /// <param name="transportMessageDecoder">The transport message decoder.</param>
        public TransportMessageChannelHandlerAdapter(ITransportMessageDecoder transportMessageDecoder)
        {
            _transportMessageDecoder = transportMessageDecoder;
        }

        #region Overrides of ChannelHandlerAdapter

        /// <summary>
        /// Channels the read.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="message">The message.</param>
        public override void ChannelRead(IChannelHandlerContext context, object message)
        {
            var buffer = (IByteBuffer) message;
            var data = new byte[buffer.ReadableBytes];
            buffer.ReadBytes(data);
            var transportMessage = _transportMessageDecoder.Decode(data);
            context.FireChannelRead(transportMessage);
            ReferenceCountUtil.Release(buffer);
        }

        #endregion Overrides of ChannelHandlerAdapter
    }
}