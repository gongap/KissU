namespace KissU.Surging.Protocol.WS.Configurations
{
    /// <summary>
    /// BehaviorOption.
    /// </summary>
    public class BehaviorOption
    {
        /// <summary>
        /// Gets or sets a value indicating whether [ignore extensions].
        /// </summary>
        public bool IgnoreExtensions { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [emit on ping].
        /// </summary>
        public bool EmitOnPing { get; set; }

        /// <summary>
        /// Gets or sets the protocol.
        /// </summary>
        public string Protocol { get; set; }
    }
}