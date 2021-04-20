using System.Runtime.CompilerServices;
using KissU.CPlatform.Messages;
using KissU.Exceptions;
using MessagePack;

namespace KissU.Tools.Cli.Internal.MessagePack.Messages
{
    [MessagePackObject]
    public class MessagePackRemoteInvokeResultMessage
    {
        #region Constructor

        public MessagePackRemoteInvokeResultMessage(RemoteInvokeResultMessage message)
        {
            Message = message.Message;
            Result = message.Result == null ? null : new DynamicItem(message.Result);
            Details = message.Details;
            ValidationErrors = message.ValidationErrors;
        }

        public MessagePackRemoteInvokeResultMessage()
        {
        }

        #endregion Constructor

        [Key(0)]
        public string Message { get; set; }

        [Key(1)]
        public string Code { get; set; }

        [Key(2)]
        public DynamicItem Result { get; set; }

        [Key(3)]
        public string Details { get; set; }

        [Key(4)]
        public RemoteServiceValidationErrorInfo[] ValidationErrors { get; set; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
    }
}

