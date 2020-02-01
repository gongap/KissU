using System.Text;
using KissU.Core.CPlatform.Messages;
using Newtonsoft.Json;

namespace KissU.Core.CPlatform.Transport.Codec.Implementation
{
    /// <summary>
    /// Json传输消息编码器。这个类不能被继承.
    /// Implements the <see cref="ITransportMessageEncoder" />
    /// </summary>
    /// <seealso cref="ITransportMessageEncoder" />
    public sealed class JsonTransportMessageEncoder : ITransportMessageEncoder
    {
        /// <summary>
        /// 编码指定的消息.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>System.Byte[].</returns>
        public byte[] Encode(TransportMessage message)
        {
            var content = JsonConvert.SerializeObject(message);
            return Encoding.UTF8.GetBytes(content);
        }
    }
}