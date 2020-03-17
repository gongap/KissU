using System.Threading.Tasks;
using KissU.Surging.CPlatform.Ioc;
using KissU.Surging.CPlatform.Utilities;
using KissU.Surging.Protocol.Mqtt.Internal.Messages;
using KissU.Surging.Protocol.Mqtt.Internal.Services;

namespace KissU.Surging.Protocol.Mqtt.Internal.Runtime.Implementation
{
    /// <summary>
    /// MqttRomtePublishService.
    /// Implements the <see cref="KissU.Surging.CPlatform.Ioc.ServiceBase" />
    /// Implements the <see cref="KissU.Surging.Protocol.Mqtt.Internal.Runtime.IMqttRomtePublishService" />
    /// </summary>
    /// <seealso cref="KissU.Surging.CPlatform.Ioc.ServiceBase" />
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