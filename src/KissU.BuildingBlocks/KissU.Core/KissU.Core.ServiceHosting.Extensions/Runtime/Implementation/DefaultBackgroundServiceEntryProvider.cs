using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using KissU.Core.CPlatform;
using KissU.Core.CPlatform.Routing.Template;
using KissU.Core.CPlatform.Runtime.Server;
using KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Microsoft.Extensions.Logging;

namespace KissU.Core.ServiceHosting.Extensions.Runtime.Implementation
{
    /// <summary>
    /// DefaultBackgroundServiceEntryProvider.
    /// Implements the <see cref="KissU.Core.ServiceHosting.Extensions.Runtime.IBackgroundServiceEntryProvider" />
    /// </summary>
    /// <seealso cref="KissU.Core.ServiceHosting.Extensions.Runtime.IBackgroundServiceEntryProvider" />
    public class DefaultBackgroundServiceEntryProvider: IBackgroundServiceEntryProvider
    {
        #region Field
        private readonly IEnumerable<Type> _types;
        private readonly ILogger<DefaultBackgroundServiceEntryProvider> _logger;
        private readonly CPlatformContainer _serviceProvider;
        private List<BackgroundServiceEntry> _backgroundServiceEntries;

        #endregion Field

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultBackgroundServiceEntryProvider"/> class.
        /// </summary>
        /// <param name="serviceEntryProvider">The service entry provider.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="serviceProvider">The service provider.</param>
        public DefaultBackgroundServiceEntryProvider(IServiceEntryProvider serviceEntryProvider,
            ILogger<DefaultBackgroundServiceEntryProvider> logger,
            CPlatformContainer serviceProvider)
        {
            _types = serviceEntryProvider.GetTypes();
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        #endregion Constructor

        #region Implementation of IUdpServiceEntryProvider


        /// <summary>
        /// Gets the entries.
        /// </summary>
        /// <returns>IEnumerable&lt;BackgroundServiceEntry&gt;.</returns>
        public IEnumerable<BackgroundServiceEntry> GetEntries()
        {
            var services = _types.ToArray();
            if (_backgroundServiceEntries == null)
            {
                _backgroundServiceEntries = new List<BackgroundServiceEntry>();
                foreach (var service in services)
                {
                    var entry = CreateServiceEntry(service);
                    if (entry != null)
                    {
                        _backgroundServiceEntries.Add(entry);
                    }
                }
                if (_logger.IsEnabled(LogLevel.Debug))
                {
                    _logger.LogDebug($"发现了以下后台托管服务：{string.Join(",", _backgroundServiceEntries.Select(i => i.Type.FullName))}。");
                }
            }
            return _backgroundServiceEntries;
        }


        /// <summary>
        /// Creates the service entry.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <returns>BackgroundServiceEntry.</returns>
        public BackgroundServiceEntry CreateServiceEntry(Type service)
        {
            BackgroundServiceEntry result = null;
            var routeTemplate = service.GetCustomAttribute<ServiceBundleAttribute>();
            var objInstance = _serviceProvider.GetInstances(service);
            var behavior = objInstance as BackgroundServiceBehavior;
            var path = RoutePatternParser.Parse(routeTemplate.RouteTemplate, service.Name);
            if (path.Length > 0 && path[0] != '/')
                path = $"/{path}";
            if (behavior != null)
                result = new BackgroundServiceEntry
                {
                    Behavior = behavior,
                    Type = behavior.GetType(),
                    Path = path,
                };
            return result;
        }
        #endregion
    }
}
