using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using KissU.CPlatform.Messages;
using MessagePack;

namespace KissU.Codec.MessagePack.Messages
{
    /// <summary>
    /// ParameterItem.
    /// </summary>
    [MessagePackObject]
    public class ParameterItem
    {
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        [Key(0)]
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [Key(1)]
        public DynamicItem Value { get; set; }

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterItem" /> class.
        /// </summary>
        /// <param name="item">The item.</param>
        public ParameterItem(KeyValuePair<string, object> item)
        {
            Key = item.Key;
            Value = item.Value == null ? null : new DynamicItem(item.Value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterItem" /> class.
        /// </summary>
        public ParameterItem()
        {
        }

        #endregion Constructor
    }

    /// <summary>
    /// MessagePackRemoteInvokeMessage.
    /// </summary>
    [MessagePackObject]
    public class MessagePackRemoteInvokeMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessagePackRemoteInvokeMessage" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public MessagePackRemoteInvokeMessage(RemoteInvokeMessage message)
        {
            ServiceId = message.ServiceId;
            DecodeJOject = message.DecodeJObject;
            ServiceKey = message.ServiceKey;
            Parameters = message.Parameters?.Select(i => new ParameterItem(i)).ToArray();
            Attachments = message.Attachments?.Select(i => new ParameterItem(i)).ToArray();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessagePackRemoteInvokeMessage" /> class.
        /// </summary>
        public MessagePackRemoteInvokeMessage()
        {
        }

        /// <summary>
        /// Gets or sets the service identifier.
        /// </summary>
        [Key(0)]
        public string ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        [Key(1)]
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [decode j oject].
        /// </summary>
        [Key(2)]
        public bool DecodeJOject { get; set; }

        /// <summary>
        /// Gets or sets the service key.
        /// </summary>
        [Key(3)]
        public string ServiceKey { get; set; }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        [Key(4)]
        public ParameterItem[] Parameters { get; set; }

        /// <summary>
        /// Gets or sets the attachments.
        /// </summary>
        [Key(5)]
        public ParameterItem[] Attachments { get; set; }

        /// <summary>
        /// Gets the remote invoke message.
        /// </summary>
        /// <returns>RemoteInvokeMessage.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RemoteInvokeMessage GetRemoteInvokeMessage()
        {
            return new RemoteInvokeMessage
            {
                Parameters = Parameters?.ToDictionary(i => i.Key, i => i.Value?.Get()),
                Attachments = Attachments?.ToDictionary(i => i.Key, i => i.Value?.Get()),
                ServiceId = ServiceId,
                DecodeJObject = DecodeJOject,
                ServiceKey = ServiceKey
            };
        }
    }
}