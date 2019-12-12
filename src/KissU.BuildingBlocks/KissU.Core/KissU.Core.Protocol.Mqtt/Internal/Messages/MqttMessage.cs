using DotNetty.Codecs.Mqtt.Packets;
using KissU.Core.Protocol.Mqtt.Internal.Enums;

namespace KissU.Core.Protocol.Mqtt.Internal.Messages
{
   public abstract class MqttMessage
    {
        public abstract MessageType MessageType { get; }

        public virtual bool Duplicate { get; set; }
        public virtual int Qos { get; set; } =(int) QualityOfService.AtMostOnce;
        public virtual bool RetainRequested { get; set; }
        

        public override string ToString()
        {
            return $"{this.GetType().Name}[Qos={this.Qos}, Duplicate={this.Duplicate}, Retain={this.RetainRequested}]";
        }
    }
}
