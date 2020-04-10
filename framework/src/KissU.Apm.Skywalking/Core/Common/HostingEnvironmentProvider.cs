using KissU.Apm.Skywalking.Abstractions;

namespace KissU.Apm.Skywalking.Core.Common
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
