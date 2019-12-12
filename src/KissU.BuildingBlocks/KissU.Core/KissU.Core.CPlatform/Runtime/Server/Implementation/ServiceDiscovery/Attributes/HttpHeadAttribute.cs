using System.Collections.Generic;

namespace KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes
{
   public class HttpHeadAttribute : HttpMethodAttribute
    {
        private static readonly IEnumerable<string> _supportedMethods = new[] { "HEAD" };

        public HttpHeadAttribute()
            : base(_supportedMethods)
        {
        }

        public HttpHeadAttribute(bool isRegisterMetadata)
            : base(_supportedMethods, isRegisterMetadata)
        {
        }
    }
}
