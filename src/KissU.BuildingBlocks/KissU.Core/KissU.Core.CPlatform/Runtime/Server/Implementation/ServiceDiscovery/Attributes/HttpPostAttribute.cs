using System.Collections.Generic;

namespace KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes
{
    public class HttpPostAttribute : HttpMethodAttribute
    {
        private static readonly IEnumerable<string> _supportedMethods = new[] { "POST" };
         
        public HttpPostAttribute()
            : base(_supportedMethods)
        {
        }
         
        public HttpPostAttribute(bool isRegisterMetadata)
            : base(_supportedMethods, isRegisterMetadata)
        {
            
        }
    }
}