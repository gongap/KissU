using System.Collections.Generic;

namespace KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes
{
    public class HttpPatchAttribute : HttpMethodAttribute
    {
        private static readonly IEnumerable<string> _supportedMethods = new[] { "PATCH" };

        public HttpPatchAttribute()
            : base(_supportedMethods)
        {
        }

        public HttpPatchAttribute(bool isRegisterMetadata)
            : base(_supportedMethods, isRegisterMetadata)
        {
        }
    }
}
