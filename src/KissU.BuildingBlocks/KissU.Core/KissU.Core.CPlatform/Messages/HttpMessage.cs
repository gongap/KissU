using System.Collections.Generic;

namespace KissU.Core.CPlatform.Messages
{
    public  class HttpMessage
    { 
        public string RoutePath { get; set; }

        

        public string ServiceKey { get; set; } 

        public IDictionary<string,object> Parameters { get; set; }

        public IDictionary<string, object> Attachments { get; set; }
    }
}
