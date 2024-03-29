﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DotNetty.Codecs.Mqtt.Packets;
using DotNetty.Transport.Channels;
using KissU.CPlatform;
using KissU.CPlatform.Diagnostics;
using KissU.CPlatform.Messages;
using KissU.DotNetty.Mqtt.Internal.Enums;
using KissU.DotNetty.Mqtt.Internal.Messages;
using KissU.DotNetty.Mqtt.Internal.Runtime;
using KissU.DotNetty.Mqtt.Internal.Services;
using Microsoft.Extensions.Logging;

namespace KissU.DotNetty.Mqtt.Implementation
{
    /// <summary>
    /// ServerMqttHandlerService.
    /// </summary>
    public class ServerMqttHandlerService
    {
        private readonly IChannelService _channelService;
        private readonly ILogger _logger;
        private readonly IMqttBehaviorProvider _mqttBehaviorProvider;
        private readonly DiagnosticListener _diagnosticListener;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerMqttHandlerService" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="channelService">The channel service.</param>
        /// <param name="mqttBehaviorProvider">The MQTT behavior provider.</param>
        public ServerMqttHandlerService(
            ILogger logger, IChannelService channelService, IMqttBehaviorProvider mqttBehaviorProvider)
        {
            _logger = logger;
            _channelService = channelService;
            _mqttBehaviorProvider = mqttBehaviorProvider;
            _diagnosticListener = new DiagnosticListener(string.Format(DiagnosticListenerExtensions.DiagnosticListenerName, TransportType.Mqtt));
        }

        /// <summary>
        /// Connections the ack.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packet">The packet.</param>
        public async Task ConnAck(IChannelHandlerContext context, ConnAckPacket packet)
        {
            await context.WriteAndFlushAsync(packet);
        }

        /// <summary>
        /// Logins the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packet">The packet.</param>
        public async Task Login(IChannelHandlerContext context, ConnectPacket packet)
        {
            var deviceId = packet.ClientId;
            var message = TransportMessage.CreateInvokeMessage(new RemoteInvokeMessage
                {ServiceId = "Connect", Parameters = new Dictionary<string, object> {{"packet", packet}}});
            WriteTransportBefore(message, context.Channel.RemoteAddress.ToString(), deviceId, packet.PacketType);
            if (string.IsNullOrEmpty(deviceId))
            {
                await ConnAck(context, new ConnAckPacket
                {
                    ReturnCode = ConnectReturnCode.RefusedIdentifierRejected
                });
                return;
            }

            var mqttBehavior = _mqttBehaviorProvider.GetMqttBehavior();
            if (mqttBehavior != null)
            {
                if (packet.HasPassword && packet.HasUsername
                                       && await mqttBehavior.AuthorizedAsync(packet.Username, packet.Password))
                {
                    var mqttChannel = _channelService.GetMqttChannel(deviceId);
                    if (mqttChannel == null || !await mqttChannel.IsOnine())
                    {
                        byte[] bytes = null;
                        if (packet.WillMessage != null)
                        {
                            bytes = new byte[packet.WillMessage.ReadableBytes];
                            packet.WillMessage.ReadBytes(bytes);
                        }

                        await _channelService.Login(context.Channel, deviceId, new ConnectMessage
                        {
                            CleanSession = packet.CleanSession,
                            ClientId = packet.ClientId,
                            Duplicate = packet.Duplicate,
                            HasPassword = packet.HasPassword,
                            HasUsername = packet.HasUsername,
                            HasWill = packet.HasWill,
                            KeepAliveInSeconds = packet.KeepAliveInSeconds,
                            Password = packet.Password,
                            ProtocolLevel = packet.ProtocolLevel,
                            ProtocolName = packet.ProtocolName,
                            Qos = (int) packet.QualityOfService,
                            RetainRequested = packet.RetainRequested,
                            Username = packet.Username,
                            WillMessage = bytes,
                            WillQualityOfService = (int) packet.WillQualityOfService,
                            WillRetain = packet.WillRetain,
                            WillTopic = packet.WillTopicName
                        });
                    }
                }
                else
                {
                    await ConnAck(context, new ConnAckPacket
                    {
                        ReturnCode = ConnectReturnCode.RefusedBadUsernameOrPassword
                    });
                }
            }
            else
            {
                await ConnAck(context, new ConnAckPacket
                {
                    ReturnCode = ConnectReturnCode.RefusedServerUnavailable
                });
            }

            WirteDiagnosticAfter(message);
        }

        /// <summary>
        /// Disconnects the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packet">The packet.</param>
        public async Task Disconnect(IChannelHandlerContext context, DisconnectPacket packet)
        {
            var deviceId = await _channelService.GetDeviceId(context.Channel);
            var message = TransportMessage.CreateInvokeMessage(new RemoteInvokeMessage
                {ServiceId = "Disconnect", Parameters = new Dictionary<string, object> {{"packet", packet}}});
            WriteTransportBefore(message, context.Channel.RemoteAddress.ToString(), deviceId, packet.PacketType);
            await _channelService.Close(deviceId, true);
            WirteDiagnosticAfter(message);
        }

        /// <summary>
        /// Pings the req.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packet">The packet.</param>
        public async Task PingReq(IChannelHandlerContext context, PingReqPacket packet)
        {
            var channel = context.Channel;
            if (channel.Open && channel.Active && channel.IsWritable)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                    _logger.LogInformation("收到来自：【" + context.Channel.RemoteAddress + "】心跳");
                await _channelService.PingReq(context.Channel);
                await PingResp(context, PingRespPacket.Instance);
            }
        }

        /// <summary>
        /// Pings the resp.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packet">The packet.</param>
        public async Task PingResp(IChannelHandlerContext context, PingRespPacket packet)
        {
            await context.WriteAndFlushAsync(packet);
        }

        /// <summary>
        /// Pubs the ack.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packet">The packet.</param>
        public async Task PubAck(IChannelHandlerContext context, PubAckPacket packet)
        {
            var messageId = packet.PacketId;
            var mqttChannel = _channelService.GetMqttChannel(await _channelService.GetDeviceId(context.Channel));
            var message = mqttChannel.GetMqttMessage(messageId);
            if (message != null)
            {
                message.ConfirmStatus = ConfirmStatus.COMPLETE;
            }

            await context.WriteAndFlushAsync(packet);
        }

        /// <summary>
        /// Pubs the comp.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packet">The packet.</param>
        public async Task PubComp(IChannelHandlerContext context, PubCompPacket packet)
        {
            var messageId = packet.PacketId;
            var mqttChannel = _channelService.GetMqttChannel(await _channelService.GetDeviceId(context.Channel));
            var message = mqttChannel.GetMqttMessage(messageId);
            if (message != null)
            {
                message.ConfirmStatus = ConfirmStatus.COMPLETE;
            }

            await context.WriteAndFlushAsync(packet);
        }

        /// <summary>
        /// Publishes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packet">The packet.</param>
        public async Task Publish(IChannelHandlerContext context, PublishPacket packet)
        {
            await _channelService.Publish(context.Channel, packet);
        }

        /// <summary>
        /// Pubs the record.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packet">The packet.</param>
        public async Task PubRec(IChannelHandlerContext context, PubRecPacket packet)
        {
            var messageId = packet.PacketId;
            var mqttChannel = _channelService.GetMqttChannel(await _channelService.GetDeviceId(context.Channel));
            var message = mqttChannel.GetMqttMessage(messageId);
            if (message != null)
            {
                message.ConfirmStatus = ConfirmStatus.PUBREC;
            }

            await _channelService.Pubrec(mqttChannel, messageId);
        }

        /// <summary>
        /// Pubs the relative.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packet">The packet.</param>
        public async Task PubRel(IChannelHandlerContext context, PubRelPacket packet)
        {
            var messageId = packet.PacketId;
            var mqttChannel = _channelService.GetMqttChannel(await _channelService.GetDeviceId(context.Channel));
            var message = mqttChannel.GetMqttMessage(messageId);
            if (message != null)
            {
                message.ConfirmStatus = ConfirmStatus.PUBREL;
            }

            await _channelService.Pubrel(context.Channel, messageId);
        }

        /// <summary>
        /// Subs the ack.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packet">The packet.</param>
        public async Task SubAck(IChannelHandlerContext context, SubAckPacket packet)
        {
            await context.WriteAndFlushAsync(packet);
        }

        /// <summary>
        /// Subscribes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packet">The packet.</param>
        public async Task Subscribe(IChannelHandlerContext context, SubscribePacket packet)
        {
            if (packet != null)
            {
                var deviceId = await _channelService.GetDeviceId(context.Channel);
                var topics = packet.Requests.Select(p => p.TopicFilter).ToArray();
                var message = TransportMessage.CreateInvokeMessage(new RemoteInvokeMessage
                    {ServiceId = "Subscribe", Parameters = new Dictionary<string, object> {{"packet", packet}}});
                WriteTransportBefore(message, context.Channel.RemoteAddress.ToString(), deviceId, packet.PacketType);
                await _channelService.Suscribe(deviceId, topics);
                await SubAck(context, SubAckPacket.InResponseTo(packet, QualityOfService.ExactlyOnce));
                WirteDiagnosticAfter(message);
            }
        }

        /// <summary>
        /// Unsubs the ack.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packet">The packet.</param>
        public async Task UnsubAck(IChannelHandlerContext context, UnsubAckPacket packet)
        {
            await context.WriteAndFlushAsync(packet);
        }

        /// <summary>
        /// Unsubscribes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packet">The packet.</param>
        public async Task Unsubscribe(IChannelHandlerContext context, UnsubscribePacket packet)
        {
            var topics = packet.TopicFilters.ToArray();
            var deviceId = await _channelService.GetDeviceId(context.Channel);
            var message = TransportMessage.CreateInvokeMessage(new RemoteInvokeMessage
                {ServiceId = "Unsubscribe", Parameters = new Dictionary<string, object> {{"packet", packet}}});
            WriteTransportBefore(message, context.Channel.RemoteAddress.ToString(), deviceId, packet.PacketType);
            await _channelService.UnSubscribe(deviceId, topics);
            await UnsubAck(context, UnsubAckPacket.InResponseTo(packet));
            WirteDiagnosticAfter(message);
        }

        private void WriteTransportBefore(TransportMessage message, string address, string traceId,
            PacketType packetType)
        {
            if (!AppConfig.ServerOptions.DisableDiagnostic)
            {
                var remoteInvokeMessage = message.GetContent<RemoteInvokeMessage>();
                _diagnosticListener.WriteTransportBefore(TransportType.Mqtt, new TransportEventData(new DiagnosticMessage
                {
                        Content = message.Content,
                        ContentType = message.ContentType,
                        Id = message.Id,
                        MessageName = remoteInvokeMessage.ServiceId
                    }, packetType.ToString(),
                    new TracingHeaders(), address));
            }
        }

        private void WirteDiagnosticAfter(TransportMessage message)
        {
            if (!AppConfig.ServerOptions.DisableDiagnostic)
            {
                _diagnosticListener.WriteTransportAfter(TransportType.Mqtt, new ReceiveEventData(new DiagnosticMessage
                {
                    Content = message.Content,
                    ContentType = message.ContentType,
                    Id = message.Id
                }));
            }
        }
    }
}