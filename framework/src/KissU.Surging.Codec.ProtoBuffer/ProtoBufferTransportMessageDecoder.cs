using KissU.Surging.Codec.ProtoBuffer.Messages;
using KissU.Surging.Codec.ProtoBuffer.Utilities;
using KissU.Surging.CPlatform.Messages;
using KissU.Surging.CPlatform.Transport.Codec;

namespace KissU.Surging.Codec.ProtoBuffer
{
    /// <summary>
    /// ProtoBufferTransportMessageDecoder. This class cannot be inherited.
    /// Implements the <see cref="KissU.Surging.CPlatform.Transport.Codec.ITransportMessageDecoder" />
    /// </summary>
    /// <seealso cref="KissU.Surging.CPlatform.Transport.Codec.ITransportMessageDecoder" />
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