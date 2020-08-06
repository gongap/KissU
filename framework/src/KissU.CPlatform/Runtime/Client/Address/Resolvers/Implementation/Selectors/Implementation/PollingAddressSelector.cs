using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KissU.CPlatform.Address;
using KissU.CPlatform.Routing;
using KissU.CPlatform.Routing.Implementation;
using KissU.CPlatform.Runtime.Client.HealthChecks;

namespace KissU.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation
{
    /// <summary>
    /// 轮询的地址选择器。
    /// </summary>
    public class PollingAddressSelector : AddressSelectorBase
    {
        private readonly ConcurrentDictionary<string, Lazy<AddressEntry>> _concurrent =
            new ConcurrentDictionary<string, Lazy<AddressEntry>>();

        private readonly IHealthCheckService _healthCheckService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PollingAddressSelector" /> class.
        /// </summary>
        /// <param name="serviceRouteManager">The service route manager.</param>
        /// <param name="healthCheckService">The health check service.</param>
        public PollingAddressSelector(IServiceRouteManager serviceRouteManager, IHealthCheckService healthCheckService)
        {
            _healthCheckService = healthCheckService;

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

            // 根据服务id缓存服务地址。
            var addressEntry = _concurrent
                .GetOrAdd(key, k => new Lazy<AddressEntry>(() => new AddressEntry(context.Address))).Value;
            AddressModel addressModel;
            var index = 0;
            var len = context.Address.Count();
            ValueTask<bool> vt;
            do
            {
                addressModel = addressEntry.GetAddress();
                if (len <= index)
                {
                    addressModel = null;
                    break;
                }

                index++;
                vt = _healthCheckService.IsHealth(addressModel);
            } while (!(vt.IsCompletedSuccessfully ? vt.Result : await vt));

            return addressModel;
        }

        private static string GetCacheKey(ServiceDescriptor descriptor)
        {
            return descriptor.Id;
        }

        /// <summary>
        /// 检查健康.
        /// </summary>
        /// <param name="addressModel">The address model.</param>
        /// <returns>ValueTask&lt;System.Boolean&gt;.</returns>
        public async ValueTask<bool> CheckHealth(AddressModel addressModel)
        {
            var vt = _healthCheckService.IsHealth(addressModel);
            return vt.IsCompletedSuccessfully ? vt.Result : await vt;
        }

        private void ServiceRouteManager_Removed(object sender, ServiceRouteEventArgs e)
        {
            var key = GetCacheKey(e.Route.ServiceDescriptor);
            Lazy<AddressEntry> value;
            _concurrent.TryRemove(key, out value);
        }

        /// <summary>
        /// AddressEntry.
        /// </summary>
        protected class AddressEntry
        {
            private readonly AddressModel[] _address;
            private readonly int _maxIndex;
            private int _index;
            private int _lock;

            /// <summary>
            /// Initializes a new instance of the <see cref="AddressEntry" /> class.
            /// </summary>
            /// <param name="address">The address.</param>
            public AddressEntry(IEnumerable<AddressModel> address)
            {
                _address = address.ToArray();
                _maxIndex = _address.Length - 1;
            }

            /// <summary>
            /// 获取地址.
            /// </summary>
            /// <returns>AddressModel.</returns>
            public AddressModel GetAddress()
            {
                while (true)
                {
                    // 如果无法得到锁则等待
                    if (Interlocked.Exchange(ref _lock, 1) != 0)
                    {
                        default(SpinWait).SpinOnce();
                        continue;
                    }

                    var address = _address[_index];

                    // 设置为下一个
                    if (_maxIndex > _index)
                    {
                        _index++;
                    }
                    else
                    {
                        _index = 0;
                    }

                    // 释放锁
                    Interlocked.Exchange(ref _lock, 0);

                    return address;
                }
            }
        }
    }
}