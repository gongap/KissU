using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consul;
using KissU.CPlatform.Runtime.Client;
using KissU.CPlatform.Runtime.Client.Implementation;
using KissU.Serialization;
using KissU.ServiceDiscovery.Consul.Configurations;
using KissU.ServiceDiscovery.Consul.Internal;
using KissU.ServiceDiscovery.Consul.Utilitys;
using KissU.ServiceDiscovery.Consul.WatcherProvider;
using Microsoft.Extensions.Logging;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace KissU.ServiceDiscovery.Consul
{
    /// <summary>
    /// ConsulServiceSubscribeManager.
    /// Implements the <see cref="KissU.CPlatform.Runtime.Client.Implementation.ServiceSubscribeManagerBase" />
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="KissU.CPlatform.Runtime.Client.Implementation.ServiceSubscribeManagerBase" />
    /// <seealso cref="System.IDisposable" />
    public class ConsulServiceSubscribeManager : ServiceSubscribeManagerBase, IDisposable
    {
        private readonly ConfigInfo _configInfo;
        private readonly IConsulClientProvider _consulClientFactory;
        private readonly ILogger<ConsulServiceSubscribeManager> _logger;
        private readonly IClientWatchManager _manager;
        private readonly ISerializer<byte[]> _serializer;
        private readonly IServiceSubscriberFactory _serviceSubscriberFactory;
        private readonly ISerializer<string> _stringSerializer;
        private ServiceSubscriber[] _subscribers;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsulServiceSubscribeManager" /> class.
        /// </summary>
        /// <param name="configInfo">The configuration information.</param>
        /// <param name="serializer">The serializer.</param>
        /// <param name="stringSerializer">The string serializer.</param>
        /// <param name="manager">The manager.</param>
        /// <param name="serviceSubscriberFactory">The service subscriber factory.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="consulClientFactory">The consul client factory.</param>
        public ConsulServiceSubscribeManager(ConfigInfo configInfo, ISerializer<byte[]> serializer,
            ISerializer<string> stringSerializer, IClientWatchManager manager,
            IServiceSubscriberFactory serviceSubscriberFactory,
            ILogger<ConsulServiceSubscribeManager> logger, IConsulClientProvider consulClientFactory) : base(
            stringSerializer)
        {
            _configInfo = configInfo;
            _serializer = serializer;
            _stringSerializer = stringSerializer;
            _serviceSubscriberFactory = serviceSubscriberFactory;
            _logger = logger;
            _manager = manager;
            _consulClientFactory = consulClientFactory;
            EnterSubscribers().Wait();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        /// 获取所有可用的服务订阅者信息。
        /// </summary>
        /// <returns>服务路由集合。</returns>
        public override async Task<IEnumerable<ServiceSubscriber>> GetSubscribersAsync()
        {
            await EnterSubscribers();
            return _subscribers;
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
                var queryResult = await client.KV.List(_configInfo.SubscriberPath);
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
        /// set subscribers as an asynchronous operation.
        /// </summary>
        /// <param name="subscribers">The subscribers.</param>
        /// <returns>一个任务。</returns>
        protected override async Task SetSubscribersAsync(IEnumerable<ServiceSubscriberDescriptor> subscribers)
        {
            subscribers = subscribers.ToArray();
            var clients = await _consulClientFactory.GetClients();
            foreach (var client in clients)
            {
                if (_subscribers != null)
                {
                    var oldSubscriberIds = _subscribers.Select(i => i.ServiceDescriptor.Id).ToArray();
                    var newSubscriberIds = subscribers.Select(i => i.ServiceDescriptor.Id).ToArray();
                    var deletedSubscriberIds = oldSubscriberIds.Except(newSubscriberIds).ToArray();
                    foreach (var deletedSubscriberId in deletedSubscriberIds)
                    {
                        await client.KV.Delete($"{_configInfo.SubscriberPath}{deletedSubscriberId}");
                    }
                }

                foreach (var serviceSubscriber in subscribers)
                {
                    var nodeData = _serializer.Serialize(serviceSubscriber);
                    var keyValuePair =
                        new KVPair($"{_configInfo.SubscriberPath}{serviceSubscriber.ServiceDescriptor.Id}")
                            {Value = nodeData};
                    await client.KV.Put(keyValuePair);
                }
            }
        }

        /// <summary>
        /// set subscribers as an asynchronous operation.
        /// </summary>
        /// <param name="subscribers">The subscribers.</param>
        public override async Task SetSubscribersAsync(IEnumerable<ServiceSubscriber> subscribers)
        {
            var serviceSubscribers =
                await GetSubscribers(subscribers.Select(p => $"{_configInfo.SubscriberPath}{p.ServiceDescriptor.Id}"));
            if (serviceSubscribers.Count() > 0)
            {
                foreach (var subscriber in subscribers)
                {
                    var serviceSubscriber = serviceSubscribers
                        .Where(p => p.ServiceDescriptor.Id == subscriber.ServiceDescriptor.Id).FirstOrDefault();
                    if (serviceSubscriber != null)
                    {
                        subscriber.Address = subscriber.Address.Concat(
                            subscriber.Address.Except(serviceSubscriber.Address));
                    }
                }
            }

            await base.SetSubscribersAsync(subscribers);
        }

        private async Task<ServiceSubscriber> GetSubscriber(byte[] data)
        {
            if (_logger.IsEnabled(LogLevel.Debug))
                _logger.LogDebug($"准备转换服务订阅者，配置内容：{Encoding.UTF8.GetString(data)}。");

            if (data == null)
                return null;

            var descriptor = _serializer.Deserialize<byte[], ServiceSubscriberDescriptor>(data);
            return (await _serviceSubscriberFactory.CreateServiceSubscribersAsync(new[] {descriptor})).First();
        }

        private async Task EnterSubscribers()
        {
            if (_subscribers != null)
                return;
            var client = await _consulClientFactory.GetClient();
            if (client.KV.Keys(_configInfo.SubscriberPath).Result.Response?.Count() > 0)
            {
                var result = await client.GetChildrenAsync(_configInfo.SubscriberPath);
                var keys = await client.KV.Keys(_configInfo.SubscriberPath);
                _subscribers = await GetSubscribers(keys.Response);
            }
            else
            {
                if (_logger.IsEnabled(LogLevel.Warning))
                    _logger.LogWarning($"无法获取订阅者信息，因为节点：{_configInfo.SubscriberPath}，不存在。");
                _subscribers = new ServiceSubscriber[0];
            }
        }

        private async Task<ServiceSubscriber> GetSubscriber(string path)
        {
            ServiceSubscriber result = null;
            var client = await _consulClientFactory.GetClient();
            var queryResult = await client.KV.Keys(path);
            if (queryResult.Response != null)
            {
                var data = await client.GetDataAsync(path);
                if (data != null)
                {
                    result = await GetSubscriber(data);
                }
            }

            return result;
        }

        private async Task<ServiceSubscriber[]> GetSubscribers(IEnumerable<string> childrens)
        {
            childrens = childrens.ToArray();
            var subscribers = new List<ServiceSubscriber>(childrens.Count());
            foreach (var children in childrens)
            {
                if (_logger.IsEnabled(LogLevel.Debug))
                    _logger.LogDebug($"准备从节点：{children}中获取订阅者信息。");

                var subscriber = await GetSubscriber(children);
                if (subscriber != null)
                    subscribers.Add(subscriber);
            }

            return subscribers.ToArray();
        }
    }
}