using System.Threading.Tasks;
using KissU.Dependency;
using KissU.DotNetty.Mqtt.Internal.Messages;
using KissU.DotNetty.Mqtt.Internal.Services;

namespace KissU.DotNetty.Mqtt.Internal.Runtime.Implementation
{
    /// <summary>
    /// MqttRomtePublishService.
    /// Implements the <see cref="ServiceBase" />
    /// Implements the <see cref="IMqttRomtePublishService" />
    /// </summary>
    /// <seealso cref="ServiceBase" />
    /// <seealso cref="IMqttRomtePublishService" />
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