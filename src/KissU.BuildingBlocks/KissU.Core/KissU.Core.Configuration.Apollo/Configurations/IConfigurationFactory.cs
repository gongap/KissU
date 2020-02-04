using Microsoft.Extensions.Configuration;

namespace KissU.Core.Configuration.Apollo.Configurations
{
    /// <summary>
    /// Interface IConfigurationFactory
    /// </summary>
    public interface IConfigurationFactory
    {
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>IConfiguration.</returns>
        IConfiguration Create();
    }
}