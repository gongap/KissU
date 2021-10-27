﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Consul;
using KissU.Address;
using KissU.CPlatform.Routing;
using KissU.CPlatform.Routing.Implementation;
using KissU.CPlatform.Runtime.Client;
using KissU.Serialization;
using KissU.ServiceDiscovery.Consul.Configurations;
using KissU.ServiceDiscovery.Consul.Internal;
using KissU.ServiceDiscovery.Consul.Utilitys;
using KissU.ServiceDiscovery.Consul.WatcherProvider;
using KissU.ServiceDiscovery.Consul.WatcherProvider.Implementation;
using Microsoft.Extensions.Logging;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace KissU.ServiceDiscovery.Consul
{
    /// <summary>
    /// consul服务路由管理器
    /// </summary>
    public class ConsulServiceRouteManager : ServiceRouteManagerBase, IDisposable
    {
        private readonly ConfigInfo _configInfo;
        private readonly IConsulClientProvider _consulClientProvider;
        private readonly ILogger<ConsulServiceRouteManager> _logger;
        private readonly IClientWatchManager _manager;
        private readonly ISerializer<byte[]> _serializer;
        private readonly IServiceHeartbeatManager _serviceHeartbeatManager;
        private readonly IServiceRouteFactory _serviceRouteFactory;
        private readonly ISerializer<string> _stringSerializer;
        private ServiceRoute[] _routes;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsulServiceRouteManager" /> class.
        /// </summary>
        /// <param name="configInfo">The configuration information.</param>
        /// <param name="serializer">The serializer.</param>
        /// <param name="stringSerializer">The string serializer.</param>
        /// <param name="manager">The manager.</param>
        /// <param name="serviceRouteFactory">The service route factory.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="serviceHeartbeatManager">The service heartbeat manager.</param>
        /// <param name="consulClientProvider">The consul client provider.</param>
        public ConsulServiceRouteManager(ConfigInfo configInfo, ISerializer<byte[]> serializer,
            ISerializer<string> stringSerializer, IClientWatchManager manager, IServiceRouteFactory serviceRouteFactory,
            ILogger<ConsulServiceRouteManager> logger,
            IServiceHeartbeatManager serviceHeartbeatManager, IConsulClientProvider consulClientProvider) : base(
            stringSerializer)
        {
            _configInfo = configInfo;
            _serializer = serializer;
            _stringSerializer = stringSerializer;
            _serviceRouteFactory = serviceRouteFactory;
            _logger = logger;
            _consulClientProvider = consulClientProvider;
            _manager = manager;
            _serviceHeartbeatManager = serviceHeartbeatManager;
            EnterRoutes().Wait();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        /// 清空服务路由
        /// </summary>
        /// <returns>一个任务。</returns>
        public override async Task ClearAsync()
        {
            var clients = await _consulClientProvider.GetClients();
            foreach (var client in clients)
            {
                //根据前缀获取consul结果
                var queryResult = await client.KV.List(_configInfo.RoutePath);
                var response = queryResult.Response;
                if (response != null)
                {
                    //删除操作
                    foreach (var result in response)
                    {
                        await client.KV.DeleteCAS(result);
                    }
                }
            }
        }

        /// <summary>
        /// 获取所有可用的服务路由信息。
        /// </summary>
        /// <returns>服务路由集合。</returns>
        public override async Task<IEnumerable<ServiceRoute>> GetRoutesAsync()
        {
            await EnterRoutes();
            return _routes;
        }

        /// <summary>
        /// set routes as an asynchronous operation.
        /// </summary>
        /// <param name="routes">服务路由集合。</param>
        /// <returns>一个任务。</returns>
        public override async Task SetRoutesAsync(IEnumerable<ServiceRoute> routes)
        {
            var locks = await CreateLock();
            try
            {
                await _consulClientProvider.Check();
                var hostAddr = CPlatform.AppConfig.GetHostAddress();
                var serviceRoutes =
                    await GetRoutes(routes.Select(p => $"{_configInfo.RoutePath}{p.ServiceDescriptor.Id}"));
                foreach (var route in routes)
                {
                    var serviceRoute = serviceRoutes.Where(p => p.ServiceDescriptor.Id == route.ServiceDescriptor.Id)
                        .FirstOrDefault();

                    if (serviceRoute != null)
                    {
                        var addresses = serviceRoute.Address.Concat(
                            route.Address.Except(serviceRoute.Address)).ToList();

                        foreach (var address in route.Address)
                        {
                            addresses.Remove(addresses.Where(p => p.ToString() == address.ToString()).FirstOrDefault());
                            addresses.Add(address);
                        }

                        route.Address = addresses;
                    }
                }

                await RemoveExceptRoutesAsync(routes, hostAddr);
                await base.SetRoutesAsync(routes);
            }
            finally
            {
                locks.ForEach(p => p.Release());
            }
        }

        /// <summary>
        /// remve address as an asynchronous operation.
        /// </summary>
        /// <param name="Address">The address.</param>
        /// <returns>一个任务。</returns>
        public override async Task RemveAddressAsync(IEnumerable<AddressModel> Address)
        {
            var routes = await GetRoutesAsync();
            try
            {
                foreach (var route in routes)
                {
                    route.Address = route.Address.Except(Address);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            await base.SetRoutesAsync(routes);
        }

        /// <summary>
        /// set routes as an asynchronous operation.
        /// </summary>
        /// <param name="routes">The routes.</param>
        protected override async Task SetRoutesAsync(IEnumerable<ServiceRouteDescriptor> routes)
        {
            var clients = await _consulClientProvider.GetClients();
            foreach (var client in clients)
            {
                foreach (var serviceRoute in routes)
                {
                    var nodeData = _serializer.Serialize(serviceRoute);
                    var keyValuePair = new KVPair($"{_configInfo.RoutePath}{serviceRoute.ServiceDescriptor.Id}")
                        {Value = nodeData};
                    await client.KV.Put(keyValuePair);
                }
            }
        }

        #region 私有方法

        private async Task RemoveExceptRoutesAsync(IEnumerable<ServiceRoute> routes, AddressModel hostAddr)
        {
            routes = routes.ToArray();
            var clients = await _consulClientProvider.GetClients();
            foreach (var client in clients)
            {
                if (_routes != null)
                {
                    var oldRouteIds = _routes.Select(i => i.ServiceDescriptor.Id).ToArray();
                    var newRouteIds = routes.Select(i => i.ServiceDescriptor.Id).ToArray();
                    var deletedRouteIds = oldRouteIds.Except(newRouteIds).ToArray();
                    foreach (var deletedRouteId in deletedRouteIds)
                    {
                        var addresses = _routes.Where(p => p.ServiceDescriptor.Id == deletedRouteId)
                            .Select(p => p.Address).FirstOrDefault();
                        if (addresses.Contains(hostAddr))
                            await client.KV.Delete($"{_configInfo.RoutePath}{deletedRouteId}");
                    }
                }
            }
        }

        private async Task<List<IDistributedLock>> CreateLock()
        {
            var result = new List<IDistributedLock>();
            var clients = await _consulClientProvider.GetClients();
            foreach (var client in clients)
            {
                var key = $"lock_{_configInfo.RoutePath}";
                var writeResult = await client.KV.Get(key);
                if (writeResult.Response != null)
                {
                    var distributedLock = await client.AcquireLock(key);
                    result.Add(distributedLock);
                }
                else
                {
                    var distributedLock = await client.AcquireLock(new LockOptions($"lock_{_configInfo.RoutePath}")
                        {
                            SessionTTL = TimeSpan.FromSeconds(_configInfo.LockDelay),
                            LockTryOnce = true,
                            LockWaitTime = TimeSpan.FromSeconds(_configInfo.LockDelay)
                        },
                        _configInfo.LockDelay == 0
                            ? default
                            : new CancellationTokenSource(TimeSpan.FromSeconds(_configInfo.LockDelay)).Token);
                    result.Add(distributedLock);
                }
            }

            return result;
        }

        private async Task<ServiceRoute> GetRoute(byte[] data)
        {
            if (_logger.IsEnabled(LogLevel.Trace))
                _logger.LogTrace($"准备转换服务路由，配置内容：{Encoding.UTF8.GetString(data)}。");

            if (data == null)
                return null;

            var descriptor = _serializer.Deserialize<byte[], ServiceRouteDescriptor>(data);
            return (await _serviceRouteFactory.CreateServiceRoutesAsync(new[] {descriptor})).First();
        }

        private async Task<ServiceRoute[]> GetRouteDatas(string[] routes)
        {
            var serviceRoutes = new List<ServiceRoute>();
            foreach (var route in routes)
            {
                var serviceRoute = await GetRouteData(route);
                serviceRoutes.Add(serviceRoute);
            }

            return serviceRoutes.ToArray();
        }

        private async Task<ServiceRoute> GetRouteData(string data)
        {
            if (data == null)
                return null;

            var descriptor =
                _stringSerializer.Deserialize(data, typeof(ServiceRouteDescriptor)) as ServiceRouteDescriptor;
            return (await _serviceRouteFactory.CreateServiceRoutesAsync(new[] {descriptor})).First();
        }

        private async Task<ServiceRoute[]> GetRoutes(IEnumerable<string> childrens)
        {
            childrens = childrens.ToArray();
            var routes = new List<ServiceRoute>(childrens.Count());

            foreach (var children in childrens)
            {
                if (_logger.IsEnabled(LogLevel.Trace))
                    _logger.LogTrace($"准备从节点：{children}中获取路由信息。");

                var route = await GetRoute(children);
                if (route != null)
                    routes.Add(route);
            }

            return routes.ToArray();
        }

        private async Task<ServiceRoute> GetRoute(string path)
        {
            ServiceRoute result = null;
            var client = await GetConsulClient();
            var watcher = new NodeMonitorWatcher(GetConsulClient, _manager, path,
                async (oldData, newData) => await NodeChange(oldData, newData), tmpPath =>
                {
                    var index = tmpPath.LastIndexOf("/");
                    return _serviceHeartbeatManager.ExistsWhitelist(tmpPath.Substring(index + 1));
                });

            var queryResult = await client.KV.Keys(path);
            if (queryResult.Response != null)
            {
                var data = await client.GetDataAsync(path);
                if (data != null)
                {
                    watcher.SetCurrentData(data);
                    result = await GetRoute(data);
                }
            }

            return result;
        }

        private async ValueTask<ConsulClient> GetConsulClient()
        {
            var client = await _consulClientProvider.GetClient();
            return client;
        }

        private async Task EnterRoutes()
        {
            if (_routes != null && _routes.Length > 0)
                return;
            Action<string[]> action = null;
            var client = await GetConsulClient();
            //判断是否启用子监视器
            if (_configInfo.EnableChildrenMonitor)
            {
                //创建子监控类
                var watcher = new ChildrenMonitorWatcher(GetConsulClient, _manager, _configInfo.RoutePath,
                    async (oldChildrens, newChildrens) => await ChildrenChange(oldChildrens, newChildrens),
                    result => ConvertPaths(result).Result);
                //对委托绑定方法
                action = currentData => watcher.SetCurrentData(currentData);
            }

            if (client.KV.Keys(_configInfo.RoutePath).Result.Response?.Count() > 0)
            {
                var result = await client.GetChildrenAsync(_configInfo.RoutePath);
                var keys = await client.KV.Keys(_configInfo.RoutePath);
                var childrens = result;
                //传参数到方法中
                action?.Invoke(ConvertPaths(childrens).Result.Select(key => $"{_configInfo.RoutePath}{key}").ToArray());
                //重新赋值到routes中
                _routes = await GetRoutes(keys.Response);
            }
            else
            {
                _routes = new ServiceRoute[0];
            }
        }

        private static bool DataEquals(IReadOnlyList<byte> data1, IReadOnlyList<byte> data2)
        {
            if (data1.Count != data2.Count)
                return false;
            for (var i = 0; i < data1.Count; i++)
            {
                var b1 = data1[i];
                var b2 = data2[i];
                if (b1 != b2)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// 转化路径集合
        /// </summary>
        /// <param name="datas">信息数据集合</param>
        /// <returns>返回路径集合</returns>
        private async Task<string[]> ConvertPaths(string[] datas)
        {
            var paths = new List<string>();
            foreach (var data in datas)
            {
                var result = await GetRouteData(data);
                var serviceId = result?.ServiceDescriptor.Id;
                if (!string.IsNullOrEmpty(serviceId))
                    paths.Add(serviceId);
            }

            return paths.ToArray();
        }

        private async Task NodeChange(byte[] oldData, byte[] newData)
        {
            if (DataEquals(oldData, newData))
                return;

            var newRoute = await GetRoute(newData);
            //得到旧的路由。
            var oldRoute = _routes.FirstOrDefault(i => i.ServiceDescriptor.Id == newRoute.ServiceDescriptor.Id);

            lock (_routes)
            {
                //删除旧路由，并添加上新的路由。
                _routes =
                    _routes
                        .Where(i => i.ServiceDescriptor.Id != newRoute.ServiceDescriptor.Id)
                        .Concat(new[] {newRoute}).ToArray();
            }

            //触发路由变更事件。
            OnChanged(new ServiceRouteChangedEventArgs(newRoute, oldRoute));
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="oldChildrens">旧的节点信息</param>
        /// <param name="newChildrens">最新的节点信息</param>
        /// <returns></returns>
        private async Task ChildrenChange(string[] oldChildrens, string[] newChildrens)
        {
            //计算出已被删除的节点。
            var deletedChildrens = oldChildrens.Except(newChildrens).ToArray();
            //计算出新增的节点。
            var createdChildrens = newChildrens.Except(oldChildrens).ToArray();

            if (_logger.IsEnabled(LogLevel.Debug) && deletedChildrens?.Count() > 0)
                _logger.LogDebug($"需要被删除的路由节点：{string.Join(",", deletedChildrens)}");
            if (_logger.IsEnabled(LogLevel.Debug) && createdChildrens?.Count() > 0)
                _logger.LogDebug($"需要被添加的路由节点：{string.Join(",", createdChildrens)}");

            //获取新增的路由信息。
            var newRoutes = (await GetRoutes(createdChildrens)).ToArray();

            var routes = _routes.ToArray();
            lock (_routes)
            {
                #region 节点变更操作

                _routes = _routes
                    //删除无效的节点路由。
                    .Where(i => !deletedChildrens.Contains($"{_configInfo.RoutePath}{i.ServiceDescriptor.Id}"))
                    //连接上新的路由。
                    .Concat(newRoutes)
                    .ToArray();

                #endregion
            }

            //需要删除的路由集合。
            var deletedRoutes = routes
                .Where(i => deletedChildrens.Contains($"{_configInfo.RoutePath}{i.ServiceDescriptor.Id}")).ToArray();
            //触发删除事件。
            OnRemoved(deletedRoutes.Select(route => new ServiceRouteEventArgs(route)).ToArray());

            //触发路由被创建事件。
            OnCreated(newRoutes.Select(route => new ServiceRouteEventArgs(route)).ToArray());

            if (_logger.IsEnabled(LogLevel.Debug))
                _logger.LogDebug("服务路由数据更新成功。");
        }

        #endregion
    }
}