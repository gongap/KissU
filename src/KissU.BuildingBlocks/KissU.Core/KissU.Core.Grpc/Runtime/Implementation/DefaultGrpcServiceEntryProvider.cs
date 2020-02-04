using System;
using System.Collections.Generic;
using System.Linq;
using KissU.Core.CPlatform;
using KissU.Core.CPlatform.Ioc;
using KissU.Core.CPlatform.Runtime.Server;
using Microsoft.Extensions.Logging;

namespace KissU.Core.Grpc.Runtime.Implementation
{
    /// <summary>
    /// DefaultGrpcServiceEntryProvider.
    /// Implements the <see cref="KissU.Core.Grpc.Runtime.IGrpcServiceEntryProvider" />
    /// </summary>
    /// <seealso cref="KissU.Core.Grpc.Runtime.IGrpcServiceEntryProvider" />
    public class DefaultGrpcServiceEntryProvider: IGrpcServiceEntryProvider
    { 
        #region Field

        private readonly IEnumerable<Type> _types;
        private readonly ILogger<DefaultGrpcServiceEntryProvider> _logger;
        private readonly CPlatformContainer _serviceProvider;
        private List<GrpcServiceEntry> _grpcServiceEntries;

        #endregion Field

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultGrpcServiceEntryProvider" /> class.
        /// </summary>
        /// <param name="serviceEntryProvider">The service entry provider.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="serviceProvider">The service provider.</param>
        public DefaultGrpcServiceEntryProvider(IServiceEntryProvider serviceEntryProvider,
            ILogger<DefaultGrpcServiceEntryProvider> logger,
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
        public List<GrpcServiceEntry> GetEntries()
        {
            var services = _types.ToArray();
            if (_grpcServiceEntries == null)
            {
                _grpcServiceEntries = new List<GrpcServiceEntry>(); 
                foreach (var service in services)
                {
                    var entry = CreateServiceEntry(service);
                    if (entry != null)
                    {
                        _grpcServiceEntries.Add(entry); 
                    }
                }
                if (_logger.IsEnabled(LogLevel.Debug))
                {
                    _logger.LogDebug($"发现了以下grpc服务：{string.Join(",", _grpcServiceEntries.Select(i => i.Type.FullName))}。"); ;
                }
            }
            return _grpcServiceEntries;
        }

        /// <summary>
        /// Creates the service entry.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <returns>GrpcServiceEntry.</returns>
        public GrpcServiceEntry CreateServiceEntry(Type service)
        {
            GrpcServiceEntry result = null; 
            var objInstance = _serviceProvider.GetInstances(service);
            var behavior = objInstance as IServiceBehavior;  
            if (behavior != null)
                result = new GrpcServiceEntry
                {
                    Behavior = behavior,
                    Type = behavior.GetType()
                };
            return result;
        }
        #endregion
    }
}
