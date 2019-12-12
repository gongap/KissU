using DotNetty.Transport.Channels;
using KissU.Core.Protocol.Mqtt.Internal.Enums;

namespace KissU.Core.Protocol.Mqtt.Internal.Messages
{
   public class SendMqttMessage
    {
        public int MessageId { get; set; }

        public IChannel Channel { get; set; }

        public  ConfirmStatus ConfirmStatus { get; set; }

        public long Time { get; set; }

        public byte[] ByteBuf { get; set; }

        public bool Retain { get; set; }

        public int Qos { get; set; }

        public string Topic { get; set; }
    }
}
