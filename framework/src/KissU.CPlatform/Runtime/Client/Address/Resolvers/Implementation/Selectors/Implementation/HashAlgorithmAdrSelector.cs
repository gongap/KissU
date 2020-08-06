using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.CPlatform.Address;
using KissU.CPlatform.HashAlgorithms;
using KissU.CPlatform.Routing;
using KissU.CPlatform.Routing.Implementation;
using KissU.CPlatform.Runtime.Client.HealthChecks;
using KissU.CPlatform.Runtime.Client.HealthChecks.Implementation;

namespace KissU.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation
{
    /// <summary>
    /// 哈希算法地址选择器.
    /// Implements the <see cref="AddressSelectorBase" />
    /// </summary>
    /// <seealso cref="AddressSelectorBase" />
    public class HashAlgorithmAdrSelector : AddressSelectorBase
    {
        private readonly ConcurrentDictionary<string, ConsistentHash<AddressModel>> _concurrent =
            new ConcurrentDictionary<string, ConsistentHash<AddressModel>>();

        private readonly IHashAlgorithm _hashAlgorithm;
        private readonly IHealthCheckService _healthCheckService;

        private readonly List<ValueTuple<string, AddressModel>> _unHealths =
            new List<ValueTuple<string, AddressModel>>();

        /// <summary>
        /// Initializes a new instance of the <see cref="HashAlgorithmAdrSelector" /> class.
        /// </summary>
        /// <param name="serviceRouteManager">The service route manager.</param>
        /// <param name="healthCheckService">The health check service.</param>
        /// <param name="hashAlgorithm">The hash algorithm.</param>
        public HashAlgorithmAdrSelector(IServiceRouteManager serviceRouteManager,
            IHealthCheckService healthCheckService, IHashAlgorithm hashAlgorithm)
        {
            _healthCheckService = healthCheckService;
            _hashAlgorithm = hashAlgorithm;

            // 路由发生变更时重建地址条目。
            serviceRouteManager.Changed += ServiceRouteManager_Removed;
            serviceRouteManager.Removed += ServiceRouteManager_Removed;
        }

        /// <summary>
        /// 选择一个地址。
        /// </summary>
        /// <param name="context">地址选择上下文。</param>
        /// <returns>地址模型。</returns>
        protected override async ValueTask<AddressModel> SelectAsync(AddressSelectContext context)
        {
            var key = GetCacheKey(context.Descriptor);
            var addressEntry = _concurrent.GetOrAdd(key, k =>
            {
                var len = context.Address.Count();
                len = len > 1 && len < 10 ? len * 10 : len;
                var hash = new ConsistentHash<AddressModel>(_hashAlgorithm, len);
                foreach (var address in context.Address)
                {
                    hash.Add(address, address.ToString());
                }

                return hash;
            });
            AddressModel addressModel;
            var isHealth = false;
            var index = 0;
            var count = context.Address.Count();
            do
            {
                addressModel = addressEntry.GetItemNode(context.Item);
                if (count <= index)
                {
                    addressModel = null;
                    break;
                }

                index++;
                isHealth = await _healthCheckService.IsHealth(addressModel);
                if (!isHealth)
                {
                    addressEntry.Remove(addressModel.ToString());
                    _unHealths.Add(new ValueTuple<string, AddressModel>(key, addressModel));
                    _healthCheckService.Changed += ItemNode_Changed;
                }
            } while (!isHealth);

            return addressModel;
        }

        private void ItemNode_Changed(object sender, HealthCheckEventArgs e)
        {
            var list = _unHealths.Where(p => p.Item2.ToString() == e.Address.ToString()).ToList();
            foreach (var item in list)
            {
                if (item.Item1 != null && e.Health)
                {
                    var addressEntry = _concurrent.GetValueOrDefault(item.Item1);
                    addressEntry.Add(item.Item2, item.Item2.ToString());
                    _unHealths.Remove(item);
                }
            }

            if (_unHealths.Count == 0)
            {
                _healthCheckService.Changed -= ItemNode_Changed;
            }
        }

        private static string GetCacheKey(ServiceDescriptor descriptor)
        {
            return descriptor.Id;
        }

        private void ServiceRouteManager_Removed(object sender, ServiceRouteEventArgs e)
        {
            var key = GetCacheKey(e.Route.ServiceDescriptor);
            var item = _unHealths
                .Where(p => e.Route.Address.Select(addr => addr.ToString()).Contains(p.Item2.ToString())).ToList();
            item.ForEach(p => _unHealths.Remove(p));
            _concurrent.TryRemove(key, out var value);
        }
    }
}