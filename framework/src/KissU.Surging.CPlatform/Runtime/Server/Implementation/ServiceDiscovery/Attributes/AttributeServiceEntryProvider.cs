using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using KissU.Core;
using Microsoft.Extensions.Logging;

namespace KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes
{
    /// <summary>
    /// Service标记类型的服务条目提供程序。
    /// </summary>
    public class AttributeServiceEntryProvider : IServiceEntryProvider
    {
        private readonly IClrServiceEntryFactory _clrServiceEntryFactory;
        private readonly ILogger<AttributeServiceEntryProvider> _logger;
        private readonly CPlatformContainer _serviceProvider;
        private readonly IEnumerable<Type> _types;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeServiceEntryProvider" /> class.
        /// </summary>
        /// <param name="types">The types.</param>
        /// <param name="clrServiceEntryFactory">The color service entry factory.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="serviceProvider">The service provider.</param>
        public AttributeServiceEntryProvider(IEnumerable<Type> types, IClrServiceEntryFactory clrServiceEntryFactory,
            ILogger<AttributeServiceEntryProvider> logger, CPlatformContainer serviceProvider)
        {
            _types = types;
            _clrServiceEntryFactory = clrServiceEntryFactory;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// 获取服务条目集合。
        /// </summary>
        /// <returns>服务条目集合。</returns>
        public IEnumerable<ServiceEntry> GetEntries()
        {
            var services = GetTypes();

            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation($"发现了以下服务：\n{string.Join(",\n", services.Select(i => i.ToString()))}。");
            }

            var entries = new List<ServiceEntry>();
            foreach (var service in services)
            {
                entries.AddRange(_clrServiceEntryFactory.CreateServiceEntry(service));
            }

            return entries;
        }

        /// <summary>
        /// 获取所有条目.
        /// </summary>
        /// <returns>IEnumerable&lt;ServiceEntry&gt;.</returns>
        public IEnumerable<ServiceEntry> GetALLEntries()
        {
            var services = _types.Where(i =>
            {
                var typeInfo = i.GetTypeInfo();
                return typeInfo.IsInterface && typeInfo.GetCustomAttribute<ServiceBundleAttribute>() != null;
            }).Distinct().ToArray();
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation($"发现了以下服务：\n{string.Join(",\n", services.Select(i => i.ToString()))}。");
            }

            var entries = new List<ServiceEntry>();
            foreach (var service in services)
            {
                entries.AddRange(_clrServiceEntryFactory.CreateServiceEntry(service));
            }

            return entries;
        }

        /// <summary>
        /// 获取类型.
        /// </summary>
        /// <returns>IEnumerable&lt;Type&gt;.</returns>
        public IEnumerable<Type> GetTypes()
        {
            var services = _types.Where(i =>
            {
                var typeInfo = i.GetTypeInfo();
                return typeInfo.IsInterface && typeInfo.GetCustomAttribute<ServiceBundleAttribute>() != null &&
                       _serviceProvider.Current.IsRegistered(i);
            }).Distinct().ToArray();
            return services;
        }
    }
}