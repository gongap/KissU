using System;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace KissU.Core.CPlatform.Configurations.Remote
{
    /// <summary>
    /// 远程配置源.
    /// Implements the <see cref="IConfigurationSource" />
    /// </summary>
    /// <seealso cref="IConfigurationSource" />
    public class RemoteConfigurationSource : IConfigurationSource
    {
        /// <summary>
        /// The uri to call to fetch
        /// </summary>
        public Uri ConfigurationUri { get; set; }

        /// <summary>
        /// Determines if the remote source is optional
        /// </summary>
        public bool Optional { get; set; }

        /// <summary>
        /// 用于与远程配置提供程序通信的HttpMessageHandler.
        /// </summary>
        public HttpMessageHandler BackchannelHttpHandler { get; set; }

        /// <summary>
        /// 与远程标识提供者的反向通道通信的超时值（以毫秒为单位）.
        /// </summary>
        public TimeSpan BackchannelTimeout { get; set; } = TimeSpan.FromSeconds(60);

        /// <summary>
        /// Parser for parsing the returned data into the required configuration source
        /// </summary>
        public IConfigurationParser Parser { get; set; }

        /// <summary>
        /// The accept header used to create a MediaTypeWithQualityHeaderValue
        /// </summary>
        public string MediaType { get; set; } = "application/json";

        /// <summary>
        /// Events providing hooks into the remote call
        /// </summary>
        public RemoteConfigurationEvents Events { get; set; } = new RemoteConfigurationEvents();

        /// <summary>
        /// If provided, keys loaded from endpoint will be prefixed with the provided value
        /// </summary>
        public string ConfigurationKeyPrefix { get; set; }

        /// <summary>
        /// Build the <see cref="T:Microsoft.Extensions.Configuration.IConfigurationProvider" /> for this source.
        /// </summary>
        /// <param name="builder">The <see cref="T:Microsoft.Extensions.Configuration.IConfigurationBuilder" />.</param>
        /// <returns>An <see cref="T:Microsoft.Extensions.Configuration.IConfigurationProvider" /></returns>
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new RemoteConfigurationProvider(this);
        }
    }
}