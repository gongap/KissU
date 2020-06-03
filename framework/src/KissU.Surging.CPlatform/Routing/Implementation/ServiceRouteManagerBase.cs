using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Address;
using KissU.Serialization;

namespace KissU.Surging.CPlatform.Routing.Implementation
{
    /// <summary>
    /// 服务路由管理者基类。
    /// </summary>
    public abstract class ServiceRouteManagerBase : IServiceRouteManager
    {
        private readonly ISerializer<string> _serializer;
        private EventHandler<ServiceRouteChangedEventArgs> _changed;
        private EventHandler<ServiceRouteEventArgs> _created;
        private EventHandler<ServiceRouteEventArgs> _removed;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceRouteManagerBase" /> class.
        /// </summary>
        /// <param name="serializer">The serializer.</param>
        protected ServiceRouteManagerBase(ISerializer<string> serializer)
        {
            _serializer = serializer;
        }

        /// <summary>
        /// 服务路由被创建。
        /// </summary>
        public event EventHandler<ServiceRouteEventArgs> Created
        {
            add => _created += value;
            remove => _created -= value;
        }

        /// <summary>
        /// 服务路由被删除。
        /// </summary>
        public event EventHandler<ServiceRouteEventArgs> Removed
        {
            add => _removed += value;
            remove => _removed -= value;
        }

        /// <summary>
        /// 服务路由被修改。
        /// </summary>
        public event EventHandler<ServiceRouteChangedEventArgs> Changed
        {
            add => _changed += value;
            remove => _changed -= value;
        }

        /// <summary>
        /// 获取所有可用的服务路由信息。
        /// </summary>
        /// <returns>服务路由集合。</returns>
        public abstract Task<IEnumerable<ServiceRoute>> GetRoutesAsync();

        /// <summary>
        /// 设置服务路由。
        /// </summary>
        /// <param name="routes">服务路由集合。</param>
        /// <returns>一个任务。</returns>
        /// <exception cref="ArgumentNullException">routes</exception>
        public virtual Task SetRoutesAsync(IEnumerable<ServiceRoute> routes)
        {
            if (routes == null)
            {
                throw new ArgumentNullException(nameof(routes));
            }

            var descriptors = routes.Where(route => route != null).Select(route => new ServiceRouteDescriptor
            {
                AddressDescriptors = route.Address?.Select(address => new ServiceAddressDescriptor
                {
                    Value = _serializer.Serialize(address)
                }) ?? Enumerable.Empty<ServiceAddressDescriptor>(),
                ServiceDescriptor = route.ServiceDescriptor
            });

            return SetRoutesAsync(descriptors);
        }

        /// <summary>
        /// 移除地址列表
        /// </summary>
        /// <param name="Address">The address.</param>
        /// <returns>一个任务。</returns>
        public abstract Task RemveAddressAsync(IEnumerable<AddressModel> Address);

        /// <summary>
        /// 清空所有的服务路由。
        /// </summary>
        /// <returns>一个任务。</returns>
        public abstract Task ClearAsync();

        /// <summary>
        /// 设置服务路由。
        /// </summary>
        /// <param name="routes">服务路由集合。</param>
        /// <returns>一个任务。</returns>
        protected abstract Task SetRoutesAsync(IEnumerable<ServiceRouteDescriptor> routes);

        /// <summary>
        /// Called when [created].
        /// </summary>
        /// <param name="args">The arguments.</param>
        protected void OnCreated(params ServiceRouteEventArgs[] args)
        {
            if (_created == null)
            {
                return;
            }

            foreach (var arg in args)
            {
                _created(this, arg);
            }
        }

        /// <summary>
        /// Called when [changed].
        /// </summary>
        /// <param name="args">The arguments.</param>
        protected void OnChanged(params ServiceRouteChangedEventArgs[] args)
        {
            if (_changed == null)
            {
                return;
            }

            foreach (var arg in args)
            {
                _changed(this, arg);
            }
        }

        /// <summary>
        /// Called when [removed].
        /// </summary>
        /// <param name="args">The arguments.</param>
        protected void OnRemoved(params ServiceRouteEventArgs[] args)
        {
            if (_removed == null)
            {
                return;
            }

            foreach (var arg in args)
            {
                _removed(this, arg);
            }
        }
    }
}