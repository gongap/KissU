using KissU.Core.Protocol.Mqtt.Internal.Services;

namespace KissU.Core.Protocol.Mqtt.Internal.Runtime
{
   public interface IMqttBehaviorProvider
    {
        MqttBehavior GetMqttBehavior();
    }
}
