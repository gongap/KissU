using System;
using KissU.Dependency;

namespace KissU.Thrift.Runtime
{
   public class ThriftServiceEntry
    {
        public Type Type { get; set; }

        public IServiceBehavior Behavior { get; set; }
    }
}
