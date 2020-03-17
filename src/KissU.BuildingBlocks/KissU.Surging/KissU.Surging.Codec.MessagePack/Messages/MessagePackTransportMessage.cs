using System;
using System.Runtime.CompilerServices;
using KissU.Surging.Codec.MessagePack.Utilities;
using KissU.Surging.CPlatform.Messages;
using MessagePack;

namespace KissU.Surging.Codec.MessagePack.Messages
{
    /// <summary>
    /// MessagePackTransportMessage.
    /// </summary>
    [MessagePackObject]
    public class MessagePackTransportMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessagePackTransportMessage" /> class.
        /// </summary>
        /// <param name="transportMessage">The transport message.</param>
        /// <exception cref="NotSupportedException">无法支持的消息类型：{ContentType}！</exception>
        public MessagePackTransportMessage(TransportMessage transportMessage)
        {
            Id = transportMessage.Id;
            ContentType = transportMessage.ContentType;

            object contentObject;
            if (transportMessage.IsInvokeMessage())
            {
                contentObject = new MessagePackRemoteInvokeMessage(transportMessage.GetContent<RemoteInvokeMessage>());
            }
            else if (transportMessage.IsInvokeResultMessage())
            {
                contentObject =
                    new MessagePackRemoteInvokeResultMessage(transportMessage.GetContent<RemoteInvokeResultMessage>());
            }
            else
            {
                throw new NotSupportedException($"无法支持的消息类型：{ContentType}！");
            }

            Content = SerializerUtilitys.Serialize(contentObject);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessagePackTransportMessage" /> class.
        /// </summary>
        public MessagePackTransportMessage()
        {
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [Key(0)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        [Key(1)]
        public byte[] Content { get; set; }

        /// <summary>
        /// Gets or sets the type of the content.
        /// </summary>
        [Key(2)]
        public string ContentType { get; set; }

        /// <summary>
        /// Determines whether [is invoke message].
        /// </summary>
        /// <returns><c>true</c> if [is invoke message]; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsInvokeMessage()
        {
            return ContentType == MessagePackTransportMessageType.RemoteInvokeMessageTypeName;
        }

        /// <summary>
        /// Determines whether [is invoke result message].
        /// </summary>
        /// <returns><c>true</c> if [is invoke result message]; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
                    SerializerUtilitys.Deserialize<MessagePackRemoteInvokeMessage>(Content).GetRemoteInvokeMessage();
            }
            else if (IsInvokeResultMessage())
            {
                contentObject =
                    SerializerUtilitys.Deserialize<MessagePackRemoteInvokeResultMessage>(Content)
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