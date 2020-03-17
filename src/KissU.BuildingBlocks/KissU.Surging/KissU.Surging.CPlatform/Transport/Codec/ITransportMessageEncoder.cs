using KissU.Surging.CPlatform.Messages;

namespace KissU.Surging.CPlatform.Transport.Codec
{
    /// <summary>
    /// Json传输消息编码器
    /// </summary>
    public interface ITransportMessageEncoder
    {
        /// <summary>
        /// 编码指定的消息.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>System.Byte[].</returns>
        byte[] Encode(TransportMessage message);
    }
}