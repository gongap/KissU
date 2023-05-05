namespace KissU.CPlatform.Diagnostics
{
    /// <summary>
    /// Interface IParameterResolver
    /// </summary>
    public interface IParameterResolver
    {
        /// <summary>
        /// Resolves the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Object.</returns>
        object Resolve(object value);
    }
}