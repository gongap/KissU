using System;
using System.Threading.Tasks;
using DotNetty.Codecs.Mqtt.Packets;
using DotNetty.Transport.Channels;
using KissU.Core.Protocol.Mqtt.Internal.Channel;
using KissU.Core.Protocol.Mqtt.Internal.Messages;

namespace KissU.Core.Protocol.Mqtt.Internal.Services
{
    /// <summary>
    /// Interface IMessagePushService
    /// </summary>
    public interface IMessagePushService
    {
        /// <summary>
        /// Writes the will MSG.
        /// </summary>
        /// <param name="mqttChannel">The MQTT channel.</param>
        /// <param name="willMeaasge">The will meaasge.</param>
        /// <returns>Task.</returns>
        Task WriteWillMsg(MqttChannel mqttChannel, MqttWillMessage willMeaasge);

        /// <summary>
        /// Sends the qos confirm MSG.
        /// </summary>
        /// <param name="qos">The qos.</param>
        /// <param name="mqttChannel">The MQTT channel.</param>
        /// <param name="topic">The topic.</param>
        /// <param name="bytes">The bytes.</param>
        /// <returns>Task.</returns>
        Task SendQosConfirmMsg(QualityOfService qos, MqttChannel mqttChannel, string topic, byte[] bytes);

        /// <summary>
        /// Sends the pub back.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <param name="messageId">The message identifier.</param>
        /// <returns>Task.</returns>
        Task SendPubBack(IChannel channel, int messageId);

        /// <summary>
        /// Sends the pub record.
        /// </summary>
        /// <param name="mqttChannel">The MQTT channel.</param>
        /// <param name="messageId">The message identifier.</param>
        /// <returns>Task.</returns>
        Task SendPubRec(MqttChannel mqttChannel, int messageId);

        /// <summary>
        /// Sends the pub relative.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <param name="messageId">The message identifier.</param>
        /// <returns>Task.</returns>
        Task SendPubRel(IChannel channel, int messageId);

        /// <summary>
        /// Sends to pub comp.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <param name="messageId">The message identifier.</param>
        /// <returns>Task.</returns>
        Task SendToPubComp(IChannel channel, int messageId);

        /// <summary>
        /// Sends the qos0 MSG.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <param name="topic">The topic.</param>
        /// <param name="byteBuf">The byte buf.</param>
        /// <returns>Task.</returns>
        Task SendQos0Msg(IChannel channel, String topic, byte[] byteBuf);
    }
}
