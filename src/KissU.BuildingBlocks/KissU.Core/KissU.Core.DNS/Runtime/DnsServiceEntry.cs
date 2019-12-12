using System;

namespace KissU.Core.DNS.Runtime
{
   public class DnsServiceEntry
    {
        public string Path { get; set; }

        public Type Type { get; set; }

        public DnsBehavior Behavior { get; set; }

    }
}
