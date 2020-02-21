using System;
using System.IO;
using KissU.Core.CPlatform;
using Microsoft.Extensions.Configuration;

namespace KissU.Core.Configuration.Apollo.Configurations
{
    /// <summary>
    /// ConfigurationFactory.
    /// Implements the <see cref="KissU.Core.Configuration.Apollo.Configurations.IConfigurationFactory" />
    /// </summary>
    /// <seealso cref="KissU.Core.Configuration.Apollo.Configurations.IConfigurationFactory" />
    public class ConfigurationFactory : IConfigurationFactory
    {
        private const string CONFIG_FILE_PATH = "APOLLO__CONFIG__PATH";

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>IConfiguration.</returns>
        /// <exception cref="Exception">apollo config file not exists!</exception>
        public IConfiguration Create()
        {
            var builder = new ConfigurationBuilder();
            var environmentName = Environment.GetEnvironmentVariable("environmentname");


            builder.AddJsonFile("apollo.json", true)
                .AddJsonFile($"apollo.{environmentName}.json", true);


            if (!string.IsNullOrEmpty(AppConfig.ServerOptions.RootPath))
            {
                var skyapmPath = Path.Combine(AppConfig.ServerOptions.RootPath, "apollo.json");
                builder.AddJsonFile(skyapmPath, true);
            }


            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable(CONFIG_FILE_PATH)))
            {
                builder.AddJsonFile(Environment.GetEnvironmentVariable(CONFIG_FILE_PATH), false);
            }

            builder.AddEnvironmentVariables();

            var providers = AppConfig.Configuration.Providers;

            foreach (var provider in providers)
            {
                var fileConfigurationProvider = provider as FileConfigurationProvider;
                if (fileConfigurationProvider != null)
                {
                    builder.Add(fileConfigurationProvider.Source);
                }
            }

            var config = builder.Build();
            var section = config.GetSection("apollo");
            if (!section.Exists())
            {
                throw new Exception("apollo config file not exists!");
            }

            var apollo = builder.AddApollo(section);
            apollo.AddNamespaceKissUApollo("servicesettings");
            return config;
        }
    }
}