using System;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace KissU.ServiceProxy.Interceptors.Implementation.Metadatas
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
        public abstract class ServiceIntercept : ServiceDescriptorAttribute
        {
            protected abstract string MetadataId { get; set; }
        }
}