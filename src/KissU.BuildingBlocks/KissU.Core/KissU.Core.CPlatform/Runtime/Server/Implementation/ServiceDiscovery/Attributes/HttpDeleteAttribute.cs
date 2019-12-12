using System.Collections.Generic;

namespace KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes
{
   public class HttpDeleteAttribute : HttpMethodAttribute
    {
        private static readonly IEnumerable<string> _supportedMethods = new[] { "DELETE" };

        public HttpDeleteAttribute()
            : base(_supportedMethods)
        {
        }

        public HttpDeleteAttribute(bool isRegisterMetadata)
            : base(_supportedMethods,isRegisterMetadata)
        {
          
        }
    }
}
