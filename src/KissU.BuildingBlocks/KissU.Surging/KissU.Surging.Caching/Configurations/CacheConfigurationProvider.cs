using System.IO;
using KissU.Surging.CPlatform.Configurations.Remote;
using Microsoft.Extensions.Configuration;

namespace KissU.Surging.Caching.Configurations
{
    /// <summary>
    /// CacheConfigurationProvider.
    /// Implements the <see cref="Microsoft.Extensions.Configuration.FileConfigurationProvider" />
    /// </summary>
    /// <seealso cref="Microsoft.Extensions.Configuration.FileConfigurationProvider" />
    internal class CacheConfigurationProvider : FileConfigurationProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CacheConfigurationProvider" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        public CacheConfigurationProvider(CacheConfigurationSource source) : base(source)
        {
        }

        /// <summary>
        /// 重写数据转换方法
        /// </summary>
        /// <param name="stream">The stream.</param>
        public override void Load(Stream stream)
        {
            var parser = new JsonConfigurationParser();
            Data = parser.Parse(stream, null);
        }
    }
}