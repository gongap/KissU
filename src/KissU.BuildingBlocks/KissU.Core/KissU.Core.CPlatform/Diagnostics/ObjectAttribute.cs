using System;

namespace KissU.Core.CPlatform.Diagnostics
{
    /// <summary>
    /// ObjectAttribute.
    /// Implements the <see cref="KissU.Core.CPlatform.Diagnostics.ParameterBinder" />
    /// </summary>
    /// <seealso cref="KissU.Core.CPlatform.Diagnostics.ParameterBinder" />
    public class ObjectAttribute: ParameterBinder
    {
        /// <summary>
        /// Gets or sets the type of the target.
        /// </summary>
        public Type TargetType { get; set; }

        /// <summary>
        /// Resolves the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Object.</returns>
        public override object Resolve(object value)
        {
            if (TargetType == null || value == null)
            {
                return value;
            }

            if (TargetType == value.GetType())
            {
                return value;
            }

            if (TargetType.IsInstanceOfType(value))
            {
                return value;
            }

            return null;
        }
    }
}
