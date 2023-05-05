using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using KissU.CPlatform.Routing.Template;
using KissU.CPlatform.Runtime.Server;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Dependency;
using KissU.DotNetty.WebSocket.Attributes;
using Microsoft.Extensions.Logging;

namespace KissU.DotNetty.WebSocket.Runtime.Implementation
{
    /// <summary>
    /// DefaultWSServiceEntryProvider.
    /// Implements the <see cref="IWSServiceEntryProvider" />
    /// </summary>
    /// <seealso cref="IWSServiceEntryProvider" />
    public class DefaultWSServiceEntryProvider : IWSServiceEntryProvider
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultWSServiceEntryProvider" /> class.
        /// </summary>
        /// <param name="serviceEntryProvider">The service entry provider.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="serviceProvider">The service provider.</param>
        public DefaultWSServiceEntryProvider(IServiceEntryManager serviceEntryProvider,
            ILogger<DefaultWSServiceEntryProvider> logger,
            CPlatformContainer serviceProvider)
        {
            _types = serviceEntryProvider.GetTypes();
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        #endregion Constructor

        #region Field

        private readonly IEnumerable<Type> _types;
        private readonly ILogger<DefaultWSServiceEntryProvider> _logger;
        private readonly CPlatformContainer _serviceProvider;
        private List<WSServiceEntry> _wSServiceEntries;

        #endregion Field

        #region Implementation of IUdpServiceEntryProvider

        /// <summary>
        /// 获取服务条目集合。
        /// </summary>
        /// <returns>服务条目集合。</returns>
        public IEnumerable<WSServiceEntry> GetEntries()
        {
            var services = _types.ToArray();
            if (_wSServiceEntries == null)
            {
                _wSServiceEntries = new List<WSServiceEntry>();
                foreach (var service in services)
                {
                    var entry = CreateServiceEntry(service);
                    if (entry != null)
                    {
                        _wSServiceEntries.Add(entry);
                    }
                }

                if (_wSServiceEntries.Any())
                {
                    _logger.LogInformation($"发现了{_wSServiceEntries.Count()}个WS服务：");
                    foreach (var service in _wSServiceEntries)
                    {
                        _logger.LogInformation(service.Type.FullName);
                    }
                }
            }

            return _wSServiceEntries;
        }

        /// <summary>
        /// Creates the service entry.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <returns>WSServiceEntry.</returns>
        public WSServiceEntry CreateServiceEntry(Type service, string defaultRouteTemplate= "api/{Service}/{Async}")
        {
            WSServiceEntry result = null;
            var routeTemplate = service.GetCustomAttribute<ServiceBundleAttribute>() ?? new ServiceBundleAttribute(defaultRouteTemplate);
            var behaviorContract = service.GetCustomAttribute<BehaviorContractAttribute>();
            var objInstance = _serviceProvider.GetInstances(service);
            var behavior = objInstance as WSBehavior;
            var path = RoutePatternParser.Parse(routeTemplate.RouteTemplate, service.Name);
            if (path.Length > 0 && path[0] != '/')
                path = $"/{path}";
            if (behavior != null)
            {
                behavior.Protocol = behaviorContract?.Protocol;
                result = new WSServiceEntry
                {
                    Behavior = behavior,
                    Type = behavior.GetType(),
                    Path = path
                };
            }

            return result;
        }

        #endregion
    }
}