using KissU.Surging.CPlatform.Messages;
using ProtoBuf;

namespace KissU.Surging.Codec.ProtoBuffer.Messages
{
    /// <summary>
    /// ProtoBufferRemoteInvokeResultMessage.
    /// </summary>
    [ProtoContract]
    public class ProtoBufferRemoteInvokeResultMessage
    {
        /// <summary>
        /// Gets or sets the exception message.
        /// </summary>
        [ProtoMember(1)]
        public string ExceptionMessage { get; set; }


        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        [ProtoMember(2)]
        public DynamicItem Result { get; set; }

        /// <summary>
        /// Gets the remote invoke result message.
        /// </summary>
        /// <returns>RemoteInvokeResultMessage.</returns>
        public RemoteInvokeResultMessage GetRemoteInvokeResultMessage()
        {
            return new RemoteInvokeResultMessage
            {
                ExceptionMessage = ExceptionMessage,
                Result = Result?.Get()
            };
        }

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProtoBufferRemoteInvokeResultMessage" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ProtoBufferRemoteInvokeResultMessage(RemoteInvokeResultMessage message)
        {
            ExceptionMessage = message.ExceptionMessage;
            Result = message.Result == null ? null : new DynamicItem(message.Result);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProtoBufferRemoteInvokeResultMessage" /> class.
        /// </summary>
        public ProtoBufferRemoteInvokeResultMessage()
        {
        }

        #endregion Constructor
    }
}