using System;
using WebSocketCore.Server;

namespace KissU.Surging.Protocol.WS.Runtime
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
        public WebSocketBehavior Behavior { get; set; }

        /// <summary>
        /// Gets or sets the function behavior.
        /// </summary>
        public Func<WebSocketBehavior> FuncBehavior { get; set; }
    }
}