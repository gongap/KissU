using KissU.Surging.CPlatform.Runtime.Client;

namespace KissU.Surging.Protocol.Mqtt.Internal.Runtime
{
    /// <summary>
    /// MqttRemoteInvokeContext.
    /// Implements the <see cref="KissU.Surging.CPlatform.Runtime.Client.RemoteInvokeContext" />
    /// </summary>
    /// <seealso cref="KissU.Surging.CPlatform.Runtime.Client.RemoteInvokeContext" />
    public class MqttRemoteInvokeContext : RemoteInvokeContext
    {
        /// <summary>
        /// Gets or sets the topic.
        /// </summary>
        public string topic { get; set; }
    }
}