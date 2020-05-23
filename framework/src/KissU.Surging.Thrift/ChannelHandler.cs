using System.Threading.Tasks;
using KissU.Surging.CPlatform.Transport;
using KissU.Surging.CPlatform.Transport.Codec;
using Microsoft.Extensions.Logging;
using Thrift.Protocol;

namespace KissU.Surging.Thrift
{
    public class ChannelHandler
    {
        private readonly ILogger _logger; 
        private readonly ITransportMessageDecoder _transportMessageDecoder;
        private readonly IMessageListener _messageListener;
        private readonly IMessageSender _messageSender;

        public ChannelHandler(ITransportMessageDecoder transportMessageDecoder, IMessageListener messageListener, IMessageSender  messageSender, ILogger logger)
        {
            _transportMessageDecoder = transportMessageDecoder; 
            _logger = logger;
            _messageListener = messageListener;
            _messageSender = messageSender;
        }

        public async Task ChannelRead(TProtocol context)
        {
            var msg = await context.ReadMessageBeginAsync();
            var message = _transportMessageDecoder.Decode(await context.ReadBinaryAsync()); 
            await context.ReadMessageEndAsync();
            await _messageListener.OnReceived(_messageSender, message);
        }
    }
}
