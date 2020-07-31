using Autofac;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Modularity
{
    /// <summary>
    /// 服务构建器
    /// </summary>
    public interface IServiceBuilder
    {
        /// <summary>
        /// 服务集合
        /// </summary>
        ContainerBuilder ContainerBuilder { get; set; }

        /// <summary>
        /// 服务集合
        /// </summary>
        IServiceCollection Services { get; set; }
    }
}