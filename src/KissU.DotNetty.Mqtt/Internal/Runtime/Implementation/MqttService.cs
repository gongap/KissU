using System.Threading.Tasks;
using KissU.CPlatform.Ioc;
using KissU.Dependency;
using KissU.DotNetty.Mqtt.Internal.Messages;
using KissU.DotNetty.Mqtt.Internal.Services;

namespace KissU.DotNetty.Mqtt.Internal.Runtime.Implementation
{
    /// <summary>
    /// MqttService.
    /// </summary>
    [DisableConventionalRegistration]
    public class MqttService : ServiceBase, IMqttService
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