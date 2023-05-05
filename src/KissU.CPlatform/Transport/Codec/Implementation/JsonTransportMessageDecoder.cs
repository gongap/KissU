using System.Text;
using KissU.CPlatform.Messages;
using Newtonsoft.Json;

namespace KissU.CPlatform.Transport.Codec.Implementation
{
    /// <summary>
    /// Json传输消息解码器。这个类不能被继承.
    /// Implements the <see cref="ITransportMessageDecoder" />
    /// </summary>
    /// <seealso cref="ITransportMessageDecoder" />
    public sealed class JsonTransportMessageDecoder : ITransportMessageDecoder
    {
        /// <summary>
        /// 解码指定的数据.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>TransportMessage.</returns>
        public TransportMessage Decode(byte[] data)
        {
            var content = Encoding.UTF8.GetString(data);
            var message = JsonConvert.DeserializeObject<TransportMessage>(content);
            if (message.IsInvokeMessage())
            {
                message.Content = JsonConvert.DeserializeObject<RemoteInvokeMessage>(message.Content.ToString());
            }

            if (message.IsInvokeResultMessage())
            {
                message.Content = JsonConvert.DeserializeObject<RemoteInvokeResultMessage>(message.Content.ToString());
            }

            return message;
        }
    }
}