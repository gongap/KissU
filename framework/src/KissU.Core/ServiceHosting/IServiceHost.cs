using System;
using Autofac;

namespace KissU.ServiceHosting
{
    /// <summary>
    /// 服务主机
    /// </summary>
    public interface IServiceHost : IDisposable
    {
        /// <summary>
        /// 运行
        /// </summary>
        /// <returns>An IDisposable that ends the logical operation scope on dispose.</returns>
        IDisposable Run();

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns>容器</returns>
        IContainer Initialize();
    }
}