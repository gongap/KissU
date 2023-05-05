using System.Collections.Generic;

namespace KissU.Msm.Sample.Service.Contracts.Models
{
   public class Message
    {
        public string RoutePath { get; set; }

        public string ServiceKey { get; set; }

        public IDictionary<string, object> Parameters { get; set; }
    }
}
