using System.Threading.Tasks;
using KissU.Extensions;
using Microsoft.Extensions.Hosting;

namespace KissU.Services
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).RunConsoleAsync();
        }

        internal static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureMicroServiceHostDefaults();

    }
}