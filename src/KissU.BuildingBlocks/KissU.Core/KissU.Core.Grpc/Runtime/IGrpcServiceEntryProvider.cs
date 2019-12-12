using System.Collections.Generic;

namespace KissU.Core.Grpc.Runtime
{
    public interface IGrpcServiceEntryProvider
    {
        List<GrpcServiceEntry> GetEntries();
    }
}
