using KissU.DotNetty.Mqtt.Internal.Services;

namespace KissU.DotNetty.Mqtt.Internal.Runtime
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