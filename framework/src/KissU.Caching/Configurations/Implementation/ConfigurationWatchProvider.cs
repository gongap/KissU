using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using KissU.Dependency;
using KissU.Caching.HashAlgorithms;
using KissU.Caching.Models;
using KissU.CPlatform.Cache;
using KissU.CPlatform.Cache.Implementation;
using KissU.CPlatform.Configurations;
using KissU.CPlatform.Configurations.Watch;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace KissU.Caching.Configurations.Implementation
{
    /// <summary>
    /// 配置watch提供者
    /// </summary>
    public class ConfigurationWatchProvider : ConfigurationWatch, IConfigurationWatchProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationWatchProvider" /> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="serviceCacheManager">The service cache manager.</param>
        public ConfigurationWatchProvider(CPlatformContainer serviceProvider,
            ILogger<ConfigurationWatchProvider> logger, IServiceCacheManager serviceCacheManager)
        {
            if (serviceProvider.IsRegistered<IConfigurationWatchManager>())
                serviceProvider.GetInstances<IConfigurationWatchManager>().Register(this);
            _logger = logger;
            _cachingProvider = AppConfig.Configuration.Get<CachingProvider>();
            _serviceCacheManager = serviceCacheManager;
            _serviceCacheManager.Changed += ServiceCacheManager_Removed;
            _serviceCacheManager.Removed += ServiceCacheManager_Removed;
            _serviceCacheManager.Created += ServiceCacheManager_Add;
        }


        private void ServiceCacheManager_Removed(object sender, ServiceCacheEventArgs e)
        {
            SaveConfiguration(e.Cache);
        }

        private void ServiceCacheManager_Add(object sender, ServiceCacheEventArgs e)
        {
            SaveConfiguration(e.Cache);
        }

        private void SaveConfiguration(ServiceCache cache)
        {
            if (queue.Count > 0) queue.Dequeue();
            var setting = _cachingProvider.CachingSettings.Where(p => p.Id == cache.CacheDescriptor.Prefix)
                .FirstOrDefault();
            if (setting != null)
            {
                setting.Properties.ForEach(p =>
                {
                    if (p.Maps != null)
                        p.Maps.ForEach(m =>
                        {
                            if (m.Name == cache.CacheDescriptor.Type)
                                m.Properties = cache.CacheEndpoint.Select(n =>
                                {
                                    var hashNode = n as ConsistentHashNode;
                                    if (!string.IsNullOrEmpty(hashNode.UserName) ||
                                        !string.IsNullOrEmpty(hashNode.Password))
                                    {
                                        return new Property
                                        {
                                            Value =
                                                $"{hashNode.UserName}:{hashNode.Password}@{hashNode.Host}:{hashNode.Port}::{hashNode.Db}"
                                        };
                                    }

                                    return new Property
                                    {
                                        Value = $"{hashNode.Host}:{hashNode.Port}::{hashNode.Db}"
                                    };
                                }).ToList();
                        });
                });
                queue.Enqueue(true);
            }
        }

        /// <summary>
        /// Processes this instance.
        /// </summary>
        public override Task Process()
        {
            if (queue.Count > 0 && queue.Dequeue())
            {
                //var jsonString = JsonConvert.SerializeObject(_cachingProvider);
                //await File.WriteAllTextAsync(AppConfig.Path, jsonString);
            }

            return Task.CompletedTask;
        }

        #region Field  

        private readonly ILogger<ConfigurationWatchProvider> _logger;
        private readonly IServiceCacheManager _serviceCacheManager;
        private readonly CachingProvider _cachingProvider;
        private readonly Queue<bool> queue = new Queue<bool>();

        #endregion
    }
}