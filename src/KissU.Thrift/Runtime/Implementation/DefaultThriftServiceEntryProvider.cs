using System;
using System.Collections.Generic;
using System.Linq;
using KissU.Dependency;
using KissU.CPlatform.Runtime.Server;
using Microsoft.Extensions.Logging;

namespace KissU.Thrift.Runtime.Implementation
{
   public  class DefaultThriftServiceEntryProvider : IThriftServiceEntryProvider
    {
        #region Field

        private readonly IEnumerable<Type> _types;
        private readonly ILogger<DefaultThriftServiceEntryProvider> _logger;
        private readonly CPlatformContainer _serviceProvider;
        private List<ThriftServiceEntry> _thriftServiceEntries;

        #endregion Field

        #region Constructor

        public DefaultThriftServiceEntryProvider(IServiceEntryManager serviceEntryProvider,
            ILogger<DefaultThriftServiceEntryProvider> logger,
            CPlatformContainer serviceProvider)
        {
            _types = serviceEntryProvider.GetTypes();
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        #endregion Constructor

        #region Implementation of IUdpServiceEntryProvider

        /// <summary>
        /// 获取服务条目集合。
        /// </summary>
        /// <returns>服务条目集合。</returns>
        public List<ThriftServiceEntry> GetEntries()
        {
            var services = _types.ToArray();
            if (_thriftServiceEntries == null)
            {
                _thriftServiceEntries = new List<ThriftServiceEntry>();
                foreach (var service in services)
                {
                    var entry = CreateServiceEntry(service);
                    if (entry != null)
                    {
                        _thriftServiceEntries.Add(entry);
                    }
                }
                if (_thriftServiceEntries.Any())
                {
                    _logger.LogInformation($"发现了{_thriftServiceEntries.Count()}个thrift服务：");
                    foreach (var service in _thriftServiceEntries)
                    {
                        _logger.LogInformation(service.Type.FullName);
                    }
                }
            }
            return _thriftServiceEntries;
        }

        public ThriftServiceEntry CreateServiceEntry(Type service)
        {
            ThriftServiceEntry result = null;
            var objInstance = _serviceProvider.GetInstances(service);
            var behavior = objInstance as IThriftBehavior;
            if (behavior != null)
                result = new ThriftServiceEntry
                {
                    Behavior = behavior,
                    Type = behavior.GetType()
                };
            return result;
        }
        #endregion
    }
}
