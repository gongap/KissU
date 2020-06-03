using System;
using KissU.Dependency;

namespace KissU.Surging.Grpc.Runtime
{
    /// <summary>
    /// GrpcServiceEntry.
    /// </summary>
    public class GrpcServiceEntry
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// Gets or sets the behavior.
        /// </summary>
        public IServiceBehavior Behavior { get; set; }
    }
}