using System;
using DotNetty.Codecs.Mqtt.Packets;
using DotNetty.Transport.Channels;

namespace KissU.Protocol.Mqtt
{
    /// <summary>
    /// MqttHandlerServiceBase.
    /// </summary>
    public abstract class MqttHandlerServiceBase
    {
        /// <summary>
        /// The handler
        /// </summary>
        protected readonly Action<IChannelHandlerContext, object> _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="MqttHandlerServiceBase" /> class.
        /// </summary>
        /// <param name="handler">The handler.</param>
        public MqttHandlerServiceBase(Action<IChannelHandlerContext, object> handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// Logins the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packet">The packet.</param>
        public abstract void Login(IChannelHandlerContext context, ConnectPacket packet);

        /// <summary>
        /// Connections the ack.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packet">The packet.</param>
        public abstract void ConnAck(IChannelHandlerContext context, ConnAckPacket packet);

        /// <summary>
        /// Disconnects the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packet">The packet.</param>
        public abstract void Disconnect(IChannelHandlerContext context, DisconnectPacket packet);

        /// <summary>
        /// Pings the req.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packet">The packet.</param>
        public abstract void PingReq(IChannelHandlerContext context, PingReqPacket packet);

        /// <summary>
        /// Pings the resp.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packet">The packet.</param>
        public abstract void PingResp(IChannelHandlerContext context, PingRespPacket packet);

        /// <summary>
        /// Pubs the ack.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packet">The packet.</param>
        public abstract void PubAck(IChannelHandlerContext context, PubAckPacket packet);

        /// <summary>
        /// Pubs the comp.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packet">The packet.</param>
        public abstract void PubComp(IChannelHandlerContext context, PubCompPacket packet);

        /// <summary>
        /// Pubs the record.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packet">The packet.</param>
        public abstract void PubRec(IChannelHandlerContext context, PubRecPacket packet);

        /// <summary>
        /// Pubs the relative.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packet">The packet.</param>
        public abstract void PubRel(IChannelHandlerContext context, PubRelPacket packet);

        /// <summary>
        /// Publishes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packet">The packet.</param>
        public abstract void Publish(IChannelHandlerContext context, PublishPacket packet);

        /// <summary>
        /// Subs the ack.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packet">The packet.</param>
        public abstract void SubAck(IChannelHandlerContext context, SubAckPacket packet);

        /// <summary>
        /// Subscribes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packet">The packet.</param>
        public abstract void Subscribe(IChannelHandlerContext context, SubscribePacket packet);

        /// <summary>
        /// Unsubs the ack.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packet">The packet.</param>
        public abstract void UnsubAck(IChannelHandlerContext context, UnsubAckPacket packet);

        /// <summary>
        /// Unsubscribes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packet">The packet.</param>
        public abstract void Unsubscribe(IChannelHandlerContext context, UnsubscribePacket packet);
    }
}