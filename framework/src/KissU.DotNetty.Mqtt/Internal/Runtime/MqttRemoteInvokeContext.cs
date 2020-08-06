using KissU.CPlatform.Runtime.Client;

namespace KissU.DotNetty.Mqtt.Internal.Runtime
{
    /// <summary>
    /// MqttRemoteInvokeContext.
    /// Implements the <see cref="KissU.CPlatform.Runtime.Client.RemoteInvokeContext" />
    /// </summary>
    /// <seealso cref="KissU.CPlatform.Runtime.Client.RemoteInvokeContext" />
    public class MqttRemoteInvokeContext : RemoteInvokeContext
    {
        /// <summary>
        /// Gets or sets the topic.
        /// </summary>
        public string topic { get; set; }
    }
}