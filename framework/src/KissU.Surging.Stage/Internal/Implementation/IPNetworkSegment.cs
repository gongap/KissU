using System.Net;

namespace KissU.Surging.Stage.Internal.Implementation
{
    /// <summary>
    /// IPNetworkSegment.
    /// </summary>
    public class IPNetworkSegment
    {
        /// <summary>
        /// Gets or sets the last usable.
        /// </summary>
        public IPAddress LastUsable { get; set; }

        /// <summary>
        /// Gets or sets the long last usable.
        /// </summary>
        public long LongLastUsable { get; set; }

        /// <summary>
        /// Gets or sets the cidr.
        /// </summary>
        public byte Cidr { get; set; }

        /// <summary>
        /// Gets or sets the first usable.
        /// </summary>
        public IPAddress FirstUsable { get; set; }

        /// <summary>
        /// Gets or sets the long first usable.
        /// </summary>
        public long LongFirstUsable { get; set; }
    }
}