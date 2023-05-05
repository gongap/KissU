using System;

namespace KissU.DotNetty.Tcp.Runtime
{
    /// <summary>
    /// TcpServiceEntry.
    /// </summary>
    public class TcpServiceEntry
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
        public TcpBehavior Behavior { get; set; }
    }
}
