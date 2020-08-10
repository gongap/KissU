using System.Threading.Tasks;
using KissU.DotNetty.Mqtt.Internal.Messages;
using KissU.DotNetty.Mqtt.Internal.Services;
using KissU.Modules.SampleA.Service.Contracts;
using KissU.Modules.SampleA.Service.Contracts.Dtos;
using KissU.Modules.SampleB.Service.Contracts;

namespace KissU.Modules.SampleA.Service.Implements
{
    /// <summary>
    /// ControllerService.
    /// Implements the <see cref="MqttBehavior" />
    /// Implements the <see cref="IMqttService" />
    /// </summary>
    /// <seealso cref="MqttBehavior" />
    /// <seealso cref="IMqttService" />
    public class MqttService : MqttBehavior, IMqttService
    {
        /// <summary>
        /// Determines whether the specified device identifier is online.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public async Task<bool> IsOnline(string deviceId)
        {
            var text = await GetService<IManagerService>().SayHello("gongap");
            return await GetDeviceIsOnine(deviceId);
        }

        /// <summary>
        /// Publishes the specified device identifier.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns>Task.</returns>
        public async Task Publish(string deviceId, WillMessage message)
        {
            var willMessage = new MqttWillMessage
            {
                WillMessage = message.Message,
                Qos = message.Qos,
                Topic = message.Topic,
                WillRetain = message.WillRetain
            };
            await Publish(deviceId, willMessage);
            await RemotePublish(deviceId, willMessage);
        }

        /// <summary>
        /// Authorizeds the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public override async Task<bool> Authorized(string username, string password)
        {
            var result = false;
            if (username == "admin" && password == "123456")
                result = true;
            return await Task.FromResult(result);
        }
    }
}