using System.Runtime.CompilerServices;
using KissU.CPlatform.Messages;
using KissU.Exceptions;
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
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        [Key(1)]
        public DynamicItem Result { get; set; }

        /// <summary>
        /// Error details.
        /// </summary>
        [Key(2)]
        public string Details { get; set; }

        /// <summary>
        /// Gets or sets the validation errors.
        /// </summary>
        [Key(3)]
        public RemoteServiceValidationErrorInfo[] ValidationErrors { get; set; }

        /// <summary>
        /// Gets the remote invoke result message.
        /// </summary>
        /// <returns>RemoteInvokeResultMessage.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RemoteInvokeResultMessage GetRemoteInvokeResultMessage()
        {
            return new RemoteInvokeResultMessage
            {
                Message = Message,
                Result = Result?.Get(),
                Details  = Details,
                ValidationErrors = ValidationErrors,
            };
        }

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MessagePackRemoteInvokeResultMessage" /> class.
        /// </summary>
        /// <param name="result">The message.</param>
        public MessagePackRemoteInvokeResultMessage(RemoteInvokeResultMessage result)
        {
            Message = result.Message;
            Result = result.Result == null ? null : new DynamicItem(result.Result);
            Details = result.Details;
            ValidationErrors = result.ValidationErrors;
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