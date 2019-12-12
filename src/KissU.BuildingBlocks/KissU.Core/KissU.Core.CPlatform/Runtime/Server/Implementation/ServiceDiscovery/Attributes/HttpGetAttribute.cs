using System.Collections.Generic;

namespace KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes
{
   public class HttpGetAttribute : HttpMethodAttribute
    {
        private static readonly IEnumerable<string> _supportedMethods = new[] { "GET" };

        public HttpGetAttribute()
            : base(_supportedMethods)
        {
        }

        public HttpGetAttribute(bool isRegisterMetadata)
            : base(_supportedMethods,  isRegisterMetadata)
        {
        }
    }
}
