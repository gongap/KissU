using System;

namespace KissU.Thrift.Runtime
{
   public class ThriftServiceEntry
    {
        public Type Type { get; set; }

        public IThriftBehavior Behavior { get; set; }
    }
}
