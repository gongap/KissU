using System;

namespace KissU.GrpcTransport.Runtime
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
        public IGrpcBehavior Behavior { get; set; }
    }
}