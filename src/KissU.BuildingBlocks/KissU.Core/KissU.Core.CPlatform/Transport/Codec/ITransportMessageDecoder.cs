using KissU.Core.CPlatform.Messages;

namespace KissU.Core.CPlatform.Transport.Codec
{
    /// <summary>
    /// Json传输消息解码器
    /// </summary>
    public interface ITransportMessageDecoder
    {
        /// <summary>
        /// 解码指定的数据.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>TransportMessage.</returns>
        TransportMessage Decode(byte[] data);
    }
}