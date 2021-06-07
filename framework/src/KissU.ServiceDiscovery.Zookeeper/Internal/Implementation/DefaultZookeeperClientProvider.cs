using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KissU.Address;
using KissU.CPlatform;
using KissU.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors;
using KissU.Exceptions;
using KissU.ServiceDiscovery.Zookeeper.Configurations;
using KissU.ServiceDiscovery.Zookeeper.Internal.Cluster.HealthChecks;
using KissU.ServiceDiscovery.Zookeeper.Internal.Cluster.Implementation.Selectors;
using KissU.ServiceDiscovery.Zookeeper.WatcherProvider;
using Microsoft.Extensions.Logging;
using org.apache.zookeeper;
using Level = Microsoft.Extensions.Logging.LogLevel;

namespace KissU.ServiceDiscovery.Zookeeper.Internal.Implementation
{
    /// <summary>
    /// DefaultZookeeperClientProvider.
    /// Implements the <see cref="IZookeeperClientProvider" />
    /// </summary>
    /// <seealso cref="IZookeeperClientProvider" />
    public class DefaultZookeeperClientProvider : IZookeeperClientProvider
    {
        private readonly ConcurrentDictionary<string, IAddressSelector> _addressSelectors = new
            ConcurrentDictionary<string, IAddressSelector>();

        private readonly IHealthCheckService _healthCheckService;
        private readonly ILogger<DefaultZookeeperClientProvider> _logger;
        private readonly IZookeeperAddressSelector _zookeeperAddressSelector;

        private readonly ConcurrentDictionary<AddressModel, ValueTuple<ManualResetEvent, ZooKeeper>> _zookeeperClients =
            new
                ConcurrentDictionary<AddressModel, ValueTuple<ManualResetEvent, ZooKeeper>>();

        private readonly ConfigInfo _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultZookeeperClientProvider" /> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="healthCheckService">The health check service.</param>
        /// <param name="zookeeperAddressSelector">The zookeeper address selector.</param>
        /// <param name="logger">The logger.</param>
        public DefaultZookeeperClientProvider(ConfigInfo config, IHealthCheckService healthCheckService,
            IZookeeperAddressSelector zookeeperAddressSelector,
            ILogger<DefaultZookeeperClientProvider> logger)
        {
            _config = config;
            _healthCheckService = healthCheckService;
            _zookeeperAddressSelector = zookeeperAddressSelector;
            _logger = logger;
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

        /// <summary>
        /// Gets the zoo keeper.
        /// </summary>
        /// <returns>ValueTask&lt;System.ValueTuple&lt;ManualResetEvent, ZooKeeper&gt;&gt;.</returns>
        public async ValueTask<(ManualResetEvent, ZooKeeper)> GetZooKeeper()
        {
            var result = new ValueTuple<ManualResetEvent, ZooKeeper>();
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
                return default;
            }

            var vt = _zookeeperAddressSelector.SelectAsync(new AddressSelectContext
            {
                Descriptor = new ServiceDescriptor {Id = nameof(DefaultZookeeperClientProvider)},
                Address = address
            });
            var addr = vt.IsCompletedSuccessfully ? vt.Result : await vt;
            if (addr != null)
            {
                var ipAddress = addr as IpAddressModel;
                result = CreateZooKeeper(ipAddress);
            }

            return result;
        }

        /// <summary>
        /// Gets the zoo keepers.
        /// </summary>
        /// <returns>ValueTask&lt;IEnumerable&lt;System.ValueTuple&lt;ManualResetEvent, ZooKeeper&gt;&gt;&gt;.</returns>
        public async ValueTask<IEnumerable<(ManualResetEvent, ZooKeeper)>> GetZooKeepers()
        {
            var result = new List<(ManualResetEvent, ZooKeeper)>();
            foreach (var address in _config.Addresses)
            {
                var ipAddress = address as IpAddressModel;
                if (await _healthCheckService.IsHealth(address))
                {
                    result.Add(CreateZooKeeper(ipAddress));
                }
            }

            return result;
        }

        /// <summary>
        /// Creates the zoo keeper.
        /// </summary>
        /// <param name="ipAddress">The ip address.</param>
        /// <returns>System.ValueTuple&lt;ManualResetEvent, ZooKeeper&gt;.</returns>
        protected (ManualResetEvent, ZooKeeper) CreateZooKeeper(IpAddressModel ipAddress)
        {
            if (!_zookeeperClients.TryGetValue(ipAddress, out var result))
            {
                var connectionWait = new ManualResetEvent(false);
                result = new ValueTuple<ManualResetEvent, ZooKeeper>(connectionWait, new ZooKeeper(
                    $"{ipAddress.Ip}:{ipAddress.Port}", (int) _config.SessionTimeout.TotalMilliseconds
                    , new ReconnectionWatcher(
                        () => { connectionWait.Set(); },
                        () => { connectionWait.Close(); },
                        async () =>
                        {
                            connectionWait.Reset();
                            if (_zookeeperClients.TryRemove(ipAddress, out var value))
                            {
                                await value.Item2.closeAsync();
                                value.Item1.Close();
                            }

                            CreateZooKeeper(ipAddress);
                        })));
                _zookeeperClients.AddOrUpdate(ipAddress, result, (k, v) => result);
            }

            return result;
        }
    }
}