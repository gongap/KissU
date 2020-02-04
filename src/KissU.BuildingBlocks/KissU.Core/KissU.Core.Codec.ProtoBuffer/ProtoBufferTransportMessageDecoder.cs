using KissU.Core.Codec.ProtoBuffer.Messages;
using KissU.Core.Codec.ProtoBuffer.Utilities;
using KissU.Core.CPlatform.Messages;
using KissU.Core.CPlatform.Transport.Codec;

namespace KissU.Core.Codec.ProtoBuffer
{
    /// <summary>
    /// ProtoBufferTransportMessageDecoder. This class cannot be inherited.
    /// Implements the <see cref="KissU.Core.CPlatform.Transport.Codec.ITransportMessageDecoder" />
    /// </summary>
    /// <seealso cref="KissU.Core.CPlatform.Transport.Codec.ITransportMessageDecoder" />
    public sealed class ProtoBufferTransportMessageDecoder : ITransportMessageDecoder
    {
        #region Implementation of ITransportMessageDecoder

        /// <summary>
        /// Decodes the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>TransportMessage.</returns>
        public TransportMessage Decode(byte[] data)
        {
            var message = SerializerUtilitys.Deserialize<ProtoBufferTransportMessage>(data);
            return message.GetTransportMessage();
        }

        #endregion Implementation of ITransportMessageDecoder
    }
}