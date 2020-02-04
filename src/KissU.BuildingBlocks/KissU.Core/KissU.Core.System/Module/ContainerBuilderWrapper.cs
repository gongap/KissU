using Autofac;

namespace KissU.Core.System.Module
{
    /// <summary>
    /// ContainerBuilderWrapper.
    /// </summary>
    public class ContainerBuilderWrapper
    {
        /// <summary>
        /// 初始化一个新的 <see cref="ContainerBuilderWrapper" /> 类实例。
        /// </summary>
        /// <param name="builder">容器构建对象。</param>
        /// <remarks>
        ///     <para>创建：范亮</para>
        ///     <para>日期：2015/12/4</para>
        /// </remarks>
        public ContainerBuilderWrapper(ContainerBuilder builder)
        {
            ContainerBuilder = builder;
        }

        /// <summary>
        /// 获取内部容器构建对象。
        /// </summary>
        /// <remarks>
        ///     <para>创建：范亮</para>
        ///     <para>日期：2015/12/4</para>
        /// </remarks>
        public ContainerBuilder ContainerBuilder { get; }

        /// <summary>
        /// 构建容器。
        /// </summary>
        /// <returns>IContainer.</returns>
        /// <remarks>
        ///     <para>创建：范亮</para>
        ///     <para>日期：2015/12/4</para>
        /// </remarks>
        public IContainer Build()
        {
            return ContainerBuilder.Build();
        }
    }
}