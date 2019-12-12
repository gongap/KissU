using System.Text;
using KissU.Core.CPlatform.Messages;
using Newtonsoft.Json;

namespace KissU.Core.CPlatform.Transport.Codec.Implementation
{
    public sealed class JsonTransportMessageDecoder : ITransportMessageDecoder
    {
        #region Implementation of ITransportMessageDecoder

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

        #endregion Implementation of ITransportMessageDecoder
    }
}