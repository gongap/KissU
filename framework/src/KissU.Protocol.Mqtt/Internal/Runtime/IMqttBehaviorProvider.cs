using KissU.Protocol.Mqtt.Internal.Services;

namespace KissU.Protocol.Mqtt.Internal.Runtime
{
    /// <summary>
    /// Interface IMqttBehaviorProvider
    /// </summary>
    public interface IMqttBehaviorProvider
    {
        /// <summary>
        /// Gets the MQTT behavior.
        /// </summary>
        /// <returns>MqttBehavior.</returns>
        MqttBehavior GetMqttBehavior();
    }
}