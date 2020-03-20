﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AspectCore.Configuration;
using Autofac;
using KissU.Core.Events.Handlers;
using KissU.Core.Helpers;
using KissU.Core.Reflections;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Core.Dependency
{
    /// <summary>
    /// 依赖引导器
    /// </summary>
    public class Bootstrapper
    {
        /// <summary>
        /// Aop配置操作
        /// </summary>
        private readonly Action<IAspectConfiguration> _aopConfigAction;

        /// <summary>
        /// 依赖配置
        /// </summary>
        private readonly IConfig[] _configs;

        /// <summary>
        /// 类型查找器
        /// </summary>
        private readonly IFind _finder;

        /// <summary>
        /// 服务集合
        /// </summary>
        private readonly IServiceCollection _services;

        /// <summary>
        /// 程序集列表
        /// </summary>
        private List<Assembly> _assemblies;

        /// <summary>
        /// 容器生成器
        /// </summary>
        private ContainerBuilder _builder;

        /// <summary>
        /// 初始化依赖引导器
        /// </summary>
        /// <param name="builder">容器生成器</param>
        /// <param name="services">服务集合</param>
        /// <param name="configs">依赖配置</param>
        /// <param name="aopConfigAction">Aop配置操作</param>
        /// <param name="finder">类型查找器</param>
        public Bootstrapper(ContainerBuilder builder, IServiceCollection services, IConfig[] configs,
            Action<IAspectConfiguration> aopConfigAction, IFind finder)
        {
            _builder = builder ?? new ContainerBuilder();
            _services = services ?? new ServiceCollection();
            _configs = configs;
            _aopConfigAction = aopConfigAction;
            _finder = finder ?? new Finder();
        }

        /// <summary>
        /// 启动引导
        /// </summary>
        /// <param name="builder">容器生成器</param>
        /// <param name="services">服务集合</param>
        /// <param name="configs">依赖配置</param>
        /// <param name="aopConfigAction">Aop配置操作</param>
        /// <param name="finder">类型查找器</param>
        /// <returns>Autofac.IContainer.</returns>
        public static Autofac.IContainer Run(ContainerBuilder builder = null, IServiceCollection services = null,
            IConfig[] configs = null, Action<IAspectConfiguration> aopConfigAction = null, IFind finder = null)
        {
            return new Bootstrapper(builder, services, configs, aopConfigAction, finder).Bootstrap();
        }

        /// <summary>
        /// 引导
        /// </summary>
        /// <returns>Autofac.IContainer.</returns>
        public Autofac.IContainer Bootstrap()
        {
            _assemblies = _finder.GetAssemblies();
            return Helpers.Ioc.DefaultContainer.Register(_builder, _services, RegisterServices, _configs);
        }

        /// <summary>
        /// 注册服务集合
        /// </summary>
        private void RegisterServices(ContainerBuilder builder)
        {
            _builder = builder;
            RegisterInfrastracture();
            RegisterEventHandlers();
            RegisterDependency();
        }

        /// <summary>
        /// 注册基础设施
        /// </summary>
        private void RegisterInfrastracture()
        {
            // EnableAop();
            RegisterFinder();
        }

        /// <summary>
        /// 启用Aop
        /// </summary>
        private void EnableAop()
        {
            _builder.EnableAop(_aopConfigAction);
        }

        /// <summary>
        /// 注册类型查找器
        /// </summary>
        private void RegisterFinder()
        {
            _builder.AddSingleton(_finder);
        }

        /// <summary>
        /// 注册事件处理器
        /// </summary>
        private void RegisterEventHandlers()
        {
            RegisterEventHandlers(typeof(IEventHandler<>));
        }

        /// <summary>
        /// 注册事件处理器
        /// </summary>
        private void RegisterEventHandlers(Type handlerType)
        {
            var handlerTypes = GetTypes(handlerType);
            foreach (var handler in handlerTypes)
            {
                _builder.RegisterType(handler).As(handler.FindInterfaces(
                    (filter, criteria) => filter.IsGenericType &&
                                          ((Type) criteria).IsAssignableFrom(filter.GetGenericTypeDefinition())
                    , handlerType
                )).InstancePerLifetimeScope();
            }
        }

        /// <summary>
        /// 获取类型集合
        /// </summary>
        private Type[] GetTypes(Type type)
        {
            return _finder.Find(type, _assemblies).ToArray();
        }

        /// <summary>
        /// 查找并注册依赖
        /// </summary>
        private void RegisterDependency()
        {
            RegisterSingletonDependency();
            RegisterScopeDependency();
            RegisterTransientDependency();
            ResolveDependencyRegistrar();
        }

        /// <summary>
        /// 注册单例依赖
        /// </summary>
        private void RegisterSingletonDependency()
        {
            _builder.RegisterTypes(GetTypes<ISingletonDependency>()).AsImplementedInterfaces().PropertiesAutowired()
                .SingleInstance();
        }

        /// <summary>
        /// 获取类型集合
        /// </summary>
        private Type[] GetTypes<T>()
        {
            return _finder.Find<T>(_assemblies).ToArray();
        }

        /// <summary>
        /// 注册作用域依赖
        /// </summary>
        private void RegisterScopeDependency()
        {
            _builder.RegisterTypes(GetTypes<IScopeDependency>()).AsImplementedInterfaces().PropertiesAutowired()
                .InstancePerLifetimeScope();
        }

        /// <summary>
        /// 注册瞬态依赖
        /// </summary>
        private void RegisterTransientDependency()
        {
            _builder.RegisterTypes(GetTypes<ITransientDependency>()).AsImplementedInterfaces().PropertiesAutowired()
                .InstancePerDependency();
        }

        /// <summary>
        /// 解析依赖注册器
        /// </summary>
        private void ResolveDependencyRegistrar()
        {
            var types = GetTypes<IDependencyRegistrar>();
            types.Select(type => Reflection.CreateInstance<IDependencyRegistrar>(type)).ToList()
                .ForEach(t => t.Register(_services));
        }
    }
}