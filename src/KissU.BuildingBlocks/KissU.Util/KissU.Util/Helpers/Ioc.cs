using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using KissU.Util.Dependency;
using Microsoft.Extensions.DependencyInjection;
using KissU.Util.Dependency;
using IContainer = KissU.Util.Dependency.IContainer;

namespace KissU.Util.Helpers
{
    /// <summary>
    /// 容器
    /// </summary>
    public static class Ioc
    {
        /// <summary>
        /// 默认容器
        /// </summary>
        internal static readonly Container DefaultContainer = new Container();

        /// <summary>
        /// 创建集合
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">服务名称</param>
        public static List<T> CreateList<T>(string name = null)
        {
            return DefaultContainer.CreateList<T>(name);
        }

        /// <summary>
        /// 创建集合
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="type">对象类型</param>
        /// <param name="name">服务名称</param>
        public static List<T> CreateList<T>(Type type, string name = null)
        {
            return ((IEnumerable<T>)DefaultContainer.CreateList(type, name)).ToList();
        }

        /// <summary>
        /// 创建实例
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">服务名称</param>
        public static T Create<T>(string name = null)
        {
            return DefaultContainer.Create<T>(name);
        }

        /// <summary>
        /// 创建实例
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="type">对象类型</param>
        /// <param name="name">服务名称</param>
        public static T Create<T>(Type type, string name = null)
        {
            return (T)DefaultContainer.Create(type, name);
        }

        /// <summary>
        /// 作用域开始
        /// </summary>
        public static IScope BeginScope()
        {
            return DefaultContainer.BeginScope();
        }

        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="configs">依赖配置</param>
        public static Autofac.IContainer Register(params IConfig[] configs)
        {
            return DefaultContainer.Register(null, null, b => b.EnableAop(), configs);
        }

        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="builder">容器生成器</param>
        /// <param name="configs">依赖配置</param>
        public static Autofac.IContainer Register(ContainerBuilder builder, params IConfig[] configs)
        {
            return DefaultContainer.Register(builder, null, b => b.EnableAop(), configs);
        }

        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="builder">容器生成器</param>
        /// <param name="services">服务集合</param>
        /// <param name="configs">依赖配置</param>
        public static Autofac.IContainer Register(ContainerBuilder builder, IServiceCollection services, params IConfig[] configs)
        {
            return DefaultContainer.Register(builder, services, b => b.EnableAop(), configs);
        }

        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="container">容器</param>
        public static void Register(Autofac.IContainer container)
        {
            DefaultContainer.Register(container);
        }

        /// <summary>
        /// 释放容器
        /// </summary>
        public static void Dispose()
        {
            DefaultContainer.Dispose();
        }
    }
}
