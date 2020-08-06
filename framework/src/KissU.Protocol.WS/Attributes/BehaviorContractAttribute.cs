using System;

namespace KissU.Protocol.WS.Attributes
{
    /// <summary>
    /// BehaviorContractAttribute.
    /// Implements the <see cref="System.Attribute" />
    /// </summary>
    /// <seealso cref="System.Attribute" />
    public class BehaviorContractAttribute : Attribute
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