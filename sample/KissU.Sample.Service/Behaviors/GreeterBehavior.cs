using System;
using System.Threading.Tasks;
using KissU.CPlatform.Ioc;
using KissU.CPlatform.Messages;
using KissU.GrpcTransport.Runtime;
using KissU.Msm.Sample.Service.Contracts;

namespace KissU.Msm.Sample.Service.Behaviors
{
    public partial class GreeterBehavior : Greeter.GreeterBase, IGrpcBehavior
    {
        private ServerReceivedDelegate received;
        public event ServerReceivedDelegate Received
        {
            add
            {
                if (received == null)
                {
                    received += value;
                }
            }
            remove
            {
                received -= value;
            }
        }

        public string MessageId { get; } = Guid.NewGuid().ToString("N");
        public async Task Write(object result, int statusCode = 200, string exceptionMessage = "")
        {
            if (received == null)
                return;
            var message = new TransportMessage(MessageId, new ReactiveResultMessage
            {
                ExceptionMessage = exceptionMessage,
                StatusCode = statusCode,
                Result = result

            });
            await received(message);
        }
    }
}
