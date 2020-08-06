using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Protocol.Mqtt.Internal.Messages;
using KissU.Protocol.Mqtt.Internal.Services;

namespace KissU.Protocol.Mqtt.Internal.Runtime.Implementation
{
    /// <summary>
    /// MqttRomtePublishService.
    /// Implements the <see cref="ServiceBase" />
    /// Implements the <see cref="KissU.Protocol.Mqtt.Internal.Runtime.IMqttRomtePublishService" />
    /// </summary>
    /// <seealso cref="ServiceBase" />
    /// <seealso cref="KissU.Protocol.Mqtt.Internal.Runtime.IMqttRomtePublishService" />
    public class MqttRomtePublishService : ServiceBase, IMqttRomtePublishService
    {
        /// <summary>
        /// Publishes the specified device identifier.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="message">The message.</param>
        public async Task Publish(string deviceId, MqttWillMessage message)
        {
            await ServiceLocator.GetService<IChannelService>().Publish(deviceId, message);
        }
    }
}