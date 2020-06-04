using System.IO;
using KissU.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace KissU.Surging.Consul.Configurations
{
    /// <summary>
    /// ConsulConfigurationExtensions.
    /// </summary>
    public static class ConsulConfigurationExtensions
    {
        /// <summary>
        /// Adds the consul file.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="path">The path.</param>
        /// <returns>IConfigurationBuilder.</returns>
        public static IConfigurationBuilder AddConsulFile(this IConfigurationBuilder builder, string path)
        {
            return AddConsulFile(builder, null, path, false, false);
        }

        /// <summary>
        /// Adds the consul file.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="path">The path.</param>
        /// <param name="optional">if set to <c>true</c> [optional].</param>
        /// <returns>IConfigurationBuilder.</returns>
        public static IConfigurationBuilder AddConsulFile(this IConfigurationBuilder builder, string path,
            bool optional)
        {
            return AddConsulFile(builder, null, path, optional, false);
        }

        /// <summary>
        /// Adds the consul file.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="path">The path.</param>
        /// <param name="optional">if set to <c>true</c> [optional].</param>
        /// <param name="reloadOnChange">if set to <c>true</c> [reload on change].</param>
        /// <returns>IConfigurationBuilder.</returns>
        public static IConfigurationBuilder AddConsulFile(this IConfigurationBuilder builder, string path,
            bool optional, bool reloadOnChange)
        {
            return AddConsulFile(builder, null, path, optional, reloadOnChange);
        }

        /// <summary>
        /// Adds the consul file.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="path">The path.</param>
        /// <param name="optional">if set to <c>true</c> [optional].</param>
        /// <param name="reloadOnChange">if set to <c>true</c> [reload on change].</param>
        /// <returns>IConfigurationBuilder.</returns>
        public static IConfigurationBuilder AddConsulFile(this IConfigurationBuilder builder, IFileProvider provider,
            string path, bool optional, bool reloadOnChange)
        {
            Check.NotNull(builder, "builder");
            Check.CheckCondition(() => string.IsNullOrEmpty(path), "path");
            path = EnvironmentHelper.GetEnvironmentVariable(path);
            if (provider == null && Path.IsPathRooted(path))
            {
                provider = new PhysicalFileProvider(Path.GetDirectoryName(path));
                path = Path.GetFileName(path);
            }

            var source = new ConsulConfigurationSource
            {
                FileProvider = provider,
                Path = path,
                Optional = optional,
                ReloadOnChange = reloadOnChange
            };
            builder.Add(source);
            AppConfig.Configuration = builder.Build();
            return builder;
        }
    }
}