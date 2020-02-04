using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using KissU.Core.CPlatform;
using KissU.Core.CPlatform.Routing.Template;
using KissU.Core.CPlatform.Runtime.Server;
using KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Microsoft.Extensions.Logging;

namespace KissU.Core.Protocol.Udp.Runtime.Implementation
{
    /// <summary>
    /// DefaultUdpServiceEntryProvider.
    /// Implements the <see cref="KissU.Core.Protocol.Udp.Runtime.IUdpServiceEntryProvider" />
    /// </summary>
    /// <seealso cref="KissU.Core.Protocol.Udp.Runtime.IUdpServiceEntryProvider" />
    public class DefaultUdpServiceEntryProvider : IUdpServiceEntryProvider
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultUdpServiceEntryProvider" /> class.
        /// </summary>
        /// <param name="serviceEntryProvider">The service entry provider.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="serviceProvider">The service provider.</param>
        public DefaultUdpServiceEntryProvider(IServiceEntryProvider serviceEntryProvider,
            ILogger<DefaultUdpServiceEntryProvider> logger,
            CPlatformContainer serviceProvider)
        {
            _types = serviceEntryProvider.GetTypes();
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        #endregion Constructor

        #region Field

        private readonly IEnumerable<Type> _types;
        private readonly ILogger<DefaultUdpServiceEntryProvider> _logger;
        private readonly CPlatformContainer _serviceProvider;
        private UdpServiceEntry _udpServiceEntry;

        #endregion Field

        #region Implementation of IUdpServiceEntryProvider

        /// <summary>
        /// 获取服务条目集合。
        /// </summary>
        /// <returns>服务条目集合。</returns>
        public UdpServiceEntry GetEntry()
        {
            var services = _types.ToArray();
            if (_udpServiceEntry == null)
            {
                _udpServiceEntry = new UdpServiceEntry();
                foreach (var service in services)
                {
                    var entry = CreateServiceEntry(service);
                    if (entry != null)
                    {
                        _udpServiceEntry = entry;
                        break;
                    }
                }

                if (_logger.IsEnabled(LogLevel.Debug))
                {
                    _logger.LogDebug($"发现了以下Udp服务：{_udpServiceEntry.Type.FullName}。");
                }
            }

            return _udpServiceEntry;
        }

        /// <summary>
        /// Creates the service entry.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <returns>UdpServiceEntry.</returns>
        public UdpServiceEntry CreateServiceEntry(Type service)
        {
            UdpServiceEntry result = null;
            var routeTemplate = service.GetCustomAttribute<ServiceBundleAttribute>();
            var objInstance = _serviceProvider.GetInstances(service);
            var behavior = objInstance as UdpBehavior;
            var path = RoutePatternParser.Parse(routeTemplate.RouteTemplate, service.Name);
            if (path.Length > 0 && path[0] != '/')
                path = $"/{path}";
            if (behavior != null)
                result = new UdpServiceEntry
                {
                    Behavior = behavior,
                    Type = behavior.GetType(),
                    Path = path
                };
            return result;
        }

        #endregion
    }
}