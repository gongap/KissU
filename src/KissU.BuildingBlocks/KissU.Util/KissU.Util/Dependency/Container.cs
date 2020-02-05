using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Util.Dependency
{
    /// <summary>
    /// Autofac对象容器
    /// </summary>
    internal class Container : IContainer
    {
        /// <summary>
        /// 容器
        /// </summary>
        private Autofac.IContainer _container;

        /// <summary>
        /// 创建集合
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">服务名称</param>
        /// <returns>List&lt;T&gt;.</returns>
        public List<T> CreateList<T>(string name = null)
        {
            var result = CreateList(typeof(T), name);
            if (result == null)
                return new List<T>();
            return ((IEnumerable<T>)result).ToList();
        }

        /// <summary>
        /// 创建集合
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="name">服务名称</param>
        /// <returns>System.Object.</returns>
        public object CreateList(Type type, string name = null)
        {
            Type serviceType = typeof(IEnumerable<>).MakeGenericType(type);
            return Create(serviceType, name);
        }

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">服务名称</param>
        /// <returns>T.</returns>
        public T Create<T>(string name = null)
        {
            return (T)Create(typeof(T), name);
        }

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="name">服务名称</param>
        /// <returns>System.Object.</returns>
        public object Create(Type type, string name = null)
        {
            return GetService(type, name);
        }

        /// <summary>
        /// 获取服务
        /// </summary>
        private object GetService(Type type, string name)
        {
            if (name == null)
                return _container.Resolve(type);
            return _container.ResolveNamed(name, type);
        }

        /// <summary>
        /// 作用域开始
        /// </summary>
        /// <returns>IScope.</returns>
        public IScope BeginScope()
        {
            return new Scope(_container.BeginLifetimeScope());
        }

        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="configs">依赖配置</param>
        /// <returns>Autofac.IContainer.</returns>
        public Autofac.IContainer Register(params IConfig[] configs)
        {
            return Register(null,  configs);
        }

        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="builder">容器生成器</param>
        /// <param name="configs">依赖配置</param>
        /// <returns>Autofac.IContainer.</returns>
        public Autofac.IContainer Register(ContainerBuilder builder, params IConfig[] configs)
        {
           return Register(builder, null, configs);
        }

        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="builder">容器生成器</param>
        /// <param name="services">服务集合</param>
        /// <param name="configs">依赖配置</param>
        /// <returns>Autofac.IContainer.</returns>
        public Autofac.IContainer Register(ContainerBuilder builder, IServiceCollection services, params IConfig[] configs)
        {
            return Register(builder, services, null, configs);
        }

        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="builder">容器生成器</param>
        /// <param name="services">服务集合</param>
        /// <param name="actionBefore">注册前操作</param>
        /// <param name="configs">依赖配置</param>
        /// <returns>Autofac.IContainer.</returns>
        public Autofac.IContainer Register(ContainerBuilder builder, IServiceCollection services, Action<ContainerBuilder> actionBefore, params IConfig[] configs)
        {
            builder = CreateBuilder(builder, services, actionBefore, configs);
            _container = builder.Build();
            return _container;
        }

        /// <summary>
        /// 创建容器生成器
        /// </summary>
        /// <param name="builder">容器生成器</param>
        /// <param name="services">服务集合</param>
        /// <param name="actionBefore">注册前执行的操作</param>
        /// <param name="configs">依赖配置</param>
        public ContainerBuilder CreateBuilder(ContainerBuilder builder, IServiceCollection services, Action<ContainerBuilder> actionBefore, params IConfig[] configs)
        {
            builder ??= new ContainerBuilder();
            actionBefore?.Invoke(builder);
            if (configs != null)
            {
                foreach (var config in configs)
                {
                    builder.RegisterModule(config);
                }
            }

            if (services != null)
            {
                builder.Populate(services);
            }

            return builder;
        }

        /// <summary>
        /// 注册容器
        /// </summary>
        /// <param name="container">容器</param>
        public void Register(Autofac.IContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// 释放容器
        /// </summary>
        public void Dispose()
        {
            _container.Dispose();
        }
    }
}