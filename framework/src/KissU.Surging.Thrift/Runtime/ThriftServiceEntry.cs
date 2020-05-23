using System;
using KissU.Core.Dependency;

namespace KissU.Surging.Thrift.Runtime
{
   public class ThriftServiceEntry
    {
        public Type Type { get; set; }

        public IServiceBehavior Behavior { get; set; }
    }
}
