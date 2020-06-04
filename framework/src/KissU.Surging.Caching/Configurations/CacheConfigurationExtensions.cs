using System.IO;
using KissU.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Check = KissU.Surging.Caching.Utilities.Check;

namespace KissU.Surging.Caching.Configurations
{
    /// <summary>
    /// CacheConfigurationExtensionsstatic.
    /// </summary>
    public static class CacheConfigurationExtensionsstatic
    {
        /// <summary>
        /// Adds the cache file.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="path">The path.</param>
        /// <returns>IConfigurationBuilder.</returns>
        public static IConfigurationBuilder AddCacheFile(this IConfigurationBuilder builder, string path)
        {
            return AddCacheFile(builder, null, path, null, false, false);
        }

        /// <summary>
        /// Adds the cache file.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="path">The path.</param>
        /// <param name="optional">if set to <c>true</c> [optional].</param>
        /// <returns>IConfigurationBuilder.</returns>
        public static IConfigurationBuilder AddCacheFile(this IConfigurationBuilder builder, string path, bool optional)
        {
            return AddCacheFile(builder, null, path, null, optional, false);
        }

        /// <summary>
        /// Adds the cache file.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="path">The path.</param>
        /// <param name="optional">if set to <c>true</c> [optional].</param>
        /// <param name="reloadOnChange">if set to <c>true</c> [reload on change].</param>
        /// <returns>IConfigurationBuilder.</returns>
        public static IConfigurationBuilder AddCacheFile(this IConfigurationBuilder builder, string path, bool optional,
            bool reloadOnChange)
        {
            return AddCacheFile(builder, null, path, null, optional, reloadOnChange);
        }

        /// <summary>
        /// Adds the cache file.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="path">The path.</param>
        /// <param name="basePath">The base path.</param>
        /// <param name="optional">if set to <c>true</c> [optional].</param>
        /// <param name="reloadOnChange">if set to <c>true</c> [reload on change].</param>
        /// <returns>IConfigurationBuilder.</returns>
        public static IConfigurationBuilder AddCacheFile(this IConfigurationBuilder builder, string path,
            string basePath, bool optional, bool reloadOnChange)
        {
            return AddCacheFile(builder, null, path, basePath, optional, reloadOnChange);
        }

        /// <summary>
        /// Adds the cache file.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="path">The path.</param>
        /// <param name="basePath">The base path.</param>
        /// <param name="optional">if set to <c>true</c> [optional].</param>
        /// <param name="reloadOnChange">if set to <c>true</c> [reload on change].</param>
        /// <returns>IConfigurationBuilder.</returns>
        public static IConfigurationBuilder AddCacheFile(this IConfigurationBuilder builder, IFileProvider provider,
            string path, string basePath, bool optional, bool reloadOnChange)
        {
            Check.NotNull(builder, "builder");
            //获取一个环境变量的路径
            Check.CheckCondition(() => string.IsNullOrEmpty(path), "path");
            path = EnvironmentHelper.GetEnvironmentVariable(path);
            if (provider == null && Path.IsPathRooted(path))
            {
                provider = new PhysicalFileProvider(Path.GetDirectoryName(path));
                path = Path.GetFileName(path);
            }

            //建立CacheConfigurationSource类，此类继承了FileConfigurationSource接口，并重写加入了json转换方法
            var source = new CacheConfigurationSource
            {
                FileProvider = provider,
                Path = path,
                Optional = optional,
                ReloadOnChange = reloadOnChange
            };
            builder.Add(source);
            if (!string.IsNullOrEmpty(basePath))
                builder.SetBasePath(basePath);
            AppConfig.Path = path;
            AppConfig.Configuration = builder.Build();
            return builder;
        }
    }
}