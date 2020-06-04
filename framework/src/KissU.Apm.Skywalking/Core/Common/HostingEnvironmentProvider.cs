using KissU.Surging.Apm.Skywalking.Abstractions;

namespace KissU.Surging.Apm.Skywalking.Core.Common
{
    internal class HostingEnvironmentProvider : IEnvironmentProvider
    {
        public string EnvironmentName { get; }

        public HostingEnvironmentProvider()
        {
            EnvironmentName ="";
        }
    }
}
