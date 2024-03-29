﻿using System;
using System.Threading.Tasks;
using Autofac;
using KissU.CPlatform.Ioc;
using KissU.Dependency;
using KissU.DotNetty.Mqtt.Internal.Messages;
using KissU.ServiceProxy;

namespace KissU.DotNetty.Mqtt.Internal.Services
{
    /// <summary>
    /// MqttBehavior.
    /// Implements the <see cref="ServiceBase" />
    /// </summary>
    /// <seealso cref="ServiceBase" />
    public abstract class MqttBehavior : ServiceBase
    {
        /// <summary>
        /// Publishes the specified device identifier.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="willMessage">The will message.</param>
        public async Task Publish(string deviceId, MqttWillMessage willMessage)
        {
            await GetService<IChannelService>().Publish(deviceId, willMessage);
        }

        /// <summary>
        /// Remotes the publish.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="willMessage">The will message.</param>
        public async Task RemotePublish(string deviceId, MqttWillMessage willMessage)
        {
            await GetService<IChannelService>().RemotePublishMessage(deviceId, willMessage);
        }

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <typeparam name="T">服务类型</typeparam>
        /// <param name="key">The key.</param>
        /// <returns>T.</returns>
        public override T GetService<T>(string key)
        {
            if (ServiceLocator.Current.IsRegisteredWithKey<T>(key))
                return base.GetService<T>(key);
            return ServiceLocator.GetService<IServiceProxyFactory>().CreateProxy<T>(key);
        }

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <typeparam name="T">服务类型</typeparam>
        /// <returns>T.</returns>
        public override T GetService<T>()
        {
            if (ServiceLocator.Current.IsRegistered<T>())
                return base.GetService<T>();
            return ServiceLocator.GetService<IServiceProxyFactory>().CreateProxy<T>();
        }

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>System.Object.</returns>
        public override object GetService(Type type)
        {
            if (ServiceLocator.Current.IsRegistered(type))
                return base.GetService(type);
            return ServiceLocator.GetService<IServiceProxyFactory>().CreateProxy(type);
        }

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="type">The type.</param>
        /// <returns>System.Object.</returns>
        public override object GetService(string key, Type type)
        {
            if (ServiceLocator.Current.IsRegisteredWithKey(key, type))
                return base.GetService(key, type);
            return ServiceLocator.GetService<IServiceProxyFactory>().CreateProxy(key, type);
        }

        /// <summary>
        /// Gets the device is onine.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public async Task<bool> GetDeviceIsOnine(string deviceId)
        {
            return await GetService<IChannelService>().GetDeviceIsOnine(deviceId);
        }

        /// <summary>
        /// Authorizeds the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public abstract Task<bool> AuthorizedAsync(string username, string password);
    }
}