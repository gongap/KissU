using Autofac;

namespace KissU.Modularity
{
    /// <summary>
    /// 服务构建器
    /// </summary>
    public interface IServiceBuilder
    {
        /// <summary>
        /// 容器构建器
        /// </summary>
        ContainerBuilder ContainerBuilder { get; set; }
    }
}