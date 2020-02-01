using System;
using Autofac;

namespace KissU.Core.CPlatform.Utilities
{
    /// <summary>
    /// 服务定位器.
    /// </summary>
    public class ServiceLocator
    {
        /// <summary>
        /// 当前容器.
        /// </summary>
        public static IContainer Current { get; set; }

        /// <summary>
        /// 获得服务.
        /// </summary>
        /// <typeparam name="T">服务类型</typeparam>
        /// <returns>T.</returns>
        public static T GetService<T>()
        {
            return Current.Resolve<T>();
        }

        /// <summary>
        /// Determines whether this instance is registered.
        /// </summary>
        /// <typeparam name="T">服务类型</typeparam>
        /// <returns><c>true</c> if this instance is registered; otherwise, <c>false</c>.</returns>
        public static bool IsRegistered<T>()
        {
            return Current.IsRegistered<T>();
        }

        /// <summary>
        /// Determines whether the specified key is registered.
        /// </summary>
        /// <typeparam name="T">服务类型</typeparam>
        /// <param name="key">The key.</param>
        /// <returns><c>true</c> if the specified key is registered; otherwise, <c>false</c>.</returns>
        public static bool IsRegistered<T>(string key)
        {
            return Current.IsRegisteredWithKey<T>(key);
        }

        /// <summary>
        /// Determines whether the specified type is registered.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if the specified type is registered; otherwise, <c>false</c>.</returns>
        public static bool IsRegistered(Type type)
        {
            return Current.IsRegistered(type);
        }

        /// <summary>
        /// Determines whether [is registered with key] [the specified key].
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if [is registered with key] [the specified key]; otherwise, <c>false</c>.</returns>
        public static bool IsRegisteredWithKey(string key, Type type)
        {
            return Current.IsRegisteredWithKey(key, type);
        }

        /// <summary>
        /// 获得服务.
        /// </summary>
        /// <typeparam name="T">服务类型</typeparam>
        /// <param name="key">The key.</param>
        /// <returns>T.</returns>
        public static T GetService<T>(string key)
        {
            return Current.ResolveKeyed<T>(key);
        }

        /// <summary>
        /// 获得服务.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>System.Object.</returns>
        public static object GetService(Type type)
        {
            return Current.Resolve(type);
        }

        /// <summary>
        /// 获得服务.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="type">The type.</param>
        /// <returns>System.Object.</returns>
        public static object GetService(string key, Type type)
        {
            return Current.ResolveKeyed(key, type);
        }
    }
}