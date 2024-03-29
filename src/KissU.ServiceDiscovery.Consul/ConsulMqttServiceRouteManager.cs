﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consul;
using KissU.Address;
using KissU.CPlatform.Mqtt;
using KissU.CPlatform.Mqtt.Implementation;
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
    /// ConsulMqttServiceRouteManager.
    /// Implements the <see cref="KissU.CPlatform.Mqtt.Implementation.MqttServiceRouteManagerBase" />
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="KissU.CPlatform.Mqtt.Implementation.MqttServiceRouteManagerBase" />
    /// <seealso cref="System.IDisposable" />
    public class ConsulMqttServiceRouteManager : MqttServiceRouteManagerBase, IDisposable
    {
        private readonly ConfigInfo _configInfo;
        private readonly IConsulClientProvider _consulClientFactory;
        private readonly ILogger<ConsulMqttServiceRouteManager> _logger;
        private readonly IClientWatchManager _manager;
        private readonly IMqttServiceFactory _mqttServiceFactory;
        private readonly ISerializer<byte[]> _serializer;
        private readonly IServiceHeartbeatManager _serviceHeartbeatManager;
        private readonly ISerializer<string> _stringSerializer;
        private MqttServiceRoute[] _routes;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsulMqttServiceRouteManager" /> class.
        /// </summary>
        /// <param name="configInfo">The configuration information.</param>
        /// <param name="serializer">The serializer.</param>
        /// <param name="stringSerializer">The string serializer.</param>
        /// <param name="manager">The manager.</param>
        /// <param name="mqttServiceFactory">The MQTT service factory.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="serviceHeartbeatManager">The service heartbeat manager.</param>
        /// <param name="consulClientFactory">The consul client factory.</param>
        public ConsulMqttServiceRouteManager(ConfigInfo configInfo, ISerializer<byte[]> serializer,
            ISerializer<string> stringSerializer, IClientWatchManager manager, IMqttServiceFactory mqttServiceFactory,
            ILogger<ConsulMqttServiceRouteManager> logger, IServiceHeartbeatManager serviceHeartbeatManager,
            IConsulClientProvider consulClientFactory) : base(stringSerializer)
        {
            _configInfo = configInfo;
            _serializer = serializer;
            _stringSerializer = stringSerializer;
            _mqttServiceFactory = mqttServiceFactory;
            _logger = logger;
            _manager = manager;
            _serviceHeartbeatManager = serviceHeartbeatManager;
            _consulClientFactory = consulClientFactory;
            EnterRoutes().Wait();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        /// clear as an asynchronous operation.
        /// </summary>
        /// <returns>一个任务。</returns>
        public override async Task ClearAsync()
        {
            var clients = await _consulClientFactory.GetClients();
            foreach (var client in clients)
            {
                //根据前缀获取consul结果
                var queryResult = await client.KV.List(_configInfo.MqttRoutePath);
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
        public override async Task<IEnumerable<MqttServiceRoute>> GetRoutesAsync()
        {
            await EnterRoutes();
            return _routes;
        }

        /// <summary>
        /// set routes as an asynchronous operation.
        /// </summary>
        /// <param name="routes">服务路由集合。</param>
        /// <returns>一个任务。</returns>
        public override async Task SetRoutesAsync(IEnumerable<MqttServiceRoute> routes)
        {
            var hostAddr = CPlatform.AppConfig.GetHostAddress();
            var mqttServiceRoutes =
                await GetRoutes(routes.Select(p => $"{_configInfo.MqttRoutePath}{p.MqttDescriptor.Topic}"));
            foreach (var route in routes)
            {
                var mqttServiceRoute = mqttServiceRoutes
                    .Where(p => p.MqttDescriptor.Topic == route.MqttDescriptor.Topic).FirstOrDefault();

                if (mqttServiceRoute != null)
                {
                    var addresses = mqttServiceRoute.MqttEndpoint.Concat(
                        route.MqttEndpoint.Except(mqttServiceRoute.MqttEndpoint)).ToList();

                    foreach (var address in route.MqttEndpoint)
                    {
                        addresses.Remove(addresses.Where(p => p.ToString() == address.ToString()).FirstOrDefault());
                        addresses.Add(address);
                    }

                    route.MqttEndpoint = addresses;
                }
            }

            await base.SetRoutesAsync(routes);
        }

        /// <summary>
        /// remve address as an asynchronous operation.
        /// </summary>
        /// <param name="endpoint">The endpoint.</param>
        public override async Task RemveAddressAsync(IEnumerable<AddressModel> endpoint)
        {
            var routes = await GetRoutesAsync();
            try
            {
                foreach (var route in routes)
                {
                    route.MqttEndpoint = route.MqttEndpoint.Except(endpoint);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            await base.SetRoutesAsync(routes);
        }

        /// <summary>
        /// remove by topic as an asynchronous operation.
        /// </summary>
        /// <param name="topic">The topic.</param>
        /// <param name="endpoint">The endpoint.</param>
        /// <returns>Task.</returns>
        public override async Task RemoveByTopicAsync(string topic, IEnumerable<AddressModel> endpoint)
        {
            var routes = await GetRoutesAsync();
            try
            {
                var route = routes.Where(p => p.MqttDescriptor.Topic == topic).SingleOrDefault();
                if (route != null)
                {
                    route.MqttEndpoint = route.MqttEndpoint.Except(endpoint);
                    await base.SetRoutesAsync(new[] {route});
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// set routes as an asynchronous operation.
        /// </summary>
        /// <param name="routes">The routes.</param>
        protected override async Task SetRoutesAsync(IEnumerable<MqttServiceDescriptor> routes)
        {
            var clients = await _consulClientFactory.GetClients();
            foreach (var client in clients)
            {
                foreach (var serviceRoute in routes)
                {
                    var nodeData = _serializer.Serialize(serviceRoute);
                    var keyValuePair = new KVPair($"{_configInfo.MqttRoutePath}{serviceRoute.MqttDescriptor.Topic}")
                        {Value = nodeData};
                    await client.KV.Put(keyValuePair);
                }
            }
        }

        #region 私有方法

        private async Task RemoveExceptRoutesAsync(IEnumerable<MqttServiceRoute> routes, AddressModel hostAddr)
        {
            routes = routes.ToArray();
            var clients = await _consulClientFactory.GetClients();
            foreach (var client in clients)
            {
                if (_routes != null)
                {
                    var oldRouteTopics = _routes.Select(i => i.MqttDescriptor.Topic).ToArray();
                    var newRouteTopics = routes.Select(i => i.MqttDescriptor.Topic).ToArray();
                    var deletedRouteTopics = oldRouteTopics.Except(newRouteTopics).ToArray();
                    foreach (var deletedRouteTopic in deletedRouteTopics)
                    {
                        var addresses = _routes.Where(p => p.MqttDescriptor.Topic == deletedRouteTopic)
                            .Select(p => p.MqttEndpoint).FirstOrDefault();
                        if (addresses.Contains(hostAddr))
                            await client.KV.Delete($"{_configInfo.MqttRoutePath}{deletedRouteTopic}");
                    }
                }
            }
        }

        private async Task<MqttServiceRoute> GetRoute(byte[] data)
        {
            if (_logger.IsEnabled(LogLevel.Trace))
                _logger.LogTrace($"准备转换mqtt服务路由，配置内容：{Encoding.UTF8.GetString(data)}。");

            if (data == null)
                return null;

            var descriptor = _serializer.Deserialize<byte[], MqttServiceDescriptor>(data);
            return (await _mqttServiceFactory.CreateMqttServiceRoutesAsync(new[] {descriptor})).First();
        }

        private async Task<MqttServiceRoute[]> GetRouteDatas(string[] routes)
        {
            var serviceRoutes = new List<MqttServiceRoute>();
            foreach (var route in routes)
            {
                var serviceRoute = await GetRouteData(route);
                serviceRoutes.Add(serviceRoute);
            }

            return serviceRoutes.ToArray();
        }

        private async Task<MqttServiceRoute> GetRouteData(string data)
        {
            if (data == null)
                return null;

            var descriptor =
                _stringSerializer.Deserialize(data, typeof(MqttServiceDescriptor)) as MqttServiceDescriptor;
            return (await _mqttServiceFactory.CreateMqttServiceRoutesAsync(new[] {descriptor})).First();
        }

        private async Task<MqttServiceRoute[]> GetRoutes(IEnumerable<string> childrens)
        {
            childrens = childrens.ToArray();
            var routes = new List<MqttServiceRoute>(childrens.Count());

            foreach (var children in childrens)
            {
                if (_logger.IsEnabled(LogLevel.Trace))
                    _logger.LogTrace($"准备从节点：{children}中获取mqtt路由信息。");

                var route = await GetRoute(children);
                if (route != null)
                    routes.Add(route);
            }

            return routes.ToArray();
        }

        private async Task<MqttServiceRoute> GetRoute(string path)
        {
            MqttServiceRoute result = null;
            var client = await GetConsulClient();
            if(client == null)  return result;
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

        private async Task EnterRoutes()
        {
            if (_routes != null && _routes.Length > 0)
                return;
            Action<string[]> action = null;
            var client = await GetConsulClient();
             if(client == null)  return;
            if (_configInfo.EnableChildrenMonitor)
            {
                var watcher = new ChildrenMonitorWatcher(GetConsulClient, _manager, _configInfo.MqttRoutePath,
                    async (oldChildrens, newChildrens) => await ChildrenChange(oldChildrens, newChildrens),
                    result => ConvertPaths(result).Result);
                action = currentData => watcher.SetCurrentData(currentData);
            }

            if (client.KV.Keys(_configInfo.MqttRoutePath).Result.Response?.Count() > 0)
            {
                var result = await client.GetChildrenAsync(_configInfo.MqttRoutePath);
                var keys = await client.KV.Keys(_configInfo.MqttRoutePath);
                var childrens = result;
                action?.Invoke(ConvertPaths(childrens).Result.Select(key => $"{_configInfo.MqttRoutePath}{key}")
                    .ToArray());
                _routes = await GetRoutes(keys.Response);
            }
            else
            {
                _routes = new MqttServiceRoute[0];
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

        private async ValueTask<ConsulClient> GetConsulClient()
        {
            var client = await _consulClientFactory.GetClient();
            return client;
        }

        /// <summary>
        /// 转化topic集合
        /// </summary>
        /// <param name="datas">信息数据集合</param>
        /// <returns>返回路径集合</returns>
        private async Task<string[]> ConvertPaths(string[] datas)
        {
            var topics = new List<string>();
            foreach (var data in datas)
            {
                var result = await GetRouteData(data);
                var topic = result?.MqttDescriptor.Topic;
                if (!string.IsNullOrEmpty(topic))
                    topics.Add(topic);
            }

            return topics.ToArray();
        }

        private async Task NodeChange(byte[] oldData, byte[] newData)
        {
            if (DataEquals(oldData, newData))
                return;

            var newRoute = await GetRoute(newData);
            //得到旧的路由。
            var oldRoute = _routes.FirstOrDefault(i => i.MqttDescriptor.Topic == newRoute.MqttDescriptor.Topic);

            lock (_routes)
            {
                //删除旧路由，并添加上新的路由。
                _routes =
                    _routes
                        .Where(i => i.MqttDescriptor.Topic != newRoute.MqttDescriptor.Topic)
                        .Concat(new[] {newRoute}).ToArray();
            }

            //触发路由变更事件。
            OnChanged(new MqttServiceRouteChangedEventArgs(newRoute, oldRoute));
        }

        private async Task ChildrenChange(string[] oldChildrens, string[] newChildrens)
        {
            if (_logger.IsEnabled(LogLevel.Debug))
                _logger.LogDebug($"最新的mqtt节点信息：{string.Join(",", newChildrens)}");

            if (_logger.IsEnabled(LogLevel.Debug))
                _logger.LogDebug($"旧的mqtt节点信息：{string.Join(",", oldChildrens)}");

            //计算出已被删除的节点。
            var deletedChildrens = oldChildrens.Except(newChildrens).ToArray();
            //计算出新增的节点。
            var createdChildrens = newChildrens.Except(oldChildrens).ToArray();

            foreach (var deletedChildren in deletedChildrens)
            {
                _logger.LogTrace($"需要被删除的MQTT路由节点：{deletedChildren}");
            }
           
            foreach (var createdChildren in createdChildrens)
            {
                _logger.LogTrace($"需要被添加的MQTT路由节点：{createdChildren}");
            }

            //获取新增的路由信息。
            var newRoutes = (await GetRoutes(createdChildrens)).ToArray();

            var routes = _routes.ToArray();
            lock (_routes)
            {
                _routes = _routes
                    //删除无效的节点路由。
                    .Where(i => !deletedChildrens.Contains($"{_configInfo.MqttRoutePath}{i.MqttDescriptor.Topic}"))
                    //连接上新的路由。
                    .Concat(newRoutes)
                    .ToArray();
            }

            //需要删除的路由集合。
            var deletedRoutes = routes
                .Where(i => deletedChildrens.Contains($"{_configInfo.MqttRoutePath}{i.MqttDescriptor.Topic}"))
                .ToArray();
            //触发删除事件。
            OnRemoved(deletedRoutes.Select(route => new MqttServiceRouteEventArgs(route)).ToArray());

            //触发路由被创建事件。
            OnCreated(newRoutes.Select(route => new MqttServiceRouteEventArgs(route)).ToArray());

            if (deletedChildrens.Any() || createdChildrens.Any())
            {
                _logger.LogInformation($"MQTT路由数据更新成功，删除节点数：{deletedChildrens.Length}，添加节点数：{createdChildrens.Length}。");
            }
        }

        #endregion
    }
}