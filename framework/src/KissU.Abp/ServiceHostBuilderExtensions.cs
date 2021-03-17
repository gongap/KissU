using System;
using Autofac;
using KissU.CPlatform;
using KissU.Extensions;
using KissU.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.Modularity.PlugIns;

namespace KissU.Abp
{
    /// <summary>
    /// 服务构建器扩展.
    /// </summary>
    public static class HostBuilderExtensions
    {
        /// <summary>
        /// Uses the server.
        /// </summary>
        /// <param name="hostBuilder">The host builder.</param>
        /// <param name="options">The options.</param>
        /// <returns>IHostBuilder.</returns>
        public static IHostBuilder AddAbp(this IHostBuilder hostBuilder, Action<AbpApplicationCreationOptions> optionsAction = null)
        {
            return hostBuilder.ConfigureServices(services =>
            {
                services.AddApplication<AbpStartupModule>(options =>
                {
                    optionsAction?.Invoke(options);
                    var assemblies = ModuleHelper.GetAssemblies();
                    var moduleTypes = ReflectionHelper.FindTypes<AbpBusinessModule>(assemblies.ToArray());
                    options.PlugInSources.AddTypes(moduleTypes.ToArray());
                });
            });
        }

        /// <summary>
        /// Uses the server.
        /// </summary>
        /// <param name="hostBuilder">The host builder.</param>
        /// <param name="options">The options.</param>
        /// <returns>IHostBuilder.</returns>
        public static IHostBuilder UseAbp(this IHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureContainer(async mapper =>
            {
                var serviceProvider = mapper.Resolve<IServiceProvider>();
                mapper.Resolve<IAbpApplicationWithExternalServiceProvider>().Initialize(serviceProvider);
            });
        }
    }
}