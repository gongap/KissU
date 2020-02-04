using System.IO;
using KissU.Core.CPlatform.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace KissU.Core.EventBusRabbitMQ.Configurations
{
    /// <summary>
    /// EventBusConfigurationExtensions.
    /// </summary>
    public static class EventBusConfigurationExtensions
    {
        /// <summary>
        /// Adds the event bus file.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="path">The path.</param>
        /// <returns>IConfigurationBuilder.</returns>
        public static IConfigurationBuilder AddEventBusFile(this IConfigurationBuilder builder, string path)
        {
            return AddEventBusFile(builder, provider: null, path: path, basePath: null, optional: false, reloadOnChange: false);
        }

        /// <summary>
        /// Adds the event bus file.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="path">The path.</param>
        /// <param name="optional">if set to <c>true</c> [optional].</param>
        /// <returns>IConfigurationBuilder.</returns>
        public static IConfigurationBuilder AddEventBusFile(this IConfigurationBuilder builder, string path, bool optional)
        {
            return AddEventBusFile(builder, provider: null, path: path, basePath: null, optional: optional, reloadOnChange: false);
        }

        /// <summary>
        /// Adds the event bus file.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="path">The path.</param>
        /// <param name="optional">if set to <c>true</c> [optional].</param>
        /// <param name="reloadOnChange">if set to <c>true</c> [reload on change].</param>
        /// <returns>IConfigurationBuilder.</returns>
        public static IConfigurationBuilder AddEventBusFile(this IConfigurationBuilder builder, string path, bool optional, bool reloadOnChange)
        {
            return AddEventBusFile(builder, provider: null, path: path,basePath:null, optional: optional, reloadOnChange: reloadOnChange);
        }

        /// <summary>
        /// Adds the event bus file.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="path">The path.</param>
        /// <param name="basePath">The base path.</param>
        /// <param name="optional">if set to <c>true</c> [optional].</param>
        /// <param name="reloadOnChange">if set to <c>true</c> [reload on change].</param>
        /// <returns>IConfigurationBuilder.</returns>
        public static IConfigurationBuilder AddEventBusFile(this IConfigurationBuilder builder, string path,string basePath, bool optional, bool reloadOnChange)
        {
            return AddEventBusFile(builder, provider: null, path: path, basePath:basePath, optional: optional, reloadOnChange: reloadOnChange);
        }

        /// <summary>
        /// Adds the event bus file.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="path">The path.</param>
        /// <param name="basePath">The base path.</param>
        /// <param name="optional">if set to <c>true</c> [optional].</param>
        /// <param name="reloadOnChange">if set to <c>true</c> [reload on change].</param>
        /// <returns>IConfigurationBuilder.</returns>
        public static IConfigurationBuilder AddEventBusFile(this IConfigurationBuilder builder, IFileProvider provider, string path,string basePath, bool optional, bool reloadOnChange)
        {
            Check.NotNull(builder, "builder");
            Check.CheckCondition(() => string.IsNullOrEmpty(path), "path");
            if (provider == null && Path.IsPathRooted(path))
            {
                provider = new PhysicalFileProvider(Path.GetDirectoryName(path));
                path = Path.GetFileName(path);
            }
              
            var source = new EventBusConfigurationSource
            {
                FileProvider = provider,
                Path = path,
                Optional = optional,
                ReloadOnChange = reloadOnChange
            };
            builder.Add(source);
            if (!string.IsNullOrEmpty(basePath))
                builder.SetBasePath(basePath);
            AppConfig.Configuration = builder.Build();
            return builder;
        }
    }
}