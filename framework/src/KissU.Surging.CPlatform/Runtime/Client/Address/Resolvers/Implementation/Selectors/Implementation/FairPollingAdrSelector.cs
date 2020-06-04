using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KissU.Surging.CPlatform.Address;
using KissU.Surging.CPlatform.Routing;
using KissU.Surging.CPlatform.Routing.Implementation;
using KissU.Surging.CPlatform.Runtime.Client.HealthChecks;

namespace KissU.Surging.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation
{
    /// <summary>
    /// 压力最小优先地址选择器.
    /// Implements the <see cref="AddressSelectorBase" />
    /// </summary>
    /// <seealso cref="AddressSelectorBase" />
    public class FairPollingAdrSelector : AddressSelectorBase
    {
        private readonly ConcurrentDictionary<string, Lazy<AddressEntry>> _concurrent =
            new ConcurrentDictionary<string, Lazy<AddressEntry>>();

        private readonly IHealthCheckService _healthCheckService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FairPollingAdrSelector" /> class.
        /// </summary>
        /// <param name="serviceRouteManager">The service route manager.</param>
        /// <param name="healthCheckService">The health check service.</param>
        public FairPollingAdrSelector(IServiceRouteManager serviceRouteManager, IHealthCheckService healthCheckService)
        {
            _healthCheckService = healthCheckService;

            // 路由发生变更时重建地址条目。
            serviceRouteManager.Changed += ServiceRouteManager_Removed;
            serviceRouteManager.Removed += ServiceRouteManager_Removed;
        }

        private void ServiceRouteManager_Removed(object sender, ServiceRouteEventArgs e)
        {
            var key = GetCacheKey(e.Route.ServiceDescriptor);
            Lazy<AddressEntry> value;
            _concurrent.TryRemove(key, out value);
        }

        private static string GetCacheKey(ServiceDescriptor descriptor)
        {
            return descriptor.Id;
        }

        /// <summary>
        /// 选择.
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
            do
            {
                addressModel = addressEntry.GetAddress();
                if (len <= index)
                {
                    addressModel = null;
                    break;
                }

                index++;
            } while (await _healthCheckService.IsHealth(addressModel) == false);

            return addressModel;
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
                _address = address.OrderBy(p => p.ProcessorTime).ToArray();
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