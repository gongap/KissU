using System;
using System.Collections.Generic;
using Com.Ctrip.Framework.Apollo;
using Com.Ctrip.Framework.Apollo.Core.Utils;
using Com.Ctrip.Framework.Apollo.Internals;
using KissU.Core.Helpers.Utilities;
using Microsoft.Extensions.Configuration;

namespace KissU.Surging.Configuration.Apollo.Configurations
{
    /// <summary>
    /// KissUApolloConfigurationProvider.
    /// Implements the <see cref="Com.Ctrip.Framework.Apollo.ApolloConfigurationProvider" />
    /// </summary>
    /// <seealso cref="Com.Ctrip.Framework.Apollo.ApolloConfigurationProvider" />
    public class KissUApolloConfigurationProvider : ApolloConfigurationProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KissUApolloConfigurationProvider" /> class.
        /// </summary>
        /// <param name="sectionKey">The section key.</param>
        /// <param name="configRepository">The configuration repository.</param>
        public KissUApolloConfigurationProvider(string sectionKey, IConfigRepository configRepository) : base(
            sectionKey, configRepository)
        {
            SectionKey = sectionKey;
            ConfigRepository = configRepository;
        }

        /// <summary>
        /// Gets the section key.
        /// </summary>
        internal string SectionKey { get; }

        /// <summary>
        /// Gets the configuration repository.
        /// </summary>
        internal IConfigRepository ConfigRepository { get; }

        /// <summary>
        /// Sets the data.
        /// </summary>
        /// <param name="properties">The properties.</param>
        protected override void SetData(Properties properties)
        {
            var data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            foreach (var key in properties.GetPropertyNames())
            {
                if (string.IsNullOrEmpty(SectionKey))
                    data[key] = EnvironmentHelper.GetEnvironmentVariable(properties.GetProperty(key) ?? string.Empty);
                else
                    data[$"{SectionKey}{ConfigurationPath.KeyDelimiter}{key}"] =
                        EnvironmentHelper.GetEnvironmentVariable(properties.GetProperty(key) ?? string.Empty);
            }

            Data = data;
        }
    }
}