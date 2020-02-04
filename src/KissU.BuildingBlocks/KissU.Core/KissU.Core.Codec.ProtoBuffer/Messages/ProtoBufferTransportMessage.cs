using System;
using KissU.Core.Codec.ProtoBuffer.Utilities;
using KissU.Core.CPlatform.Messages;
using ProtoBuf;

namespace KissU.Core.Codec.ProtoBuffer.Messages
{
    /// <summary>
    /// ProtoBufferTransportMessage.
    /// </summary>
    [ProtoContract]
    public class ProtoBufferTransportMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProtoBufferTransportMessage" /> class.
        /// </summary>
        /// <param name="transportMessage">The transport message.</param>
        /// <exception cref="NotSupportedException">无法支持的消息类型：{ContentType}！</exception>
        public ProtoBufferTransportMessage(TransportMessage transportMessage)
        {
            Id = transportMessage.Id;
            ContentType = transportMessage.ContentType;

            object contentObject;
            if (transportMessage.IsInvokeMessage())
            {
                contentObject = new ProtoBufferRemoteInvokeMessage(transportMessage.GetContent<RemoteInvokeMessage>());
            }
            else if (transportMessage.IsInvokeResultMessage())
            {
                contentObject =
                    new ProtoBufferRemoteInvokeResultMessage(transportMessage.GetContent<RemoteInvokeResultMessage>());
            }
            else
            {
                throw new NotSupportedException($"无法支持的消息类型：{ContentType}！");
            }

            Content = SerializerUtilitys.Serialize(contentObject);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProtoBufferTransportMessage" /> class.
        /// </summary>
        public ProtoBufferTransportMessage()
        {
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [ProtoMember(1)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        [ProtoMember(2)]
        public byte[] Content { get; set; }

        /// <summary>
        /// Gets or sets the type of the content.
        /// </summary>
        [ProtoMember(3)]
        public string ContentType { get; set; }


        /// <summary>
        /// Determines whether [is invoke message].
        /// </summary>
        /// <returns><c>true</c> if [is invoke message]; otherwise, <c>false</c>.</returns>
        public bool IsInvokeMessage()
        {
            return ContentType == MessagePackTransportMessageType.RemoteInvokeMessageTypeName;
        }

        /// <summary>
        /// Determines whether [is invoke result message].
        /// </summary>
        /// <returns><c>true</c> if [is invoke result message]; otherwise, <c>false</c>.</returns>
        public bool IsInvokeResultMessage()
        {
            return ContentType == MessagePackTransportMessageType.RemoteInvokeResultMessageTypeName;
        }

        /// <summary>
        /// Gets the transport message.
        /// </summary>
        /// <returns>TransportMessage.</returns>
        /// <exception cref="NotSupportedException">无法支持的消息类型：{ContentType}！</exception>
        public TransportMessage GetTransportMessage()
        {
            var message = new TransportMessage
            {
                ContentType = ContentType,
                Id = Id,
                Content = null
            };

            object contentObject;
            if (IsInvokeMessage())
            {
                contentObject =
                    SerializerUtilitys.Deserialize<ProtoBufferRemoteInvokeMessage>(Content).GetRemoteInvokeMessage();
            }
            else if (IsInvokeResultMessage())
            {
                contentObject =
                    SerializerUtilitys.Deserialize<ProtoBufferRemoteInvokeResultMessage>(Content)
                        .GetRemoteInvokeResultMessage();
            }
            else
            {
                throw new NotSupportedException($"无法支持的消息类型：{ContentType}！");
            }

            message.Content = contentObject;

            return message;
        }
    }
}