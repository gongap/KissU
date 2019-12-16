using Autofac;

namespace KissU.Core.CPlatform.Module
{
    /// <summary>
    /// 容器构建器包装
    /// </summary>
    public class ContainerBuilderWrapper
    {
        /// <summary>
        /// 容器构建器
        /// </summary>
        public ContainerBuilder ContainerBuilder { get; private set; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="builder">容器构建器</param>
        public ContainerBuilderWrapper(ContainerBuilder builder)
        {
            ContainerBuilder = builder;
        }

        /// <summary>
        /// 构建容器
        /// </summary>
        /// <returns></returns>
        public IContainer Build()
        {
            return ContainerBuilder.Build();
        }
    }
}
