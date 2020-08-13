using System.Net;
using System.Threading.Tasks;
using KissU.Tools.Cli.Internal.Implementation;
using McMaster.Extensions.CommandLineUtils;
using Thrift.Protocol;
using Thrift.Transport;
using Thrift.Transport.Client;

namespace KissU.Tools.Cli.Internal.Thrift
{
   public class ThriftTransportClientFactory : ITransportClientFactory
    {
        private readonly CommandLineApplication _app;
        private readonly IConsole _console; 
        private readonly ITransportMessageEncoder _transportMessageEncoder;
        private readonly ITransportMessageDecoder _transportMessageDecoder;
       
        public ThriftTransportClientFactory(ITransportMessageCodecFactory codecFactory, CommandLineApplication app, IConsole console)
        {
            _transportMessageEncoder = codecFactory.GetEncoder();
            _transportMessageDecoder = codecFactory.GetDecoder();
            _app = app;
            _console = console; 
        }

        public async Task<ITransportClient> CreateClientAsync(EndPoint endPoint)
        {
            try
            { 
                        var ipEndPoint = endPoint as IPEndPoint;
                        var transport = new TSocketTransport(ipEndPoint.Address.ToString(), ipEndPoint.Port);
                        var tran = new TFramedTransport(transport);
                        var protocol = new TBinaryProtocol(tran);
                        var mp = new TMultiplexedProtocol(protocol, "thrift.surging");
                        var messageListener = new MessageListener();
                        var messageSender = new ThriftMessageClientSender(_transportMessageEncoder, protocol);
                        var result = new TThriftClient(protocol, messageSender, messageListener, new ChannelHandler(_transportMessageDecoder, messageListener, messageSender), _app);
                        await result.OpenTransportAsync();
                        return result; 
            }
            catch
            { 
                throw;
            }
        }
    }
}
