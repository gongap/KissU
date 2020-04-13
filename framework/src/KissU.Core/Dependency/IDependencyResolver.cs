﻿using System;
using System.Collections.Generic;

namespace KissU.Core.Dependency
{
    /// <summary>
    /// 注入IOC容器接口
    /// </summary>
    public interface IDependencyResolver
    {
        /// <summary>
        /// 通过KEY和TYPE获取实例对象
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="key">键</param>
        /// <returns>返回实例对象</returns>
        object GetService(Type type, object key);

        /// <summary>
        /// 通过KEY和TYPE获取实例对象集合
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="key">键</param>
        /// <returns>返回实例对象</returns>
        IEnumerable<object> GetServices(Type type, object key);
    }
}