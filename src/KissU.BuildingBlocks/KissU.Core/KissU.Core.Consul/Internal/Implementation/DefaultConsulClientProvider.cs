using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Consul;
using KissU.Core.Consul.Configurations;
using KissU.Core.Consul.Internal.Cluster.HealthChecks;
using KissU.Core.Consul.Internal.Cluster.Implementation.Selectors;
using KissU.Core.CPlatform;
using KissU.Core.CPlatform.Address;
using KissU.Core.CPlatform.Exceptions;
using KissU.Core.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors;
using Microsoft.Extensions.Logging;
using Level = Microsoft.Extensions.Logging.LogLevel;

namespace KissU.Core.Consul.Internal.Implementation
{
    /// <summary>
    /// DefaultConsulClientProvider.
    /// Implements the <see cref="KissU.Core.Consul.Internal.IConsulClientProvider" />
    /// </summary>
    /// <seealso cref="KissU.Core.Consul.Internal.IConsulClientProvider" />
    public class DefaultConsulClientProvider : IConsulClientProvider
    {
        private readonly ConcurrentDictionary<string, IAddressSelector> _addressSelectors = new
            ConcurrentDictionary<string, IAddressSelector>();

        private readonly IConsulAddressSelector _consulAddressSelector;

        private readonly ConcurrentDictionary<AddressModel, ConsulClient> _consulClients = new
            ConcurrentDictionary<AddressModel, ConsulClient>();

        private readonly IHealthCheckService _healthCheckService;
        private readonly ILogger<DefaultConsulClientProvider> _logger;
        private readonly ConfigInfo _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultConsulClientProvider" /> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="healthCheckService">The health check service.</param>
        /// <param name="consulAddressSelector">The consul address selector.</param>
        /// <param name="logger">The logger.</param>
        public DefaultConsulClientProvider(ConfigInfo config, IHealthCheckService healthCheckService,
            IConsulAddressSelector consulAddressSelector,
            ILogger<DefaultConsulClientProvider> logger)
        {
            _config = config;
            _healthCheckService = healthCheckService;
            _consulAddressSelector = consulAddressSelector;
            _logger = logger;
        }

        /// <summary>
        /// Gets the client.
        /// </summary>
        /// <returns>ValueTask&lt;ConsulClient&gt;.</returns>
        public async ValueTask<ConsulClient> GetClient()
        {
            ConsulClient result = null;
            var address = new List<AddressModel>();
            foreach (var addressModel in _config.Addresses)
            {
                _healthCheckService.Monitor(addressModel);
                var task = _healthCheckService.IsHealth(addressModel);
                if (!(task.IsCompletedSuccessfully ? task.Result : await task))
                {
                    continue;
                }

                address.Add(addressModel);
            }

            if (address.Count == 0)
            {
                if (_logger.IsEnabled(Level.Warning))
                    _logger.LogWarning("找不到可用的注册中心地址。");
                return null;
            }

            var vt = _consulAddressSelector.SelectAsync(new AddressSelectContext
            {
                Descriptor = new ServiceDescriptor {Id = nameof(DefaultConsulClientProvider)},
                Address = address
            });
            var addr = vt.IsCompletedSuccessfully ? vt.Result : await vt;
            if (addr != null)
            {
                var ipAddress = addr as IpAddressModel;
                result = _consulClients.GetOrAdd(ipAddress, new ConsulClient(
                    config => { config.Address = new Uri($"http://{ipAddress.Ip}:{ipAddress.Port}"); }, null, h =>
                    {
                        h.UseProxy = false;
                        h.Proxy = null;
                    }));
            }

            return result;
        }

        /// <summary>
        /// Gets the clients.
        /// </summary>
        /// <returns>ValueTask&lt;IEnumerable&lt;ConsulClient&gt;&gt;.</returns>
        public async ValueTask<IEnumerable<ConsulClient>> GetClients()
        {
            var result = new List<ConsulClient>();
            foreach (var address in _config.Addresses)
            {
                var ipAddress = address as IpAddressModel;
                if (await _healthCheckService.IsHealth(address))
                {
                    result.Add(_consulClients.GetOrAdd(ipAddress, new ConsulClient(
                        config => { config.Address = new Uri($"http://{ipAddress.Ip}:{ipAddress.Port}"); }, null, h =>
                        {
                            h.UseProxy = false;
                            h.Proxy = null;
                        })));
                }
            }

            return result;
        }

        /// <summary>
        /// Checks this instance.
        /// </summary>
        /// <returns>ValueTask.</returns>
        /// <exception cref="RegisterConnectionException"></exception>
        public async ValueTask Check()
        {
            foreach (var address in _config.Addresses)
            {
                if (!await _healthCheckService.IsHealth(address))
                {
                    throw new RegisterConnectionException(string.Format("注册中心{0}连接异常，请联系管理员", address));
                }
            }
        }
    }
}