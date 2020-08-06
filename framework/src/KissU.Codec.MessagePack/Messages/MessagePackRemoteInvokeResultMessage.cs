using System.Runtime.CompilerServices;
using KissU.CPlatform.Messages;
using MessagePack;

namespace KissU.Codec.MessagePack.Messages
{
    /// <summary>
    /// MessagePackRemoteInvokeResultMessage.
    /// </summary>
    [MessagePackObject]
    public class MessagePackRemoteInvokeResultMessage
    {
        /// <summary>
        /// Gets or sets the exception message.
        /// </summary>
        [Key(0)]
        public string ExceptionMessage { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        [Key(1)]
        public DynamicItem Result { get; set; }

        /// <summary>
        /// Gets the remote invoke result message.
        /// </summary>
        /// <returns>RemoteInvokeResultMessage.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        /// Initializes a new instance of the <see cref="MessagePackRemoteInvokeResultMessage" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public MessagePackRemoteInvokeResultMessage(RemoteInvokeResultMessage message)
        {
            ExceptionMessage = message.ExceptionMessage;
            Result = message.Result == null ? null : new DynamicItem(message.Result);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessagePackRemoteInvokeResultMessage" /> class.
        /// </summary>
        public MessagePackRemoteInvokeResultMessage()
        {
        }

        #endregion Constructor
    }
}