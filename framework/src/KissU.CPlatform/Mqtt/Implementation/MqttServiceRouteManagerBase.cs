using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Serialization;
using KissU.CPlatform.Address;

namespace KissU.CPlatform.Mqtt.Implementation
{
    /// <summary>
    /// MqttServiceRouteEventArgs.
    /// </summary>
    public class MqttServiceRouteEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MqttServiceRouteEventArgs" /> class.
        /// </summary>
        /// <param name="route">The route.</param>
        public MqttServiceRouteEventArgs(MqttServiceRoute route)
        {
            Route = route;
        }

        /// <summary>
        /// Gets the route.
        /// </summary>
        public MqttServiceRoute Route { get; }
    }

    /// <summary>
    /// MqttServiceRouteChangedEventArgs.
    /// Implements the <see cref="MqttServiceRouteEventArgs" />
    /// </summary>
    /// <seealso cref="MqttServiceRouteEventArgs" />
    public class MqttServiceRouteChangedEventArgs : MqttServiceRouteEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MqttServiceRouteChangedEventArgs" /> class.
        /// </summary>
        /// <param name="route">The route.</param>
        /// <param name="oldRoute">The old route.</param>
        public MqttServiceRouteChangedEventArgs(MqttServiceRoute route, MqttServiceRoute oldRoute) : base(route)
        {
            OldRoute = oldRoute;
        }

        /// <summary>
        /// Gets or sets the old route.
        /// </summary>
        public MqttServiceRoute OldRoute { get; set; }
    }

    /// <summary>
    /// MqttServiceRouteManagerBase.
    /// Implements the <see cref="IMqttServiceRouteManager" />
    /// </summary>
    /// <seealso cref="IMqttServiceRouteManager" />
    public abstract class MqttServiceRouteManagerBase : IMqttServiceRouteManager
    {
        private readonly ISerializer<string> _serializer;
        private EventHandler<MqttServiceRouteChangedEventArgs> _changed;
        private EventHandler<MqttServiceRouteEventArgs> _created;
        private EventHandler<MqttServiceRouteEventArgs> _removed;

        /// <summary>
        /// Initializes a new instance of the <see cref="MqttServiceRouteManagerBase" /> class.
        /// </summary>
        /// <param name="serializer">The serializer.</param>
        protected MqttServiceRouteManagerBase(ISerializer<string> serializer)
        {
            _serializer = serializer;
        }

        /// <summary>
        /// Occurs when [created].
        /// </summary>
        public event EventHandler<MqttServiceRouteEventArgs> Created
        {
            add => _created += value;
            remove => _created -= value;
        }

        /// <summary>
        /// Occurs when [removed].
        /// </summary>
        public event EventHandler<MqttServiceRouteEventArgs> Removed
        {
            add => _removed += value;
            remove => _removed -= value;
        }

        /// <summary>
        /// Occurs when [changed].
        /// </summary>
        public event EventHandler<MqttServiceRouteChangedEventArgs> Changed
        {
            add => _changed += value;
            remove => _changed -= value;
        }

        /// <summary>
        /// 清空所有的服务路由。
        /// </summary>
        /// <returns>一个任务。</returns>
        public abstract Task ClearAsync();

        /// <summary>
        /// Gets the routes asynchronous.
        /// </summary>
        /// <returns>Task&lt;IEnumerable&lt;MqttServiceRoute&gt;&gt;.</returns>
        public abstract Task<IEnumerable<MqttServiceRoute>> GetRoutesAsync();

        /// <summary>
        /// Remves the address asynchronous.
        /// </summary>
        /// <param name="addresses">The addresses.</param>
        /// <returns>Task.</returns>
        public abstract Task RemveAddressAsync(IEnumerable<AddressModel> addresses);

        /// <summary>
        /// Removes the by topic asynchronous.
        /// </summary>
        /// <param name="topic">The topic.</param>
        /// <param name="endpoint">The endpoint.</param>
        /// <returns>Task.</returns>
        public abstract Task RemoveByTopicAsync(string topic, IEnumerable<AddressModel> endpoint);


        /// <summary>
        /// 设置服务路由。
        /// </summary>
        /// <param name="routes">服务路由集合。</param>
        /// <returns>一个任务。</returns>
        /// <exception cref="ArgumentNullException">routes</exception>
        public virtual Task SetRoutesAsync(IEnumerable<MqttServiceRoute> routes)
        {
            if (routes == null)
            {
                throw new ArgumentNullException(nameof(routes));
            }

            var descriptors = routes.Where(route => route != null).Select(route => new MqttServiceDescriptor
            {
                AddressDescriptors = route.MqttEndpoint?.Select(address => new MqttEndpointDescriptor
                {
                    Type = address.GetType().FullName,
                    Value = _serializer.Serialize(address)
                }) ?? Enumerable.Empty<MqttEndpointDescriptor>(),
                MqttDescriptor = route.MqttDescriptor
            });
            return SetRoutesAsync(descriptors);
        }

        /// <summary>
        /// Sets the routes asynchronous.
        /// </summary>
        /// <param name="descriptors">The descriptors.</param>
        /// <returns>Task.</returns>
        protected abstract Task SetRoutesAsync(IEnumerable<MqttServiceDescriptor> descriptors);

        /// <summary>
        /// Called when [created].
        /// </summary>
        /// <param name="args">The arguments.</param>
        protected void OnCreated(params MqttServiceRouteEventArgs[] args)
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
        protected void OnChanged(params MqttServiceRouteChangedEventArgs[] args)
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
        protected void OnRemoved(params MqttServiceRouteEventArgs[] args)
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