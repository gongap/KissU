using System;
using System.Collections.Generic;
using Autofac;

namespace KissU.Core.CPlatform.Engines
{
    /// <summary>
    /// 服务引擎生成器
    /// </summary>
    public interface IServiceEngineBuilder
    {
        /// <summary>
        /// 构建.
        /// </summary>
        /// <param name="serviceContainer">The service container.</param>
        void Build(ContainerBuilder serviceContainer);

        /// <summary>
        /// 重新构建.
        /// </summary>
        /// <param name="serviceContainer">The service container.</param>
        /// <returns>System.Nullable&lt;ValueTuple&lt;List&lt;Type&gt;, IEnumerable&lt;System.String&gt;&gt;&gt;.</returns>
        ValueTuple<List<Type>, IEnumerable<string>>? ReBuild(ContainerBuilder serviceContainer);
    }
}
