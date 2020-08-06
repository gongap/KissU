using System.Threading.Tasks;
using DotNetty.Codecs.Mqtt.Packets;
using DotNetty.Transport.Channels;
using KissU.Protocol.Mqtt.Internal.Channel;
using KissU.Protocol.Mqtt.Internal.Messages;

namespace KissU.Protocol.Mqtt.Internal.Services
{
    /// <summary>
    /// Interface IChannelService
    /// </summary>
    public interface IChannelService
    {
        /// <summary>
        /// 获取mqtt通道
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns>MqttChannel.</returns>
        MqttChannel GetMqttChannel(string deviceId);

        /// <summary>
        /// 获取设备是否连接
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="mqttChannel">The MQTT channel.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> Connect(string deviceId, MqttChannel mqttChannel);

        /// <summary>
        /// 订阅
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="topics">主题列表</param>
        /// <returns>Task.</returns>
        Task Suscribe(string deviceId, params string[] topics);

        /// <summary>
        /// Logins the specified channel.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="mqttConnectMessage">The MQTT connect message.</param>
        /// <returns>Task.</returns>
        Task Login(IChannel channel, string deviceId, ConnectMessage mqttConnectMessage);

        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <param name="mqttPublishMessage">The MQTT publish message.</param>
        /// <returns>Task.</returns>
        Task Publish(IChannel channel, PublishPacket mqttPublishMessage);

        /// <summary>
        /// Pings the req.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <returns>ValueTask.</returns>
        ValueTask PingReq(IChannel channel);

        /// <summary>
        /// Publishes the specified device identifier.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="willMessage">The will message.</param>
        /// <returns>Task.</returns>
        Task Publish(string deviceId, MqttWillMessage willMessage);

        /// <summary>
        /// Remotes the publish message.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="willMessage">The will message.</param>
        /// <returns>Task.</returns>
        Task RemotePublishMessage(string deviceId, MqttWillMessage willMessage);

        /// <summary>
        /// Closes the specified device identifier.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="isDisconnect">if set to <c>true</c> [is disconnect].</param>
        /// <returns>Task.</returns>
        Task Close(string deviceId, bool isDisconnect);

        /// <summary>
        /// Gets the device is onine.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns>ValueTask&lt;System.Boolean&gt;.</returns>
        ValueTask<bool> GetDeviceIsOnine(string deviceId);

        /// <summary>
        /// Sends the will MSG.
        /// </summary>
        /// <param name="willMeaasge">The will meaasge.</param>
        /// <returns>Task.</returns>
        Task SendWillMsg(MqttWillMessage willMeaasge);

        /// <summary>
        /// Gets the device identifier.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <returns>ValueTask&lt;System.String&gt;.</returns>
        ValueTask<string> GetDeviceId(IChannel channel);

        /// <summary>
        /// 取消订阅
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="topics">The topics.</param>
        /// <returns>Task.</returns>
        Task UnSubscribe(string deviceId, params string[] topics);

        /// <summary>
        /// Pubrels the specified channel.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <param name="messageId">The message identifier.</param>
        /// <returns>Task.</returns>
        Task Pubrel(IChannel channel, int messageId);

        /// <summary>
        /// Pubrecs the specified channel.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <param name="messageId">The message identifier.</param>
        /// <returns>Task.</returns>
        Task Pubrec(MqttChannel channel, int messageId);
    }
}