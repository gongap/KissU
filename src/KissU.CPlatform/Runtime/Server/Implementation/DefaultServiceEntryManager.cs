using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace KissU.CPlatform.Runtime.Server.Implementation
{
    /// <summary>
    /// 默认的服务条目管理者。
    /// </summary>
    public class DefaultServiceEntryManager : IServiceEntryManager
    {
        private readonly IEnumerable<IServiceEntryProvider> _providers;
        private readonly ILogger<DefaultServiceEntryManager> _logger;
        private IEnumerable<ServiceEntry> _allEntries;
        private IEnumerable<ServiceEntry> _serviceEntries;
        private IEnumerable<Type> _types;
        private IEnumerable<Type> _allTypes;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultServiceEntryManager" /> class.
        /// </summary>
        /// <param name="providers">The providers.</param>
        public DefaultServiceEntryManager(IEnumerable<IServiceEntryProvider> providers, ILogger<DefaultServiceEntryManager> logger)
        {
            _providers = providers;
            _logger = logger;
            UpdateEntries(providers);
        }

        /// <summary>
        /// 更新条目.
        /// </summary>
        /// <param name="providers">The providers.</param>
        /// <exception cref="InvalidOperationException">本地包含多个Id为：{entry.Descriptor.Id} 的服务条目。</exception>
        public void UpdateEntries(IEnumerable<IServiceEntryProvider> providers)
        {
            var serviceEntries = new List<ServiceEntry>();
            var allEntries = new List<ServiceEntry>();
            foreach (var provider in providers)
            {
                allEntries.AddRange(provider.GetAllEntries());

                var entries = provider.GetEntries().ToArray();
                foreach (var entry in entries)
                {
                    if (serviceEntries.Any(i => i.Descriptor.Id == entry.Descriptor.Id))
                    {
                        throw new InvalidOperationException($"本地包含多个Id为：{entry.Descriptor.Id} 的服务条目。");
                    }
                }

                serviceEntries.AddRange(entries);
            }

            _serviceEntries = serviceEntries;
            _allEntries = allEntries;
        }

        /// <summary>
        /// 获取服务条目集合。
        /// </summary>
        /// <returns>服务条目集合。</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IEnumerable<ServiceEntry> GetEntries()
        {
            GetTypes();
            return _serviceEntries;
        }

        /// <summary>
        /// 获取所有条目.
        /// </summary>
        /// <returns>IEnumerable&lt;ServiceEntry&gt;.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IEnumerable<ServiceEntry> GetAllEntries()
        {
            GetAllTypes();
            return _allEntries;
        }

        /// <summary>
        /// 获取所有条目.
        /// </summary>
        /// <returns>IEnumerable&lt;ServiceEntry&gt;.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IEnumerable<Type> GetTypes()
        {
            if (_types == null)
            {
                var types = new List<Type>();
                foreach (var provider in _providers)
                {
                    types.AddRange(provider.GetTypes());
                }

                _types = types;
            
                _logger.LogInformation($"发现了{_types.Count()}个本地服务：");
                foreach (var type in _types)
                {
                    _logger.LogInformation(type.ToString());
                }
            }

            return _types;
        }

        /// <summary>
        /// 获取所有条目.
        /// </summary>
        /// <returns>IEnumerable&lt;ServiceEntry&gt;.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IEnumerable<Type> GetAllTypes()
        {
            if (_allTypes == null)
            {
                var allTypes = new List<Type>();
                foreach (var provider in _providers)
                {
                    allTypes.AddRange(provider.GetAllTypes());
                }

                _allTypes = allTypes;
            
                _logger.LogInformation($"发现了{_allTypes.Count()}个服务：");
                foreach (var type in _allTypes)
                {
                    _logger.LogInformation(type.ToString());
                }
            }

            return _allTypes;
        }
    }
}