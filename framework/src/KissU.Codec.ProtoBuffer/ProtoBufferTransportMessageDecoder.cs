using KissU.Codec.ProtoBuffer.Messages;
using KissU.Codec.ProtoBuffer.Utilities;
using KissU.CPlatform.Messages;
using KissU.CPlatform.Transport.Codec;

namespace KissU.Codec.ProtoBuffer
{
    /// <summary>
    /// ProtoBufferTransportMessageDecoder. This class cannot be inherited.
    /// Implements the <see cref="KissU.CPlatform.Transport.Codec.ITransportMessageDecoder" />
    /// </summary>
    /// <seealso cref="KissU.CPlatform.Transport.Codec.ITransportMessageDecoder" />
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