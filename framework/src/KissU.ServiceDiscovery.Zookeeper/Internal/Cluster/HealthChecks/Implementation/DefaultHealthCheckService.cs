using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using KissU.Address;

namespace KissU.ServiceDiscovery.Zookeeper.Internal.Cluster.HealthChecks.Implementation
{
    /// <summary>
    /// DefaultHealthCheckService.
    /// Implements the <see cref="IHealthCheckService" />
    /// </summary>
    /// <seealso cref="IHealthCheckService" />
    public class DefaultHealthCheckService : IHealthCheckService
    {
        private readonly ConcurrentDictionary<ValueTuple<string, int>, MonitorEntry> _dictionary =
            new ConcurrentDictionary<ValueTuple<string, int>, MonitorEntry>();

        private readonly int _timeout = 30000;
        private readonly Timer _timer;

        #region Help Class

        /// <summary>
        /// MonitorEntry.
        /// </summary>
        protected class MonitorEntry
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="MonitorEntry" /> class.
            /// </summary>
            /// <param name="addressModel">The address model.</param>
            /// <param name="health">if set to <c>true</c> [health].</param>
            public MonitorEntry(AddressModel addressModel, bool health = true)
            {
                EndPoint = addressModel.CreateEndPoint();
                Health = health;
            }

            /// <summary>
            /// Gets or sets the unhealthy times.
            /// </summary>
            public int UnhealthyTimes { get; set; }

            /// <summary>
            /// Gets or sets the end point.
            /// </summary>
            public EndPoint EndPoint { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="MonitorEntry" /> is health.
            /// </summary>
            public bool Health { get; set; }
        }

        #endregion Help Class

        #region Implementation of IHealthCheckService

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultHealthCheckService" /> class.
        /// </summary>
        public DefaultHealthCheckService()
        {
            var timeSpan = TimeSpan.FromSeconds(60);

            _timer = new Timer(async s => { await Check(_dictionary.ToArray().Select(i => i.Value), _timeout); }, null,
                timeSpan, timeSpan);
        }

        /// <summary>
        /// Determines whether the specified address is health.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns>ValueTask&lt;System.Boolean&gt;.</returns>
        public async ValueTask<bool> IsHealth(AddressModel address)
        {
            var ipAddress = address as IpAddressModel;
            MonitorEntry entry;
            var isHealth =
                !_dictionary.TryGetValue(new ValueTuple<string, int>(ipAddress.Ip, ipAddress.Port), out entry)
                    ? await Check(address, _timeout)
                    : entry.Health;
            return isHealth;
        }

        /// <summary>
        /// Monitors the specified address.
        /// </summary>
        /// <param name="address">The address.</param>
        public void Monitor(AddressModel address)
        {
            var ipAddress = address as IpAddressModel;
            _dictionary.GetOrAdd(new ValueTuple<string, int>(ipAddress.Ip, ipAddress.Port),
                k => new MonitorEntry(address));
        }

        #region Implementation of IDisposable

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            _timer.Dispose();
        }

        #endregion

        #endregion Implementation of IDisposable

        #region Private Method

        private static async Task<bool> Check(AddressModel address, int timeout)
        {
            var isHealth = false;
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                {SendTimeout = timeout})
            {
                try
                {
                    await socket.ConnectAsync(address.CreateEndPoint());
                    isHealth = true;
                }
                catch
                {
                }

                return isHealth;
            }
        }

        private static async Task Check(IEnumerable<MonitorEntry> entrys, int timeout)
        {
            foreach (var entry in entrys)
            {
                using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                    {SendTimeout = timeout})
                {
                    try
                    {
                        await socket.ConnectAsync(entry.EndPoint);
                        entry.UnhealthyTimes = 0;
                        entry.Health = true;
                    }
                    catch
                    {
                        entry.UnhealthyTimes++;
                        entry.Health = false;
                    }
                }
            }
        }

        #endregion Private Method
    }
}