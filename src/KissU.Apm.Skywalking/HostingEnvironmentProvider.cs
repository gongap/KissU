using Microsoft.Extensions.Hosting;
using SkyApm;

namespace KissU.Apm.Skywalking
{
    internal class HostingEnvironmentProvider : IEnvironmentProvider
    {
        public string EnvironmentName { get; }

        public HostingEnvironmentProvider(IHostEnvironment hostingEnvironment)
        {
            EnvironmentName = hostingEnvironment.EnvironmentName;
        }
    }
}
