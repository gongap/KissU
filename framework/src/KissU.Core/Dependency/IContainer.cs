﻿using System;
using System.Collections.Generic;
using Autofac;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Core.Dependency
{
    /// <summary>
    /// 容器
    /// </summary>
    public interface IContainer : IDisposable
    {
        /// <summary>
        /// 创建集合
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">服务名称</param>
        /// <returns>List&lt;T&gt;.</returns>
        List<T> CreateList<T>(string name = null);

        /// <summary>
        /// 创建集合
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="name">服务名称</param>
        /// <returns>System.Object.</returns>
        object CreateList(Type type, string name = null);

        /// <summary>
        /// 创建实例
        /// </summary>
        /// <typeparam name="T">实例类型</typeparam>
        /// <param name="name">服务名称</param>
        /// <returns>T.</returns>
        T Create<T>(string name = null);

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="name">服务名称</param>
        /// <returns>System.Object.</returns>
        object Create(Type type, string name = null);

        /// <summary>
        /// 作用域开始
        /// </summary>
        /// <returns>IScope.</returns>
        IScope BeginScope();

        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="configs">依赖配置</param>
        void Register(params IConfig[] configs);

        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="builder">容器生成器</param>
        /// <param name="configs">依赖配置</param>
        void Register(ContainerBuilder builder, params IConfig[] configs);

        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="builder">容器生成器</param>
        /// <param name="services">服务集合</param>
        /// <param name="configs">依赖配置</param>
        void Register(ContainerBuilder builder, IServiceCollection services, params IConfig[] configs);

        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="builder">容器生成器</param>
        /// <param name="services">服务集合</param>
        /// <param name="actionBefore">注册前操作</param>
        /// <param name="configs">依赖配置</param>
        void Register(ContainerBuilder builder, IServiceCollection services, Action<ContainerBuilder> actionBefore, params IConfig[] configs);

        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="container">容器</param>
        void Register(Autofac.IContainer container);
    }
}