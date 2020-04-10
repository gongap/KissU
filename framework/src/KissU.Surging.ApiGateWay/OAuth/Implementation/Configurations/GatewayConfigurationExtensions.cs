using System.IO;
using KissU.Core.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace KissU.Surging.ApiGateWay.OAuth.Implementation.Configurations
{
    /// <summary>
    /// GatewayConfigurationExtensions.
    /// </summary>
    public static class GatewayConfigurationExtensions
    {
        /// <summary>
        /// Adds the gateway file.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="path">The path.</param>
        /// <returns>IConfigurationBuilder.</returns>
        public static IConfigurationBuilder AddGatewayFile(this IConfigurationBuilder builder, string path)
        {
            return AddGatewayFile(builder, null, path, false, false);
        }

        /// <summary>
        /// Adds the gateway file.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="path">The path.</param>
        /// <param name="optional">if set to <c>true</c> [optional].</param>
        /// <returns>IConfigurationBuilder.</returns>
        public static IConfigurationBuilder AddGatewayFile(this IConfigurationBuilder builder, string path,
            bool optional)
        {
            return AddGatewayFile(builder, null, path, optional, false);
        }

        /// <summary>
        /// Adds the gateway file.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="path">The path.</param>
        /// <param name="optional">if set to <c>true</c> [optional].</param>
        /// <param name="reloadOnChange">if set to <c>true</c> [reload on change].</param>
        /// <returns>IConfigurationBuilder.</returns>
        public static IConfigurationBuilder AddGatewayFile(this IConfigurationBuilder builder, string path,
            bool optional, bool reloadOnChange)
        {
            return AddGatewayFile(builder, null, path, optional, reloadOnChange);
        }

        /// <summary>
        /// Adds the gateway file.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="path">The path.</param>
        /// <param name="optional">if set to <c>true</c> [optional].</param>
        /// <param name="reloadOnChange">if set to <c>true</c> [reload on change].</param>
        /// <returns>IConfigurationBuilder.</returns>
        public static IConfigurationBuilder AddGatewayFile(this IConfigurationBuilder builder, IFileProvider provider,
            string path, bool optional, bool reloadOnChange)
        {
            Check.NotNull(builder, "builder");
            Check.CheckCondition(() => string.IsNullOrEmpty(path), "path");
            if (provider == null && Path.IsPathRooted(path))
            {
                provider = new PhysicalFileProvider(Path.GetDirectoryName(path));
                path = Path.GetFileName(path);
            }

            var source = new GatewayConfigurationSource
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