using System.Runtime.CompilerServices;
using KissU.Core.Codec.MessagePack.Messages;
using KissU.Core.Codec.MessagePack.Utilities;
using KissU.Core.CPlatform.Messages;
using KissU.Core.CPlatform.Transport.Codec;

namespace KissU.Core.Codec.MessagePack
{
    /// <summary>
    /// MessagePackTransportMessageDecoder. This class cannot be inherited.
    /// Implements the <see cref="KissU.Core.CPlatform.Transport.Codec.ITransportMessageDecoder" />
    /// </summary>
    /// <seealso cref="KissU.Core.CPlatform.Transport.Codec.ITransportMessageDecoder" />
    public sealed class MessagePackTransportMessageDecoder : ITransportMessageDecoder
    {
        #region Implementation of ITransportMessageDecoder

        /// <summary>
        /// Decodes the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>TransportMessage.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TransportMessage Decode(byte[] data)
        {
            var message = SerializerUtilitys.Deserialize<MessagePackTransportMessage>(data);
            return message.GetTransportMessage();
        }

        #endregion Implementation of ITransportMessageDecoder
    }
}