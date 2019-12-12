using System;
using System.Threading.Tasks;
using DotNetty.Codecs.Mqtt.Packets;
using DotNetty.Transport.Channels;
using KissU.Core.Protocol.Mqtt.Internal.Channel;
using KissU.Core.Protocol.Mqtt.Internal.Messages;

namespace KissU.Core.Protocol.Mqtt.Internal.Services
{
    public interface IMessagePushService
    {
        Task WriteWillMsg(MqttChannel mqttChannel, MqttWillMessage willMeaasge);

        Task SendQosConfirmMsg(QualityOfService qos, MqttChannel mqttChannel, string topic, byte[] bytes);

        Task SendPubBack(IChannel channel, int messageId);

        Task SendPubRec(MqttChannel mqttChannel, int messageId);

        Task SendPubRel(IChannel channel, int messageId);

        Task SendToPubComp(IChannel channel, int messageId);

        Task SendQos0Msg(IChannel channel, String topic, byte[] byteBuf);
    }
}
