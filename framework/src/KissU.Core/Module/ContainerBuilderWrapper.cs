using Autofac;

namespace KissU.Module
{
    /// <summary>
    /// 容器构建器包装
    /// </summary>
    public class ContainerBuilderWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerBuilderWrapper" /> class.
        /// </summary>
        /// <param name="builder">容器构建器</param>
        public ContainerBuilderWrapper(ContainerBuilder builder)
        {
            ContainerBuilder = builder;
        }

        /// <summary>
        /// 容器构建器
        /// </summary>
        public ContainerBuilder ContainerBuilder { get; }

        /// <summary>
        /// 构建容器
        /// </summary>
        /// <returns>IContainer.</returns>
        public IContainer Build()
        {
            return ContainerBuilder.Build();
        }
    }
}