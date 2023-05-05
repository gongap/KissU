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

        /// <summary>
        /// 当前容器.
        /// </summary>
        public static IServiceProvider ServiceProvider { get; private set; }

        public static void Register(IServiceProvider serviceProvider)
        {
            if (serviceProvider is AutofacServiceProvider autofacServiceProvider)
            {
                Current = autofacServiceProvider.LifetimeScope;
            }

            ServiceProvider = serviceProvider;
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