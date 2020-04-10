using System;
using Autofac;

namespace KissU.Core.Dependency
{
    /// <summary>
    /// 作用域
    /// </summary>
    internal class Scope : IScope
    {
        /// <summary>
        /// autofac作用域
        /// </summary>
        private readonly ILifetimeScope _scope;

        /// <summary>
        /// 初始化作用域
        /// </summary>
        /// <param name="scope">autofac作用域</param>
        public Scope(ILifetimeScope scope)
        {
            _scope = scope;
        }

        /// <summary>
        /// 创建实例
        /// </summary>
        /// <typeparam name="T">实例类型</typeparam>
        /// <returns>T.</returns>
        public T Create<T>()
        {
            return _scope.Resolve<T>();
        }

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <returns>System.Object.</returns>
        public object Create(Type type)
        {
            return _scope.Resolve(type);
        }

        /// <summary>
        /// 释放对象
        /// </summary>
        public void Dispose()
        {
            _scope.Dispose();
        }
    }
}