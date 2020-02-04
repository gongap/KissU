using DotNetty.Codecs.Mqtt.Packets;
using KissU.Core.Protocol.Mqtt.Internal.Enums;

namespace KissU.Core.Protocol.Mqtt.Internal.Messages
{
    /// <summary>
    /// MqttMessage.
    /// </summary>
    public abstract class MqttMessage
    {
        /// <summary>
        /// Gets the type of the message.
        /// </summary>
        public abstract MessageType MessageType { get; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="MqttMessage"/> is duplicate.
        /// </summary>
        public virtual bool Duplicate { get; set; }
        /// <summary>
        /// Gets or sets the qos.
        /// </summary>
        public virtual int Qos { get; set; } =(int) QualityOfService.AtMostOnce;
        /// <summary>
        /// Gets or sets a value indicating whether [retain requested].
        /// </summary>
        public virtual bool RetainRequested { get; set; }


        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return $"{this.GetType().Name}[Qos={this.Qos}, Duplicate={this.Duplicate}, Retain={this.RetainRequested}]";
        }
    }
}
