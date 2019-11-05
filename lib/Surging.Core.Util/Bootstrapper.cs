using System;
using System.Collections.Generic;
using System.Reflection;
using AspectCore.Configuration;
using Autofac;
using Util.Dependency;
using Util.Events.Handlers;
using Util.Reflections;

namespace Surging.Core.Util
{
    /// <summary>
    /// 依赖引导器
    /// </summary>
    public class Bootstrapper
    {
        /// <summary>
        /// 依赖配置
        /// </summary>
        private readonly IConfig[] _configs;
        /// <summary>
        /// 类型查找器
        /// </summary>
        private readonly IFind _finder;
        /// <summary>
        /// 程序集列表
        /// </summary>
        private List<Assembly> _assemblies;
        /// <summary>
        /// 容器生成器
        /// </summary>
        private ContainerBuilder _builder;
        /// <summary>
        /// Aop配置操作
        /// </summary>
        private readonly Action<IAspectConfiguration> _aopConfigAction;

        /// <summary>
        /// 初始化依赖引导器
        /// </summary>
        /// <param name="configs">依赖配置</param>
        /// <param name="aopConfigAction">Aop配置操作</param>
        /// <param name="finder">类型查找器</param>
        public Bootstrapper(IConfig[] configs, Action<IAspectConfiguration> aopConfigAction, IFind finder)
        {
            _configs = configs;
            _aopConfigAction = aopConfigAction;
            _finder = finder ?? new Finder();
        }

        /// <summary>
        /// 启动引导
        /// </summary>
        /// <param name="builder">容器生成器</param>
        /// <param name="configs">依赖配置</param>
        /// <param name="aopConfigAction">Aop配置操作</param>
        /// <param name="finder">类型查找器</param>
        public static void Run(ContainerBuilder builder, IConfig[] configs = null, Action<IAspectConfiguration> aopConfigAction = null, IFind finder = null)
        {
            new Bootstrapper(configs, aopConfigAction, finder).Bootstrap(builder);
        }

        /// <summary>
        /// 引导
        /// </summary>
        public void Bootstrap(ContainerBuilder builder)
        {
            _assemblies = _finder.GetAssemblies();
            RegisterServices(builder);
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
            EnableAop();
            RegisterFinder();
        }

        /// <summary>
        /// 启用Aop
        /// </summary>
        private void EnableAop()
        {
            //_builder.EnableAop(_aopConfigAction);
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
                    (filter, criteria) => filter.IsGenericType && ((Type)criteria).IsAssignableFrom(filter.GetGenericTypeDefinition())
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
        }

        /// <summary>
        /// 注册单例依赖
        /// </summary>
        private void RegisterSingletonDependency()
        {
            _builder.RegisterTypes(GetTypes<ISingletonDependency>()).AsImplementedInterfaces().PropertiesAutowired().SingleInstance();
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
            _builder.RegisterTypes(GetTypes<IScopeDependency>()).AsImplementedInterfaces().PropertiesAutowired().InstancePerLifetimeScope();
        }

        /// <summary>
        /// 注册瞬态依赖
        /// </summary>
        private void RegisterTransientDependency()
        {
            _builder.RegisterTypes(GetTypes<ITransientDependency>()).AsImplementedInterfaces().PropertiesAutowired().InstancePerDependency();
        }
    }
}
