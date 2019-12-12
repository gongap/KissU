using System;
using KissU.Core.CPlatform.Ioc;

namespace KissU.Core.Grpc.Runtime
{
   public class GrpcServiceEntry
    { 

        public Type Type { get; set; }

        public IServiceBehavior Behavior { get; set; }
    }
}
