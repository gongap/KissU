using KissU.Surging.Protocol.Mqtt.Internal.Services;

namespace KissU.Surging.Protocol.Mqtt.Internal.Runtime
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