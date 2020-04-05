using System.Threading.Tasks;
using KissU.Core.Ioc;
using KissU.Core.Utilities;
using KissU.Surging.Protocol.Mqtt.Internal.Messages;
using KissU.Surging.Protocol.Mqtt.Internal.Services;

namespace KissU.Surging.Protocol.Mqtt.Internal.Runtime.Implementation
{
    /// <summary>
    /// MqttRomtePublishService.
    /// Implements the <see cref="ServiceBase" />
    /// Implements the <see cref="KissU.Surging.Protocol.Mqtt.Internal.Runtime.IMqttRomtePublishService" />
    /// </summary>
    /// <seealso cref="ServiceBase" />
    /// <seealso cref="KissU.Surging.Protocol.Mqtt.Internal.Runtime.IMqttRomtePublishService" />
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