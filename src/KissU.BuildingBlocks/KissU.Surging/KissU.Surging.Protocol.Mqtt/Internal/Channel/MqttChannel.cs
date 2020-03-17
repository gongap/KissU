using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetty.Common.Utilities;
using DotNetty.Transport.Channels;
using KissU.Surging.Protocol.Mqtt.Internal.Enums;
using KissU.Surging.Protocol.Mqtt.Internal.Messages;

namespace KissU.Surging.Protocol.Mqtt.Internal.Channel
{
    /// <summary>
    /// MqttChannel.
    /// </summary>
    public class MqttChannel
    {
        /// <summary>
        /// Gets or sets the channel.
        /// </summary>
        public IChannel Channel { get; set; }

        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is will.
        /// </summary>
        public bool IsWill { get; set; }

        /// <summary>
        /// Gets or sets the subscribe status.
        /// </summary>
        public SubscribeStatus SubscribeStatus { get; set; }

        /// <summary>
        /// Gets or sets the topics.
        /// </summary>
        public List<string> Topics { get; set; }

        /// <summary>
        /// Gets or sets the session status.
        /// </summary>
        public SessionStatus SessionStatus { get; set; }

        /// <summary>
        /// Gets or sets the keep alive in seconds.
        /// </summary>
        public int KeepAliveInSeconds { get; set; }

        /// <summary>
        /// Gets or sets the ping req time.
        /// </summary>
        public DateTime PingReqTime { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets a value indicating whether [clean session].
        /// </summary>
        public bool CleanSession { get; set; }

        /// <summary>
        /// Gets or sets the messages.
        /// </summary>
        public ConcurrentDictionary<int, SendMqttMessage> Messages { get; set; }

        /// <summary>
        /// Adds the MQTT message.
        /// </summary>
        /// <param name="messageId">The message identifier.</param>
        /// <param name="msg">The MSG.</param>
        public void AddMqttMessage(int messageId, SendMqttMessage msg)
        {
            Messages.AddOrUpdate(messageId, msg, (id, message) => msg);
        }

        /// <summary>
        /// Gets the MQTT message.
        /// </summary>
        /// <param name="messageId">The message identifier.</param>
        /// <returns>SendMqttMessage.</returns>
        public SendMqttMessage GetMqttMessage(int messageId)
        {
            SendMqttMessage mqttMessage = null;
            Messages.TryGetValue(messageId, out mqttMessage);
            return mqttMessage;
        }


        /// <summary>
        /// Removes the MQTT message.
        /// </summary>
        /// <param name="messageId">The message identifier.</param>
        public void RemoveMqttMessage(int messageId)
        {
            SendMqttMessage mqttMessage = null;
            Messages.Remove(messageId, out mqttMessage);
        }

        /// <summary>
        /// Determines whether this instance is login.
        /// </summary>
        /// <returns><c>true</c> if this instance is login; otherwise, <c>false</c>.</returns>
        public bool IsLogin()
        {
            var result = false;
            if (Channel != null)
            {
                var _login = AttributeKey<string>.ValueOf("login");
                result = Channel.Active && Channel.HasAttribute(_login);
            }

            return result;
        }

        /// <summary>
        /// Closes this instance.
        /// </summary>
        public async Task Close()
        {
            if (Channel != null)
                await Channel.CloseAsync();
        }


        /// <summary>
        /// Determines whether this instance is onine.
        /// </summary>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public async Task<bool> IsOnine()
        {
            //如果保持连接的值非零，并且服务端在2倍的保持连接时间内没有收到客户端的报文，需要断开客户端的连接
            var isOnline = (DateTime.Now - PingReqTime).TotalSeconds <= KeepAliveInSeconds * 2 &&
                           SessionStatus == SessionStatus.OPEN;
            if (!isOnline)
            {
                await Close();
            }

            return isOnline;
        }

        /// <summary>
        /// Determines whether this instance is active.
        /// </summary>
        /// <returns><c>true</c> if this instance is active; otherwise, <c>false</c>.</returns>
        public bool IsActive()
        {
            return Channel != null && Channel.Active;
        }

        /// <summary>
        /// Adds the topic.
        /// </summary>
        /// <param name="topics">The topics.</param>
        public void AddTopic(params string[] topics)
        {
            Topics.AddRange(topics);
        }
    }
}