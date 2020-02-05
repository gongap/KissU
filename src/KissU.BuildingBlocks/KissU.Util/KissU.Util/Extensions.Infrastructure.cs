using System;
using System.Text;
using AspectCore.Configuration;
using Autofac;
using KissU.Util.Dependency;
using Microsoft.Extensions.DependencyInjection;
using IContainer = Autofac.IContainer;

namespace KissU.Util
{
    /// <summary>
    /// 系统扩展 - 基础设施
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 注册Util基础设施服务
        /// </summary>
        /// <param name="builder">容器生成器</param>
        /// <param name="configs">依赖配置</param>
        /// <returns>Autofac.IContainer.</returns>
        public static IContainer AddUtil(this ContainerBuilder builder, params IConfig[] configs)
        {
            return AddUtil(builder, new ServiceCollection(), configs);
        }

        /// <summary>
        /// 注册Util基础设施服务
        /// </summary>
        /// <param name="builder">容器生成器</param>
        /// <param name="services">服务集合</param>
        /// <param name="configs">依赖配置</param>
        /// <returns>Autofac.IContainer.</returns>
        public static IContainer AddUtil(this ContainerBuilder builder, IServiceCollection services,
            params IConfig[] configs)
        {
            return AddUtil(builder, services, null, configs);
        }

        /// <summary>
        /// 注册Util基础设施服务
        /// </summary>
        /// <param name="builder">容器生成器</param>
        /// <param name="services">服务集合</param>
        /// <param name="aopConfigAction">Aop配置操作</param>
        /// <param name="configs">依赖配置</param>
        /// <returns>Autofac.IContainer.</returns>
        public static IContainer AddUtil(this ContainerBuilder builder, IServiceCollection services,
            Action<IAspectConfiguration> aopConfigAction, params IConfig[] configs)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            services.AddLogging();
            return Bootstrapper.Run(builder, services, configs, aopConfigAction);
        }
    }
}