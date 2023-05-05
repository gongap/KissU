using KissU.CPlatform.Messages;
using KissU.Exceptions;
using ProtoBuf;

namespace KissU.Codec.ProtoBuffer.Messages
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
        public string Message { get; set; }

        [ProtoMember(2)]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        [ProtoMember(3)]
        public DynamicItem Result { get; set; }

        /// <summary>
        /// Error details.
        /// </summary>
        [ProtoMember(4)]
        public string Details { get; set; }

        /// <summary>
        /// Gets or sets the validation errors.
        /// </summary>
        [ProtoMember(5)]
        public RemoteServiceValidationErrorInfo[] ValidationErrors { get; set; }

        /// <summary>
        /// Gets the remote invoke result message.
        /// </summary>
        /// <returns>RemoteInvokeResultMessage.</returns>
        public RemoteInvokeResultMessage GetRemoteInvokeResultMessage()
        {
            return new RemoteInvokeResultMessage
            {
                Message = Message,
                Code = Code,
                Result = Result?.Get(),
                Details = Details,
                ValidationErrors = ValidationErrors,
            };
        }

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProtoBufferRemoteInvokeResultMessage" /> class.
        /// </summary>
        /// <param name="result">The message.</param>
        public ProtoBufferRemoteInvokeResultMessage(RemoteInvokeResultMessage result)
        {
            Message = result.Message;
            Code = result.Code;
            Result = result.Result == null ? null : new DynamicItem(result.Result);
            Details = result.Details;
            ValidationErrors = result.ValidationErrors;
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