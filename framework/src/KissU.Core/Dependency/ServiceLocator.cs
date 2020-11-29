using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace KissU.Dependency
{
    /// <summary>
    /// 服务定位器.
    /// </summary>
    public class ServiceLocator
    {
        /// <summary>
        /// 当前容器.
        /// </summary>
        public static ILifetimeScope Current { get; private set; }

        public static void Register(IServiceProvider serviceProvider)
        {
            if (serviceProvider is AutofacServiceProvider autofacServiceProvider)
            {
                Current = autofacServiceProvider.LifetimeScope;
            }
        }

        public static void Register(ILifetimeScope container)
        {
            Current = container;
        }

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
        /// 确定指定服务在上下文中是否可用.
        /// </summary>
        /// <typeparam name="T">服务类型</typeparam>
        /// <returns><c>true</c> if this instance is registered; otherwise, <c>false</c>.</returns>
        public static bool IsRegistered<T>()
        {
            return Current.IsRegistered<T>();
        }

        /// <summary>
        /// 确定指定服务在上下文中是否可用.
        /// </summary>
        /// <typeparam name="T">服务类型</typeparam>
        /// <param name="key">The key.</param>
        /// <returns><c>true</c> if the specified key is registered; otherwise, <c>false</c>.</returns>
        public static bool IsRegistered<T>(string key)
        {
            return Current.IsRegisteredWithKey<T>(key);
        }

        /// <summary>
        /// 确定指定服务在上下文中是否可用.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if the specified type is registered; otherwise, <c>false</c>.</returns>
        public static bool IsRegistered(Type type)
        {
            return Current.IsRegistered(type);
        }

        /// <summary>
        /// 确定指定服务在上下文中是否可用.
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