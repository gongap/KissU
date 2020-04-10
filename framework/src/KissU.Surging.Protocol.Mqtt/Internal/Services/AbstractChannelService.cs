using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetty.Codecs.Mqtt.Packets;
using DotNetty.Common.Utilities;
using DotNetty.Transport.Channels;
using KissU.Surging.CPlatform;
using KissU.Surging.CPlatform.Ids;
using KissU.Surging.CPlatform.Messages;
using KissU.Surging.CPlatform.Utilities;
using KissU.Surging.Protocol.Mqtt.Internal.Channel;
using KissU.Surging.Protocol.Mqtt.Internal.Messages;
using KissU.Surging.Protocol.Mqtt.Internal.Runtime;

namespace KissU.Surging.Protocol.Mqtt.Internal.Services
{
    /// <summary>
    /// AbstractChannelService.
    /// Implements the <see cref="KissU.Surging.Protocol.Mqtt.Internal.Services.IChannelService" />
    /// </summary>
    /// <seealso cref="KissU.Surging.Protocol.Mqtt.Internal.Services.IChannelService" />
    public abstract class AbstractChannelService : IChannelService
    {
        private readonly IMessagePushService _messagePushService;
        private readonly IMqttBrokerEntryManger _mqttBrokerEntryManger;
        private readonly IMqttRemoteInvokeService _mqttRemoteInvokeService;
        private readonly string _publishServiceId;

        /// <summary>
        /// The retain
        /// </summary>
        protected readonly ConcurrentDictionary<string, ConcurrentQueue<RetainMessage>> _retain =
            new ConcurrentDictionary<string, ConcurrentQueue<RetainMessage>>();

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractChannelService" /> class.
        /// </summary>
        /// <param name="messagePushService">The message push service.</param>
        /// <param name="mqttBrokerEntryManger">The MQTT broker entry manger.</param>
        /// <param name="mqttRemoteInvokeService">The MQTT remote invoke service.</param>
        /// <param name="serviceIdGenerator">The service identifier generator.</param>
        public AbstractChannelService(IMessagePushService messagePushService,
            IMqttBrokerEntryManger mqttBrokerEntryManger,
            IMqttRemoteInvokeService mqttRemoteInvokeService,
            IServiceIdGenerator serviceIdGenerator
        )
        {
            _messagePushService = messagePushService;
            _mqttBrokerEntryManger = mqttBrokerEntryManger;
            _mqttRemoteInvokeService = mqttRemoteInvokeService;
            _publishServiceId =
                serviceIdGenerator.GenerateServiceId(typeof(IMqttRomtePublishService).GetMethod("Publish"));
        }

        /// <summary>
        /// Gets the MQTT channels.
        /// </summary>
        public ConcurrentDictionary<string, MqttChannel> MqttChannels { get; } =
            new ConcurrentDictionary<string, MqttChannel>();

        /// <summary>
        /// Gets the device identifier attribute key.
        /// </summary>
        public AttributeKey<string> DeviceIdAttrKey { get; } = AttributeKey<string>.ValueOf("deviceId");

        /// <summary>
        /// Gets the login attribute key.
        /// </summary>
        public AttributeKey<string> LoginAttrKey { get; } = AttributeKey<string>.ValueOf("login");

        /// <summary>
        /// Gets the topics.
        /// </summary>
        public ConcurrentDictionary<string, IEnumerable<MqttChannel>> Topics { get; } =
            new ConcurrentDictionary<string, IEnumerable<MqttChannel>>();

        /// <summary>
        /// Gets the retain.
        /// </summary>
        public ConcurrentDictionary<string, ConcurrentQueue<RetainMessage>> Retain => _retain;

        /// <summary>
        /// Closes the specified device identifier.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="isDisconnect">if set to <c>true</c> [is disconnect].</param>
        /// <returns>Task.</returns>
        public abstract Task Close(string deviceId, bool isDisconnect);

        /// <summary>
        /// Connects the specified device identifier.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="build">The build.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public abstract Task<bool> Connect(string deviceId, MqttChannel build);

        /// <summary>
        /// Gets the device identifier.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <returns>ValueTask&lt;System.String&gt;.</returns>
        public async ValueTask<string> GetDeviceId(IChannel channel)
        {
            string deviceId = null;
            if (channel != null)
            {
                deviceId = channel.GetAttribute(DeviceIdAttrKey).Get();
            }

            return await new ValueTask<string>(deviceId);
        }

        /// <summary>
        /// 获取mqtt通道
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns>MqttChannel.</returns>
        public MqttChannel GetMqttChannel(string deviceId)
        {
            MqttChannel channel = null;
            if (!string.IsNullOrEmpty(deviceId))
            {
                MqttChannels.TryGetValue(deviceId, out channel);
            }

            return channel;
        }

        /// <summary>
        /// Remotes the publish message.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="willMessage">The will message.</param>
        public async Task RemotePublishMessage(string deviceId, MqttWillMessage willMessage)
        {
            await _mqttRemoteInvokeService.InvokeAsync(new MqttRemoteInvokeContext
            {
                topic = willMessage.Topic,
                InvokeMessage = new RemoteInvokeMessage
                {
                    ServiceId = _publishServiceId,
                    Parameters = new Dictionary<string, object>
                    {
                        {"deviceId", deviceId},
                        {"message", willMessage}
                    }
                }
            }, AppConfig.ServerOptions.ExecutionTimeoutInMilliseconds);
        }

        /// <summary>
        /// Logins the specified channel.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="mqttConnectMessage">The MQTT connect message.</param>
        /// <returns>Task.</returns>
        public abstract Task Login(IChannel channel, string deviceId, ConnectMessage mqttConnectMessage);

        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <param name="mqttPublishMessage">The MQTT publish message.</param>
        /// <returns>Task.</returns>
        public abstract Task Publish(IChannel channel, PublishPacket mqttPublishMessage);

        /// <summary>
        /// Pubrecs the specified channel.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <param name="messageId">The message identifier.</param>
        /// <returns>Task.</returns>
        public abstract Task Pubrec(MqttChannel channel, int messageId);

        /// <summary>
        /// Pings the req.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <returns>ValueTask.</returns>
        public abstract ValueTask PingReq(IChannel channel);

        /// <summary>
        /// Pubrels the specified channel.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <param name="messageId">The message identifier.</param>
        /// <returns>Task.</returns>
        public abstract Task Pubrel(IChannel channel, int messageId);

        /// <summary>
        /// Sends the will MSG.
        /// </summary>
        /// <param name="willMeaasge">The will meaasge.</param>
        /// <returns>Task.</returns>
        public abstract Task SendWillMsg(MqttWillMessage willMeaasge);

        /// <summary>
        /// 订阅
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="topics">主题列表</param>
        /// <returns>Task.</returns>
        public abstract Task Suscribe(string deviceId, params string[] topics);

        /// <summary>
        /// 取消订阅
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="topics">The topics.</param>
        /// <returns>Task.</returns>
        public abstract Task UnSubscribe(string deviceId, params string[] topics);

        /// <summary>
        /// Publishes the specified device identifier.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="willMessage">The will message.</param>
        /// <returns>Task.</returns>
        public abstract Task Publish(string deviceId, MqttWillMessage willMessage);

        /// <summary>
        /// Gets the device is onine.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns>ValueTask&lt;System.Boolean&gt;.</returns>
        public async ValueTask<bool> GetDeviceIsOnine(string deviceId)
        {
            var result = false;
            if (!string.IsNullOrEmpty(deviceId))
            {
                MqttChannels.TryGetValue(deviceId, out var mqttChannel);
                result = mqttChannel == null ? false : await mqttChannel.IsOnine();
            }

            return result;
        }

        /// <summary>
        /// Removes the channel.
        /// </summary>
        /// <param name="topic">The topic.</param>
        /// <param name="mqttChannel">The MQTT channel.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool RemoveChannel(string topic, MqttChannel mqttChannel)
        {
            var result = false;
            if (!string.IsNullOrEmpty(topic) && mqttChannel != null)
            {
                Topics.TryGetValue(topic, out var mqttChannels);
                var channels = mqttChannels == null ? new List<MqttChannel>() : mqttChannels.ToList();
                channels.Remove(mqttChannel);
                Topics.AddOrUpdate(topic, channels, (key, value) => channels);
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Adds the channel.
        /// </summary>
        /// <param name="topic">The topic.</param>
        /// <param name="mqttChannel">The MQTT channel.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool AddChannel(string topic, MqttChannel mqttChannel)
        {
            var result = false;
            if (!string.IsNullOrEmpty(topic) && mqttChannel != null)
            {
                Topics.TryGetValue(topic, out var mqttChannels);
                var channels = mqttChannels == null ? new List<MqttChannel>() : mqttChannels.ToList();
                channels.Add(mqttChannel);
                Topics.AddOrUpdate(topic, channels, (key, value) => channels);
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Registers the MQTT broker.
        /// </summary>
        /// <param name="topic">The topic.</param>
        protected async Task RegisterMqttBroker(string topic)
        {
            var addresses = await _mqttBrokerEntryManger.GetMqttBrokerAddress(topic);
            var host = NetUtils.GetHostAddress();
            if (addresses == null || !addresses.Any(p => p.ToString() == host.ToString()))
                await _mqttBrokerEntryManger.Register(topic, host);
        }

        /// <summary>
        /// Brokers the cancellation reg.
        /// </summary>
        /// <param name="topic">The topic.</param>
        protected async Task BrokerCancellationReg(string topic)
        {
            if (Topics.ContainsKey(topic))
            {
                if (Topics[topic].Count() == 0)
                    await _mqttBrokerEntryManger.CancellationReg(topic, NetUtils.GetHostAddress());
            }
            else
            {
                await _mqttBrokerEntryManger.CancellationReg(topic, NetUtils.GetHostAddress());
            }
        }
    }
}