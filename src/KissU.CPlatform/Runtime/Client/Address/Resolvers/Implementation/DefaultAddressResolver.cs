﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Address;
using KissU.Dependency;
using KissU.CPlatform.Routing;
using KissU.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors;
using KissU.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;
using KissU.CPlatform.Runtime.Client.HealthChecks;
using KissU.CPlatform.Support;
using Microsoft.Extensions.Logging;

namespace KissU.CPlatform.Runtime.Client.Address.Resolvers.Implementation
{
    /// <summary>
    /// 默认的服务地址解析器。
    /// </summary>
    public class DefaultAddressResolver : IAddressResolver
    {
        private readonly ConcurrentDictionary<string, IAddressSelector> _addressSelectors =
            new ConcurrentDictionary<string, IAddressSelector>();

        private readonly IServiceCommandProvider _commandProvider;

        private readonly ConcurrentDictionary<string, ServiceRoute> _concurrent =
            new ConcurrentDictionary<string, ServiceRoute>();

        private readonly CPlatformContainer _container;
        private readonly IHealthCheckService _healthCheckService;
        private readonly ILogger<DefaultAddressResolver> _logger;
        private readonly IServiceHeartbeatManager _serviceHeartbeatManager;
        private readonly IServiceRouteProvider _serviceRouteProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultAddressResolver" /> class.
        /// </summary>
        /// <param name="commandProvider">The command provider.</param>
        /// <param name="serviceRouteProvider">The service route manager.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="container">The container.</param>
        /// <param name="healthCheckService">The health check service.</param>
        /// <param name="serviceHeartbeatManager">The service heartbeat manager.</param>
        public DefaultAddressResolver(IServiceCommandProvider commandProvider, IServiceRouteProvider serviceRouteProvider,
            ILogger<DefaultAddressResolver> logger, CPlatformContainer container,
            IHealthCheckService healthCheckService, IServiceHeartbeatManager serviceHeartbeatManager)
        {
            _container = container;
            _serviceRouteProvider = serviceRouteProvider;
            _logger = logger;
            LoadAddressSelectors();
            _commandProvider = commandProvider;
            _healthCheckService = healthCheckService;
            _serviceHeartbeatManager = serviceHeartbeatManager;
        }

        /// <summary>
        /// 解析服务地址。
        /// </summary>
        /// <param name="serviceId">服务Id。</param>
        /// <param name="item">The item.</param>
        /// <returns>服务地址模型。</returns>
        /// 1.从字典中拿到serviceroute对象
        /// 2.从字典中拿到服务描述符集合
        /// 3.获取或添加serviceroute
        /// 4.添加服务id到白名单
        /// 5.根据服务描述符得到地址并判断地址是否是可用的（地址应该是多个）
        /// 6.添加到集合中
        /// 7.拿到服务命今
        /// 8.根据负载分流策略拿到一个选择器
        /// 9.返回addressmodel
        public async ValueTask<AddressModel> Resolver(string serviceId, string item)
        {
            if (_logger.IsEnabled(LogLevel.Trace))
            {
                _logger.LogTrace($"Prepare for service ID：{serviceId}，resolving available addresses");
            }

            var serviceRouteTask = _serviceRouteProvider.Locate(serviceId);
            var serviceRoute = serviceRouteTask.IsCompletedSuccessfully ? serviceRouteTask.Result : await serviceRouteTask;
            if (serviceRoute == null)
            {
                if (_logger.IsEnabled(LogLevel.Warning))
                    _logger.LogWarning($"Service ID：{serviceId}，no related service information was found.");
                return null;
            }

            _serviceHeartbeatManager.AddWhitelist(serviceId);
                var address = new List<AddressModel>();
            foreach (var addressModel in serviceRoute.Address)
            {
                _healthCheckService.Monitor(addressModel);
                var task = _healthCheckService.IsHealth(addressModel);
                if (!(task.IsCompletedSuccessfully ? task.Result : await task))
                {
                    await _healthCheckService.MarkFailure(addressModel);
                    continue;
                }

                address.Add(addressModel);
            }

            if (address.Count == 0)
            {
                if (_logger.IsEnabled(LogLevel.Warning))
                {
                    _logger.LogWarning($"Service ID：{serviceId}，no available addresses were found.");
                }

                return null;
            }

            if (_logger.IsEnabled(LogLevel.Trace))
            {
                _logger.LogTrace(
                    $"Service ID：{serviceId}，the following available addresses were found：{string.Join(",", address.Select(i => i.ToString()))}。");
            }

            var vtCommand = _commandProvider.GetCommand(serviceId);
            var command = vtCommand.IsCompletedSuccessfully ? vtCommand.Result : await vtCommand;
            var addressSelector = _addressSelectors[command.ShuntStrategy.ToString()];

            var vt = addressSelector.SelectAsync(new AddressSelectContext
            {
                Descriptor = serviceRoute.ServiceDescriptor,
                Address = address,
                Item = item
            });
            return vt.IsCompletedSuccessfully ? vt.Result : await vt;
        }

        private void LoadAddressSelectors()
        {
            foreach (AddressSelectorMode item in Enum.GetValues(typeof(AddressSelectorMode)))
            {
                _addressSelectors.TryAdd(item.ToString(), _container.GetInstances<IAddressSelector>(item.ToString()));
            }
        }
    }
}