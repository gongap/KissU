using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using KissU.Util.Helpers;
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
        private ILifetimeScope _container;

        /// <summary>
        /// 创建集合
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">服务名称</param>
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
        public T Create<T>(string name = null)
        {
            return (T)Create(typeof(T), name);
        }

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="name">服务名称</param>
        public object Create(Type type, string name = null)
        {
            return Web.HttpContext?.RequestServices != null ? GetServiceFromHttpContext(type, name) : GetService(type, name);
        }

        /// <summary>
        /// 从HttpContext获取服务
        /// </summary>
        private object GetServiceFromHttpContext(Type type, string name)
        {
            var serviceProvider = Web.HttpContext.RequestServices;
            if (name == null)
                return serviceProvider.GetService(type);
            var context = serviceProvider.GetService<IComponentContext>();
            return context.ResolveNamed(name, type);
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
        public IScope BeginScope()
        {
            return new Scope(_container.BeginLifetimeScope());
        }

        /// <summary>
        /// 注册容器
        /// </summary>
        /// <param name="container">容器</param>
        public void Register(ILifetimeScope container)
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