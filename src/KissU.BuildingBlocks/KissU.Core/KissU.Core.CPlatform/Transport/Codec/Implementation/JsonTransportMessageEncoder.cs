using System.Text;
using KissU.Core.CPlatform.Messages;
using Newtonsoft.Json;

namespace KissU.Core.CPlatform.Transport.Codec.Implementation
{
    public sealed class JsonTransportMessageEncoder : ITransportMessageEncoder
    {
        #region Implementation of ITransportMessageEncoder

        public byte[] Encode(TransportMessage message)
        {
            var content = JsonConvert.SerializeObject(message);
            return Encoding.UTF8.GetBytes(content);
        }

        #endregion Implementation of ITransportMessageEncoder
    }
}