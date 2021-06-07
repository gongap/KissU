using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consul;
using KissU.CPlatform.Routing;
using KissU.CPlatform.Routing.Implementation;
using KissU.CPlatform.Runtime.Client;
using KissU.CPlatform.Runtime.Server;
using KissU.CPlatform.Support;
using KissU.CPlatform.Support.Implementation;
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
    /// ConsulServiceCommandManager.
    /// Implements the <see cref="KissU.CPlatform.Support.Implementation.ServiceCommandManagerBase" />
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="KissU.CPlatform.Support.Implementation.ServiceCommandManagerBase" />
    /// <seealso cref="System.IDisposable" />
    public class ConsulServiceCommandManager : ServiceCommandManagerBase, IDisposable
    {
        private readonly ConfigInfo _configInfo;
        private readonly IConsulClientProvider _consulClientFactory;
        private readonly ILogger<ConsulServiceCommandManager> _logger;
        private readonly IClientWatchManager _manager;
        private readonly ISerializer<byte[]> _serializer;
        private readonly IServiceHeartbeatManager _serviceHeartbeatManager;
        private readonly IServiceRouteManager _serviceRouteManager;
        private readonly ISerializer<string> _stringSerializer;
        private ServiceCommandDescriptor[] _serviceCommands;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsulServiceCommandManager" /> class.
        /// </summary>
        /// <param name="configInfo">The configuration information.</param>
        /// <param name="serializer">The serializer.</param>
        /// <param name="stringSerializer">The string serializer.</param>
        /// <param name="serviceRouteManager">The service route manager.</param>
        /// <param name="manager">The manager.</param>
        /// <param name="serviceEntryManager">The service entry manager.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="serviceHeartbeatManager">The service heartbeat manager.</param>
        /// <param name="consulClientFactory">The consul client factory.</param>
        public ConsulServiceCommandManager(ConfigInfo configInfo, ISerializer<byte[]> serializer,
            ISerializer<string> stringSerializer, IServiceRouteManager serviceRouteManager, IClientWatchManager manager,
            IServiceEntryManager serviceEntryManager,
            ILogger<ConsulServiceCommandManager> logger,
            IServiceHeartbeatManager serviceHeartbeatManager, IConsulClientProvider consulClientFactory) : base(
            stringSerializer, serviceEntryManager)
        {
            _configInfo = configInfo;
            _serializer = serializer;
            _logger = logger;
            _consulClientFactory = consulClientFactory;
            _stringSerializer = stringSerializer;
            _manager = manager;
            _serviceRouteManager = serviceRouteManager;
            _serviceHeartbeatManager = serviceHeartbeatManager;
            EnterServiceCommands().Wait();
            _serviceRouteManager.Removed += ServiceRouteManager_Removed;
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
                var queryResult = await client.KV.List(_configInfo.CommandPath);
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
        /// 获取所有可用的服务命令信息。
        /// </summary>
        /// <returns>服务命令集合。</returns>
        public override async Task<IEnumerable<ServiceCommandDescriptor>> GetServiceCommandsAsync()
        {
            await EnterServiceCommands();
            return _serviceCommands;
        }

        /// <summary>
        /// Nodes the change.
        /// </summary>
        /// <param name="oldData">The old data.</param>
        /// <param name="newData">The new data.</param>
        public void NodeChange(byte[] oldData, byte[] newData)
        {
            if (DataEquals(oldData, newData))
                return;

            var newCommand = GetServiceCommand(newData);
            //得到旧的服务命令。
            var oldCommand = _serviceCommands.FirstOrDefault(i => i.ServiceId == newCommand.ServiceId);

            lock (_serviceCommands)
            {
                //删除旧服务命令，并添加上新的服务命令。
                _serviceCommands =
                    _serviceCommands
                        .Where(i => i.ServiceId != newCommand.ServiceId)
                        .Concat(new[] {newCommand}).ToArray();
            }

            if (newCommand == null)
                //触发删除事件。
                OnRemoved(new ServiceCommandEventArgs(oldCommand));

            else if (oldCommand == null)
                OnCreated(new ServiceCommandEventArgs(newCommand));
            else
                //触发服务命令变更事件。
                OnChanged(new ServiceCommandChangedEventArgs(newCommand, oldCommand));
        }

        /// <summary>
        /// Nodes the change.
        /// </summary>
        /// <param name="newCommand">The new command.</param>
        public void NodeChange(ServiceCommandDescriptor newCommand)
        {
            //得到旧的服务命令。
            var oldCommand = _serviceCommands.FirstOrDefault(i => i.ServiceId == newCommand.ServiceId);

            lock (_serviceCommands)
            {
                //删除旧服务命令，并添加上新的服务命令。
                _serviceCommands =
                    _serviceCommands
                        .Where(i => i.ServiceId != newCommand.ServiceId)
                        .Concat(new[] {newCommand}).ToArray();
            }

            //触发服务命令变更事件。
            OnChanged(new ServiceCommandChangedEventArgs(newCommand, oldCommand));
        }

        /// <summary>
        /// set service commands as an asynchronous operation.
        /// </summary>
        /// <param name="serviceCommands">The service commands.</param>
        public override async Task SetServiceCommandsAsync(IEnumerable<ServiceCommandDescriptor> serviceCommands)
        {
            var clients = await _consulClientFactory.GetClients();
            foreach (var client in clients)
            {
                if (_logger.IsEnabled(LogLevel.Debug))
                    _logger.LogDebug("准备添加服务命令.");
                foreach (var serviceCommand in serviceCommands)
                {
                    var nodeData = _serializer.Serialize(serviceCommand);
                    var keyValuePair = new KVPair($"{_configInfo.CommandPath}{serviceCommand.ServiceId}")
                        {Value = nodeData};
                    var isSuccess = await client.KV.Put(keyValuePair);
                    if (isSuccess.Response)
                        NodeChange(serviceCommand);
                }
            }
        }

        /// <summary>
        /// initialize service commands as an asynchronous operation.
        /// </summary>
        /// <param name="serviceCommands">The service commands.</param>
        protected override async Task InitServiceCommandsAsync(IEnumerable<ServiceCommandDescriptor> serviceCommands)
        {
            var commands =
                await GetServiceCommands(serviceCommands.Select(p => $"{_configInfo.CommandPath}{p.ServiceId}"));
            if (commands.Count() == 0 || _configInfo.ReloadOnChange)
            {
                await SetServiceCommandsAsync(serviceCommands);
            }
        }

        private void ServiceRouteManager_Removed(object sender, ServiceRouteEventArgs e)
        {
            var clients = _consulClientFactory.GetClients().Result;
            foreach (var client in clients)
            {
                client.KV.Delete($"{_configInfo.CommandPath}{e.Route.ServiceDescriptor.Id}").Wait();
            }
        }


        private ServiceCommandDescriptor GetServiceCommand(byte[] data)
        {
            if (_logger.IsEnabled(LogLevel.Trace))
                _logger.LogTrace($"准备转换服务命令，配置内容：{Encoding.UTF8.GetString(data)}。");

            if (data == null)
                return null;

            var descriptor = _serializer.Deserialize<byte[], ServiceCommandDescriptor>(data);
            return descriptor;
        }

        private ServiceCommandDescriptor[] GetServiceCommandDatas(string[] commands)
        {
            var serviceCommands = new List<ServiceCommandDescriptor>();
            foreach (var command in commands)
            {
                var serviceCommand = GetServiceCommandData(command);
                serviceCommands.Add(serviceCommand);
            }

            return serviceCommands.ToArray();
        }

        private ServiceCommandDescriptor GetServiceCommandData(string data)
        {
            if (data == null)
                return null;

            var serviceCommand =
                _stringSerializer.Deserialize(data, typeof(ServiceCommandDescriptor)) as ServiceCommandDescriptor;
            return serviceCommand;
        }

        private async Task<ServiceCommandDescriptor> GetServiceCommand(string path)
        {
            ServiceCommandDescriptor result = null;
            var client = await GetConsulClient();
            var watcher = new NodeMonitorWatcher(GetConsulClient, _manager, path,
                (oldData, newData) => NodeChange(oldData, newData), tmpPath =>
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
                    result = GetServiceCommand(data);
                }
            }

            return result;
        }

        private async Task<ServiceCommandDescriptor[]> GetServiceCommands(IEnumerable<string> childrens)
        {
            var rootPath = _configInfo.CommandPath;
            if (!rootPath.EndsWith("/"))
                rootPath += "/";

            childrens = childrens.ToArray();
            var serviceCommands = new List<ServiceCommandDescriptor>(childrens.Count());

            foreach (var children in childrens)
            {
                if (_logger.IsEnabled(LogLevel.Trace))
                    _logger.LogTrace($"准备从节点：{children}中获取服务命令信息。");

                var serviceCommand = await GetServiceCommand(children);
                if (serviceCommand != null)
                    serviceCommands.Add(serviceCommand);
            }

            return serviceCommands.ToArray();
        }

        private async ValueTask<ConsulClient> GetConsulClient()
        {
            var client = await _consulClientFactory.GetClient();
            return client;
        }

        private async Task EnterServiceCommands()
        {
            if (_serviceCommands != null)
                return;
            Action<string[]> action = null;
            var client = await GetConsulClient();
            if (_configInfo.EnableChildrenMonitor)
            {
                var watcher = new ChildrenMonitorWatcher(GetConsulClient, _manager, _configInfo.CommandPath,
                    async (oldChildrens, newChildrens) => await ChildrenChange(oldChildrens, newChildrens),
                    result => ConvertPaths(result));
                action = currentData => watcher.SetCurrentData(currentData);
            }

            if (client.KV.Keys(_configInfo.CommandPath).Result.Response?.Count() > 0)
            {
                var result = await client.GetChildrenAsync(_configInfo.CommandPath);
                var keys = await client.KV.Keys(_configInfo.CommandPath);
                var childrens = result;
                action?.Invoke(ConvertPaths(childrens).Select(key => $"{_configInfo.CommandPath}{key}").ToArray());
                _serviceCommands = await GetServiceCommands(keys.Response);
            }
            else
            {
                //if (_logger.IsEnabled(LogLevel.Warning))
                //    _logger.LogWarning($"无法获取服务命令信息，因为节点：{_configInfo.CommandPath}，不存在。");
                _serviceCommands = new ServiceCommandDescriptor[0];
            }
        }

        /// <summary>
        /// 转化路径集合
        /// </summary>
        /// <param name="datas">信息数据集合</param>
        /// <returns>返回路径集合</returns>
        private string[] ConvertPaths(string[] datas)
        {
            var paths = new List<string>();
            foreach (var data in datas)
            {
                var result = GetServiceCommandData(data);
                var serviceId = result?.ServiceId;
                if (!string.IsNullOrEmpty(serviceId))
                    paths.Add(serviceId);
            }

            return paths.ToArray();
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
        /// Childrens the change.
        /// </summary>
        /// <param name="oldChildrens">The old childrens.</param>
        /// <param name="newChildrens">The new childrens.</param>
        public async Task ChildrenChange(string[] oldChildrens, string[] newChildrens)
        {
            //计算出已被删除的节点。
            var deletedChildrens = oldChildrens.Except(newChildrens).ToArray();
            //计算出新增的节点。
            var createdChildrens = newChildrens.Except(oldChildrens).ToArray();

            if (_logger.IsEnabled(LogLevel.Debug) && deletedChildrens?.Count() > 0)
                _logger.LogDebug($"需要被删除的服务命令节点：{string.Join(",", deletedChildrens)}");
            if (_logger.IsEnabled(LogLevel.Debug) && createdChildrens?.Count() > 0)
                _logger.LogDebug($"需要被添加的服务命令节点：{string.Join(",", createdChildrens)}");

            //获取新增的服务命令信息。
            var newCommands = (await GetServiceCommands(createdChildrens)).ToArray();

            var serviceCommands = _serviceCommands.ToArray();
            lock (_serviceCommands)
            {
                _serviceCommands = _serviceCommands
                    //删除无效的节点服务命令。
                    .Where(i => !deletedChildrens.Contains($"{_configInfo.CommandPath}{i.ServiceId}"))
                    //连接上新的服务命令。
                    .Concat(newCommands)
                    .ToArray();
            }

            //需要删除的服务命令集合。
            var deletedRoutes = serviceCommands
                .Where(i => deletedChildrens.Contains($"{_configInfo.CommandPath}{i.ServiceId}")).ToArray();
            //触发删除事件。
            OnRemoved(deletedRoutes.Select(command => new ServiceCommandEventArgs(command)).ToArray());

            //触发服务命令被创建事件。
            OnCreated(newCommands.Select(command => new ServiceCommandEventArgs(command)).ToArray());

            if (_logger.IsEnabled(LogLevel.Debug))
                _logger.LogDebug("服务命令数据更新成功。");
        }
    }
}