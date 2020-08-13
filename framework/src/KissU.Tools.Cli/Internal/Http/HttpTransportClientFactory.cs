using System.Net;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;

namespace KissU.Tools.Cli.Internal.Http
{
    public class HttpTransportClientFactory : ITransportClientFactory
    {
        private readonly CommandLineApplication _app;
        private readonly IConsole _console;
        private readonly IHttpClientProvider _httpClientProvider;
        public HttpTransportClientFactory(CommandLineApplication app, IConsole console, IHttpClientProvider httpClientProvider)
        {
            _app = app;
            _console = console;
            _httpClientProvider = httpClientProvider;
        }

        public Task<ITransportClient> CreateClientAsync(EndPoint endPoint)
        { 
            return Task.FromResult<ITransportClient>(new HttpTransportClient(_app,_httpClientProvider));
        }
    }
}
