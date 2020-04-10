using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace KissU.Surging.ProxyGenerator
{
    /// <summary>
    /// 一个抽象的服务代理生成器。
    /// </summary>
    public interface IServiceProxyGenerater : IDisposable
    {
        /// <summary>
        /// 生成服务代理。
        /// </summary>
        /// <param name="interfacTypes">需要被代理的接口类型。</param>
        /// <param name="namespaces">The namespaces.</param>
        /// <returns>服务代理实现。</returns>
        IEnumerable<Type> GenerateProxys(IEnumerable<Type> interfacTypes, IEnumerable<string> namespaces);

        /// <summary>
        /// 生成服务代理代码树。
        /// </summary>
        /// <param name="interfaceType">需要被代理的接口类型。</param>
        /// <param name="namespaces">The namespaces.</param>
        /// <returns>代码树。</returns>
        SyntaxTree GenerateProxyTree(Type interfaceType, IEnumerable<string> namespaces);
    }
}