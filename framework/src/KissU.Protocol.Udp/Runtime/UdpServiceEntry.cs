using System;

namespace KissU.Protocol.Udp.Runtime
{
    /// <summary>
    /// UdpServiceEntry.
    /// </summary>
    public class UdpServiceEntry
    {
        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// Gets or sets the behavior.
        /// </summary>
        public UdpBehavior Behavior { get; set; }
    }
}