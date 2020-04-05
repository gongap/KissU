using System;
using KissU.Core.Utilities;

namespace KissU.Surging.Caching
{
    /// <summary>
    /// CacheContainer.
    /// </summary>
    public class CacheContainer
    {
        /// <summary>
        /// Gets the instances.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">The name.</param>
        /// <returns>T.</returns>
        public static T GetInstances<T>(string name) where T : class
        {
            var appConfig = AppConfig.DefaultInstance;
            return appConfig.GetContextInstance<T>(name);
        }

        /// <summary>
        /// Gets the instances.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>T.</returns>
        public static T GetInstances<T>() where T : class
        {
            var appConfig = AppConfig.DefaultInstance;
            return appConfig.GetContextInstance<T>();
        }

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">The name.</param>
        /// <returns>T.</returns>
        public static T GetService<T>(string name)
        {
            if (ServiceLocator.Current == null) return default;
            return ServiceLocator.GetService<T>(name);
        }

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>T.</returns>
        public static T GetService<T>()
        {
            if (ServiceLocator.Current == null) return default;
            return ServiceLocator.GetService<T>();
        }

        /// <summary>
        /// Determines whether this instance is registered.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns><c>true</c> if this instance is registered; otherwise, <c>false</c>.</returns>
        public static bool IsRegistered<T>()
        {
            return ServiceLocator.IsRegistered<T>();
        }

        /// <summary>
        /// Determines whether the specified key is registered.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns><c>true</c> if the specified key is registered; otherwise, <c>false</c>.</returns>
        public static bool IsRegistered<T>(string key)
        {
            return ServiceLocator.IsRegistered<T>(key);
        }

        /// <summary>
        /// Determines whether the specified type is registered.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if the specified type is registered; otherwise, <c>false</c>.</returns>
        public static bool IsRegistered(Type type)
        {
            return ServiceLocator.IsRegistered(type);
        }

        /// <summary>
        /// Determines whether [is registered with key] [the specified key].
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if [is registered with key] [the specified key]; otherwise, <c>false</c>.</returns>
        public static bool IsRegisteredWithKey(string key, Type type)
        {
            return ServiceLocator.IsRegisteredWithKey(key, type);
        }
    }
}