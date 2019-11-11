using Surging.Core.Caching.HashAlgorithms;

namespace KissU.ApiGateway.Models
{
    public class CacheEndpointParam
    {
        public string CacheId { get; set; }

        public string Endpoint { get; set; }

        public ConsistentHashNode CacheEndpoint { get; set; }
    }
}
