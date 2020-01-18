using System;
using System.Reflection;
using System.Runtime.ExceptionServices;
using Autofac;

namespace KissU.Core.ServiceHosting.Startup.Implementation
{
    /// <summary>
    /// 基于约定的启动
    /// </summary>
    public class ConventionBasedStartup : IStartup
    {
        /// <summary>
        /// The methods
        /// </summary>
        private readonly StartupMethods _methods;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="methods">启动方法</param>
        public ConventionBasedStartup(StartupMethods methods)
        {
            _methods = methods;
        }

        /// <summary>
        /// 配置应用
        /// </summary>
        /// <param name="app">容器</param>
        public void Configure(IContainer app)
        {
            try
            {
                _methods.ConfigureDelegate(app);
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
        /// <param name="services">容器构建器</param>
        /// <returns>容器</returns>
        public IContainer ConfigureServices(ContainerBuilder services)
        {
            try
            {
                return _methods.ConfigureServicesDelegate(services);
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
