using System.Threading.Tasks;
using KissU.Core.Dependency;
using KissU.Modules.QuickStart.Samples;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace KissU.Modules.QuickStart.Service
{
    [ServiceBundle("api/{Service}")]
    public interface ISampleService : IServiceKey
    {
        Task<SampleDto> GetAsync();
    }
}