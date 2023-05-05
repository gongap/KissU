﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using KissU.Address;
using KissU.CPlatform.Routing;

namespace KissU.CPlatform.Runtime.Client.HealthChecks.Implementation
{
    /// <summary>
    /// 默认健康检查服务(每10秒会检查一次服务状态，在构造函数中添加服务管理事件)
    /// </summary>
    public class DefaultHealthCheckService : IHealthCheckService, IDisposable
    {
        private readonly ConcurrentDictionary<ValueTuple<string, int>, MonitorEntry> _dictionary =
            new ConcurrentDictionary<ValueTuple<string, int>, MonitorEntry>();

        private readonly IServiceRouteManager _serviceRouteManager;
        private readonly int _timeout = 3000;
        private readonly Timer _timer;
        private EventHandler<HealthCheckEventArgs> _changed;
        private EventHandler<HealthCheckEventArgs> _removed;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultHealthCheckService" /> class.
        /// 默认心跳检查服务(每10秒会检查一次服务状态，在构造函数中添加服务管理事件)
        /// </summary>
        /// <param name="serviceRouteManager">The service route manager.</param>
        public DefaultHealthCheckService(IServiceRouteManager serviceRouteManager)
        {
            var timeSpan = TimeSpan.FromSeconds(10);

            _serviceRouteManager = serviceRouteManager;

            // 建立计时器
            _timer = new Timer(
                async s =>
                {
                    // 检查服务是否可用
                    await Check(_dictionary.ToArray().Select(i => i.Value), _timeout);

                    // 移除不可用的服务地址
                    RemoveUnhealthyAddress(_dictionary.ToArray().Select(i => i.Value) .Where(m => m.UnhealthyTimes >= 6));
                },
                null,
                timeSpan,
                timeSpan);

            // 去除监控。
            serviceRouteManager.Removed += (s, e) => { Remove(e.Route.Address); };

            // 重新监控。
            serviceRouteManager.Created += async (s, e) =>
            {
                var keys = e.Route.Address.Select(address =>
                {
                    var ipAddress = address as IpAddressModel;
                    return new ValueTuple<string, int>(ipAddress.Ip, ipAddress.Port);
                });
                await Check(_dictionary.Where(i => keys.Contains(i.Key)).Select(i => i.Value), _timeout);
            };

            // 重新监控。
            serviceRouteManager.Changed += async (s, e) =>
            {
                var keys = e.Route.Address.Select(address =>
                {
                    var ipAddress = address as IpAddressModel;
                    return new ValueTuple<string, int>(ipAddress.Ip, ipAddress.Port);
                });
                await Check(_dictionary.Where(i => keys.Contains(i.Key)).Select(i => i.Value), _timeout);
            };
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _timer.Dispose();
        }

        /// <summary>
        /// Occurs when [removed].
        /// </summary>
        public event EventHandler<HealthCheckEventArgs> Removed
        {
            add => _removed += value;
            remove => _removed -= value;
        }

        /// <summary>
        /// Occurs when [changed].
        /// </summary>
        public event EventHandler<HealthCheckEventArgs> Changed
        {
            add => _changed += value;
            remove => _changed -= value;
        }

        /// <summary>
        /// 监控一个地址。
        /// </summary>
        /// <param name="address">地址模型。</param>
        public void Monitor(AddressModel address)
        {
            var ipAddress = address as IpAddressModel;
            _dictionary.GetOrAdd(new ValueTuple<string, int>(ipAddress.Ip, ipAddress.Port),
                k => new MonitorEntry(address));
        }

        /// <summary>
        /// 判断一个地址是否健康。
        /// </summary>
        /// <param name="address">地址模型。</param>
        /// <returns>健康返回true，否则返回false。</returns>
        public async ValueTask<bool> IsHealth(AddressModel address, int? timeout = null)
        {
            var ipAddress = address as IpAddressModel;
            MonitorEntry entry;
            var isHealth =
                !_dictionary.TryGetValue(new ValueTuple<string, int>(ipAddress.Ip, ipAddress.Port), out entry)
                    ? await Check(address, timeout ?? _timeout)
                    : entry.Health;
            OnChanged(new HealthCheckEventArgs(address, isHealth));
            return isHealth;
        }

        /// <summary>
        /// 标记一个地址为失败的。
        /// </summary>
        /// <param name="address">地址模型。</param>
        /// <returns>一个任务。</returns>
        public Task MarkFailure(AddressModel address, bool forceRemove = false)
        {
            if (forceRemove)
            {
                var ipAddress = address as IpAddressModel;
                _serviceRouteManager.RemveAddressAsync(new[]{address}).Wait();
                _dictionary.TryRemove(new ValueTuple<string, int>(ipAddress.Ip, ipAddress.Port), out var value);
                OnRemoved(new HealthCheckEventArgs(ipAddress));
            }

            return Task.Run(() =>
            {
                var ipAddress = address as IpAddressModel;
                var entry = _dictionary.GetOrAdd(new ValueTuple<string, int>(ipAddress.Ip, ipAddress.Port),
                    k => new MonitorEntry(address, false));
                entry.Health = false;
                entry.UnhealthyTimes++;
            });
        }

        /// <summary>
        /// Called when [removed].
        /// </summary>
        /// <param name="args">The arguments.</param>
        protected void OnRemoved(params HealthCheckEventArgs[] args)
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

        /// <summary>
        /// Called when [changed].
        /// </summary>
        /// <param name="args">The arguments.</param>
        protected void OnChanged(params HealthCheckEventArgs[] args)
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

        private void Remove(IEnumerable<AddressModel> addressModels)
        {
            if (addressModels!=null && addressModels.Any())
            {
                foreach (var addressModel in addressModels)
                {
                    MonitorEntry value;
                    var ipAddress = addressModel as IpAddressModel;
                    _dictionary.TryRemove(new ValueTuple<string, int>(ipAddress.Ip, ipAddress.Port), out value);
                }
            }
        }

        private void RemoveUnhealthyAddress(IEnumerable<MonitorEntry> monitorEntry)
        {
            if (monitorEntry.Any())
            {
                var addresses = monitorEntry.Select(p =>
                {
                    var ipEndPoint = p.EndPoint as IPEndPoint;
                    return new IpAddressModel(ipEndPoint.Address.ToString(), ipEndPoint.Port);
                }).ToList();
                _serviceRouteManager.RemveAddressAsync(addresses).Wait();
                addresses.ForEach(p =>
                {
                    var ipAddress = p;
                    _dictionary.TryRemove(new ValueTuple<string, int>(ipAddress.Ip, ipAddress.Port), out var value);
                });
                OnRemoved(addresses.Select(p => new HealthCheckEventArgs(p)).ToArray());
            }
        }

        private static async Task<bool> Check(AddressModel address, int timeout)
        {
            var isHealth = false;
            var tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(TimeSpan.FromMilliseconds(timeout));
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)  {SendTimeout = timeout})
            {
                try
                {
                    await socket.ConnectAsync(address.CreateEndPoint(),tokenSource.Token);
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
                var tokenSource = new CancellationTokenSource();
                tokenSource.CancelAfter(TimeSpan.FromMilliseconds(timeout));
                using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                    {SendTimeout = timeout})
                {
                    try
                    {
                        await socket.ConnectAsync(entry.EndPoint,tokenSource.Token);
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

        /// <summary>
        /// Monitor Entry.
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
    }
}