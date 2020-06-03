using System;
using KissU.Dependency;

namespace KissU.Surging.Thrift.Runtime
{
   public class ThriftServiceEntry
    {
        public Type Type { get; set; }

        public IServiceBehavior Behavior { get; set; }
    }
}
