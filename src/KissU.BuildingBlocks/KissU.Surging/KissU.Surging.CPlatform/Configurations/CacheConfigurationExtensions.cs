using System.IO;
using KissU.Surging.CPlatform.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace KissU.Surging.CPlatform.Configurations
{
    /// <summary>
    /// 缓存配置扩展.
    /// </summary>
    public static class CacheConfigurationExtensions
    {
        /// <summary>
        /// Adds the platform file.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="path">The path.</param>
        /// <returns>IConfigurationBuilder.</returns>
        public static IConfigurationBuilder AddCPlatformFile(this IConfigurationBuilder builder, string path)
        {
            return AddCPlatformFile(builder, null, path, null, false, false);
        }

        /// <summary>
        /// Adds the platform file.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="path">The path.</param>
        /// <param name="optional">if set to <c>true</c> [optional].</param>
        /// <returns>IConfigurationBuilder.</returns>
        public static IConfigurationBuilder AddCPlatformFile(this IConfigurationBuilder builder, string path,
            bool optional)
        {
            return AddCPlatformFile(builder, null, path, null, optional, false);
        }

        /// <summary>
        /// Adds the platform file.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="path">The path.</param>
        /// <param name="optional">if set to <c>true</c> [optional].</param>
        /// <param name="reloadOnChange">if set to <c>true</c> [reload on change].</param>
        /// <returns>IConfigurationBuilder.</returns>
        public static IConfigurationBuilder AddCPlatformFile(this IConfigurationBuilder builder, string path,
            bool optional, bool reloadOnChange)
        {
            return AddCPlatformFile(builder, null, path, null, optional, reloadOnChange);
        }

        /// <summary>
        /// Adds the platform file.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="path">The path.</param>
        /// <param name="basePath">The base path.</param>
        /// <param name="optional">if set to <c>true</c> [optional].</param>
        /// <param name="reloadOnChange">if set to <c>true</c> [reload on change].</param>
        /// <returns>IConfigurationBuilder.</returns>
        public static IConfigurationBuilder AddCPlatformFile(this IConfigurationBuilder builder, string path,
            string basePath, bool optional, bool reloadOnChange)
        {
            return AddCPlatformFile(builder, null, path, basePath, optional, reloadOnChange);
        }

        /// <summary>
        /// Adds the platform file.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="path">The path.</param>
        /// <param name="basePath">The base path.</param>
        /// <param name="optional">if set to <c>true</c> [optional].</param>
        /// <param name="reloadOnChange">if set to <c>true</c> [reload on change].</param>
        /// <returns>IConfigurationBuilder.</returns>
        public static IConfigurationBuilder AddCPlatformFile(this IConfigurationBuilder builder, IFileProvider provider,
            string path, string basePath, bool optional, bool reloadOnChange)
        {
            Check.NotNull(builder, "builder");
            Check.CheckCondition(() => string.IsNullOrEmpty(path), "path");
            path = EnvironmentHelper.GetEnvironmentVariable(path);
            if (File.Exists(path))
            {
                if (provider == null && Path.IsPathRooted(path))
                {
                    provider = new PhysicalFileProvider(Path.GetDirectoryName(path));
                    path = Path.GetFileName(path);
                }

                var source = new CPlatformConfigurationSource
                {
                    FileProvider = provider,
                    Path = path,
                    Optional = optional,
                    ReloadOnChange = reloadOnChange
                };

                builder.Add(source);
                if (!string.IsNullOrEmpty(basePath))
                {
                    builder.SetBasePath(basePath);
                }

                AppConfig.Configuration = builder.Build();
                AppConfig.ServerOptions = AppConfig.Configuration.Get<ServerEngineOptions>();
                var section = AppConfig.Configuration.GetSection("ServerEngine");
                if (section.Exists())
                {
                    AppConfig.ServerOptions =
                        AppConfig.Configuration.GetSection("ServerEngine").Get<ServerEngineOptions>();
                }
            }

            return builder;
        }
    }
}