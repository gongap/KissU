using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using KissU.CPlatform.Routing.Template;
using KissU.CPlatform.Runtime.Server;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Dependency;
using Microsoft.Extensions.Logging;

namespace KissU.DotNetty.Tcp.Runtime.Implementation
{
    /// <summary>
    /// DefaultTcpServiceEntryProvider.
    /// Implements the <see cref="ITcpServiceEntryProvider" />
    /// </summary>
    /// <seealso cref="ITcpServiceEntryProvider" />
    public class DefaultTcpServiceEntryProvider : ITcpServiceEntryProvider
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultTcpServiceEntryProvider" /> class.
        /// </summary>
        /// <param name="serviceEntryProvider">The service entry provider.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="serviceProvider">The service provider.</param>
        public DefaultTcpServiceEntryProvider(IServiceEntryManager serviceEntryProvider,
            ILogger<DefaultTcpServiceEntryProvider> logger,
            CPlatformContainer serviceProvider)
        {
            _types = serviceEntryProvider.GetTypes();
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        #endregion Constructor

        #region Field

        private readonly IEnumerable<Type> _types;
        private readonly ILogger<DefaultTcpServiceEntryProvider> _logger;
        private readonly CPlatformContainer _serviceProvider;
        private TcpServiceEntry _tcpServiceEntry;

        #endregion Field

        #region Implementation of ITcpServiceEntryProvider

        /// <summary>
        /// 获取服务条目集合。
        /// </summary>
        /// <returns>服务条目集合。</returns>
        public TcpServiceEntry GetEntry()
        {
            var services = _types.ToArray();
            if (_tcpServiceEntry == null)
            {
                _tcpServiceEntry = new TcpServiceEntry();
                foreach (var service in services)
                {
                    var entry = CreateServiceEntry(service);
                    if (entry != null)
                    {
                        _tcpServiceEntry = entry;
                        break;
                    }
                }
            }

            if (_tcpServiceEntry.Type != null)
            {
                _logger.LogInformation($"发现了以下Tcp服务：{_tcpServiceEntry.Type.FullName}。");
            }

            return _tcpServiceEntry;
        }

        /// <summary>
        /// Creates the service entry.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <returns>TcpServiceEntry.</returns>
        public TcpServiceEntry CreateServiceEntry(Type service, string defaultRouteTemplate= "api/{Service}/{Async}")
        {
            TcpServiceEntry result = null;
            var routeTemplate = service.GetCustomAttribute<ServiceBundleAttribute>()?? new ServiceBundleAttribute(defaultRouteTemplate);
            var objInstance = _serviceProvider.GetInstances(service);
            var behavior = objInstance as TcpBehavior;
            var path = RoutePatternParser.Parse(routeTemplate.RouteTemplate, service.Name);
            if (path.Length > 0 && path[0] != '/')
                path = $"/{path}";
            if (behavior != null)
                result = new TcpServiceEntry
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
