using System;

namespace KissU.Core.CPlatform.Diagnostics
{
    /// <summary>
    /// ParameterBinder.
    /// Implements the <see cref="System.Attribute" />
    /// Implements the <see cref="KissU.Core.CPlatform.Diagnostics.IParameterResolver" />
    /// </summary>
    /// <seealso cref="System.Attribute" />
    /// <seealso cref="KissU.Core.CPlatform.Diagnostics.IParameterResolver" />
    public abstract class ParameterBinder : Attribute, IParameterResolver
    {
        /// <summary>
        /// Resolves the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Object.</returns>
        public abstract object Resolve(object value);
    }
}
