using Autofac;

namespace KissU.Core.Module
{
    /// <summary>
    /// 服务构建器
    /// </summary>
    public interface IServiceBuilder
    {
        /// <summary>
        /// 服务集合
        /// </summary>
        ContainerBuilder Services { get; set; }
    }
}