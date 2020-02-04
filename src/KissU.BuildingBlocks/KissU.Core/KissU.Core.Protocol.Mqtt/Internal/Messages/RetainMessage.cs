using System.Text;

namespace KissU.Core.Protocol.Mqtt.Internal.Messages
{
    /// <summary>
    /// RetainMessage.
    /// </summary>
    public class RetainMessage
    {
        /// <summary>
        /// Gets or sets the byte buf.
        /// </summary>
        public byte[] ByteBuf { get; set; }

        /// <summary>
        /// Gets or sets the qo s.
        /// </summary>
        public int QoS { get; set; }

        /// <summary>
        /// Converts to string.
        /// </summary>
        public new string ToString => Encoding.UTF8.GetString(ByteBuf);
    }
}