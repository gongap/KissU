using System;
using System.Reflection;
using System.Runtime.ExceptionServices;
using Autofac;
using KissU.Core.Hosting;

namespace KissU.ServiceHosting.Startup
{
    /// <summary>
    /// 基于约定的启动类
    /// </summary>
    public class ConventionBasedStartup : IStartup
    {
        /// <summary>
        /// 启动方法
        /// </summary>
        private readonly StartupMethods _methods;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConventionBasedStartup" /> class.
        /// 初始化
        /// </summary>
        /// <param name="methods">启动方法</param>
        public ConventionBasedStartup(StartupMethods methods)
        {
            _methods = methods;
        }

        /// <summary>
        /// 配置容器
        /// </summary>
        /// <param name="container">容器</param>
        public void Configure(IContainer container)
        {
            try
            {
                _methods.ConfigureDelegate(container);
            }
            catch (Exception ex)
            {
                if (ex is TargetInvocationException)
                {
                    ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                }

                throw;
            }
        }

        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="builder">容器构建器</param>
        /// <returns>容器</returns>
        public IContainer ConfigureContainer(ContainerBuilder builder)
        {
            try
            {
                return _methods.ConfigureContainerDelegate(builder);
            }
            catch (Exception ex)
            {
                if (ex is TargetInvocationException)
                {
                    ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                }

                throw;
            }
        }
    }
}