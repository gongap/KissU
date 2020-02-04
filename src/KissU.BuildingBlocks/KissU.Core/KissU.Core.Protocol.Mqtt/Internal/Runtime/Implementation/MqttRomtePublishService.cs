using System.Threading.Tasks;
using KissU.Core.CPlatform.Ioc;
using KissU.Core.CPlatform.Utilities;
using KissU.Core.Protocol.Mqtt.Internal.Messages;
using KissU.Core.Protocol.Mqtt.Internal.Services;

namespace KissU.Core.Protocol.Mqtt.Internal.Runtime.Implementation
{
    /// <summary>
    /// MqttRomtePublishService.
    /// Implements the <see cref="KissU.Core.CPlatform.Ioc.ServiceBase" />
    /// Implements the <see cref="KissU.Core.Protocol.Mqtt.Internal.Runtime.IMqttRomtePublishService" />
    /// </summary>
    /// <seealso cref="KissU.Core.CPlatform.Ioc.ServiceBase" />
    /// <seealso cref="KissU.Core.Protocol.Mqtt.Internal.Runtime.IMqttRomtePublishService" />
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
