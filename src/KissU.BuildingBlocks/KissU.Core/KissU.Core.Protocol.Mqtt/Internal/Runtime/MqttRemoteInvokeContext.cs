using KissU.Core.CPlatform.Runtime.Client;

namespace KissU.Core.Protocol.Mqtt.Internal.Runtime
{
    /// <summary>
    /// MqttRemoteInvokeContext.
    /// Implements the <see cref="KissU.Core.CPlatform.Runtime.Client.RemoteInvokeContext" />
    /// </summary>
    /// <seealso cref="KissU.Core.CPlatform.Runtime.Client.RemoteInvokeContext" />
    public class MqttRemoteInvokeContext : RemoteInvokeContext
    {
        /// <summary>
        /// Gets or sets the topic.
        /// </summary>
        public string topic { get; set; }
    }
}