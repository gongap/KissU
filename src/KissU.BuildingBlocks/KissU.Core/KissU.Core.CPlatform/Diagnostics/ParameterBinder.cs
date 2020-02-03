using System;

namespace KissU.Core.CPlatform.Diagnostics
{
    /// <summary>
    /// ParameterBinder.
    /// Implements the <see cref="Attribute" />
    /// Implements the <see cref="IParameterResolver" />
    /// </summary>
    /// <seealso cref="Attribute" />
    /// <seealso cref="IParameterResolver" />
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