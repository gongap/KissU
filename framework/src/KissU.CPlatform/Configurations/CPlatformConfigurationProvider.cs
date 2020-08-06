using System.IO;
using KissU.CPlatform.Configurations.Remote;
using Microsoft.Extensions.Configuration;

namespace KissU.CPlatform.Configurations
{
    /// <summary>
    /// 平台配置提供商.
    /// Implements the <see cref="FileConfigurationProvider" />
    /// </summary>
    /// <seealso cref="FileConfigurationProvider" />
    public class CPlatformConfigurationProvider : FileConfigurationProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CPlatformConfigurationProvider" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        public CPlatformConfigurationProvider(CPlatformConfigurationSource source) : base(source)
        {
        }

        /// <summary>
        /// Loads this provider's data from a stream.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        public override void Load(Stream stream)
        {
            var parser = new JsonConfigurationParser();
            Data = parser.Parse(stream, null);
        }
    }
}