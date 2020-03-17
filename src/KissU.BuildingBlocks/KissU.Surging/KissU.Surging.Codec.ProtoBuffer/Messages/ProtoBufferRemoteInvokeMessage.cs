using System.Collections.Generic;
using System.Linq;
using KissU.Surging.CPlatform.Messages;
using ProtoBuf;

namespace KissU.Surging.Codec.ProtoBuffer.Messages
{
    /// <summary>
    /// ParameterItem.
    /// </summary>
    [ProtoContract]
    public class ParameterItem
    {
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        [ProtoMember(1)]
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [ProtoMember(2)]
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
    /// ProtoBufferRemoteInvokeMessage.
    /// </summary>
    [ProtoContract]
    public class ProtoBufferRemoteInvokeMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProtoBufferRemoteInvokeMessage" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ProtoBufferRemoteInvokeMessage(RemoteInvokeMessage message)
        {
            ServiceId = message.ServiceId;
            DecodeJOject = message.DecodeJObject;
            ServiceKey = message.ServiceKey;
            Parameters = message.Parameters?.Select(i => new ParameterItem(i)).ToArray();
            Attachments = message.Attachments?.Select(i => new ParameterItem(i)).ToArray();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProtoBufferRemoteInvokeMessage" /> class.
        /// </summary>
        public ProtoBufferRemoteInvokeMessage()
        {
        }

        /// <summary>
        /// Gets or sets the service identifier.
        /// </summary>
        [ProtoMember(1)]
        public string ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        [ProtoMember(2)]
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [decode j oject].
        /// </summary>
        [ProtoMember(3)]
        public bool DecodeJOject { get; set; }

        /// <summary>
        /// Gets or sets the service key.
        /// </summary>
        [ProtoMember(4)]
        public string ServiceKey { get; set; }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        [ProtoMember(5)]
        public ParameterItem[] Parameters { get; set; }

        /// <summary>
        /// Gets or sets the attachments.
        /// </summary>
        [ProtoMember(6)]
        public ParameterItem[] Attachments { get; set; }


        /// <summary>
        /// Gets the remote invoke message.
        /// </summary>
        /// <returns>RemoteInvokeMessage.</returns>
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