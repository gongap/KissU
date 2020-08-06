using System;

namespace KissU.DotNetty.DNS.Runtime
{
    /// <summary>
    /// DnsServiceEntry.
    /// </summary>
    public class DnsServiceEntry
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
        public DnsBehavior Behavior { get; set; }
    }
}