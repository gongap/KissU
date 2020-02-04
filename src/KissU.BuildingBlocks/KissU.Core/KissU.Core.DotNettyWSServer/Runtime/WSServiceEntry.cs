using System;

namespace KissU.Core.DotNettyWSServer.Runtime
{
    /// <summary>
    /// WSServiceEntry.
    /// </summary>
    public class WSServiceEntry
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
        public WSBehavior Behavior { get; set; }
    }
}