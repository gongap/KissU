using System;
using Autofac;

namespace KissU.Core.ServiceHosting.Internal
{
    /// <summary>
    /// 服务主机
    /// </summary>
    public interface IServiceHost : IDisposable
    {
        /// <summary>
        /// 运行
        /// </summary>
        /// <returns></returns>
        IDisposable Run();

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns>容器</returns>
        IContainer Initialize();
    }
}
