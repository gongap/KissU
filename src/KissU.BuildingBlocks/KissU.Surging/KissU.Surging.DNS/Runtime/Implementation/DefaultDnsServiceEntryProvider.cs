using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using KissU.Surging.CPlatform;
using KissU.Surging.CPlatform.Routing.Template;
using KissU.Surging.CPlatform.Runtime.Server;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Microsoft.Extensions.Logging;

namespace KissU.Surging.DNS.Runtime.Implementation
{
    /// <summary>
    /// DefaultDnsServiceEntryProvider.
    /// Implements the <see cref="KissU.Surging.DNS.Runtime.IDnsServiceEntryProvider" />
    /// </summary>
    /// <seealso cref="KissU.Surging.DNS.Runtime.IDnsServiceEntryProvider" />
    public class DefaultDnsServiceEntryProvider : IDnsServiceEntryProvider
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultDnsServiceEntryProvider" /> class.
        /// </summary>
        /// <param name="serviceEntryProvider">The service entry provider.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="serviceProvider">The service provider.</param>
        public DefaultDnsServiceEntryProvider(IServiceEntryProvider serviceEntryProvider,
            ILogger<DefaultDnsServiceEntryProvider> logger,
            CPlatformContainer serviceProvider)
        {
            _types = serviceEntryProvider.GetTypes();
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        #endregion Constructor

        #region Implementation of IServiceEntryProvider

        /// <summary>
        /// 获取服务条目集合。
        /// </summary>
        /// <returns>服务条目集合。</returns>
        public DnsServiceEntry GetEntry()
        {
            var services = _types.ToArray();
            if (_dnsServiceEntry == null)
            {
                _dnsServiceEntry = new DnsServiceEntry();
                foreach (var service in services)
                {
                    var entry = CreateServiceEntry(service);
                    if (entry != null)
                    {
                        _dnsServiceEntry = entry;
                        break;
                    }
                }

                if (_logger.IsEnabled(LogLevel.Debug))
                {
                    _logger.LogDebug($"发现了以下dns服务：{_dnsServiceEntry.Type.FullName}。");
                }
            }

            return _dnsServiceEntry;
        }

        #endregion

        /// <summary>
        /// Creates the service entry.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <returns>DnsServiceEntry.</returns>
        public DnsServiceEntry CreateServiceEntry(Type service)
        {
            DnsServiceEntry result = null;
            var routeTemplate = service.GetCustomAttribute<ServiceBundleAttribute>();
            var objInstance = _serviceProvider.GetInstances(service);
            var behavior = objInstance as DnsBehavior;
            var path = RoutePatternParser.Parse(routeTemplate.RouteTemplate, service.Name);
            if (path.Length > 0 && path[0] != '/')
                path = $"/{path}";
            if (behavior != null)
                result = new DnsServiceEntry
                {
                    Behavior = behavior,
                    Type = behavior.GetType(),
                    Path = path
                };
            return result;
        }

        #region Field

        private readonly IEnumerable<Type> _types;
        private readonly ILogger<DefaultDnsServiceEntryProvider> _logger;
        private readonly CPlatformContainer _serviceProvider;
        private DnsServiceEntry _dnsServiceEntry;

        #endregion Field
    }
}