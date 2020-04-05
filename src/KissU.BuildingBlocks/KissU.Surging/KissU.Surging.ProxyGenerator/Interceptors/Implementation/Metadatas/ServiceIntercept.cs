using System;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace KissU.Surging.ProxyGenerator.Interceptors.Implementation.Metadatas
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
        public abstract class ServiceIntercept : ServiceDescriptorAttribute
        {
            protected abstract string MetadataId { get; set; }
        }
}