using System;

namespace KissU.WebSocket.Configurations
{
    /// <summary>
    /// WebSocketOptions.
    /// </summary>
    public class WebSocketOptions
    {
        /// <summary>
        /// Gets or sets the time to wait for the response to the WebSocket Ping or
        /// Close.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">The value specified for a set operation is zero or less.</exception>
        /// <remarks>
        /// The set operation does nothing if the server has already started or
        /// it is shutting down.
        /// </remarks>
        public int WaitTime { get; set; } = 1;

        /// <summary>
        /// Gets or sets a value indicating whether [keep clean].
        /// </summary>
        public bool KeepClean { get; set; }
            = false;

        /// <summary>
        /// Gets or sets the behavior.
        /// </summary>
        public BehaviorOption Behavior { get; set; }
    }
}