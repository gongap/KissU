using System;
using System.Text;
using AspectCore.Configuration;
using AspectCore.Extensions.Autofac;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Util.Dependency;

namespace KissU
{
    /// <summary>
    /// 系统扩展 - 基础设施
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 注册Util基础设施服务
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="builder">容器生成器</param>
        /// <param name="configs">依赖配置</param>
        public static void AddUtil(this IServiceCollection services, ContainerBuilder builder, params IConfig[] configs)
        {
           AddUtil(services, builder, null, configs);
        }

        /// <summary>
        /// 注册Util基础设施服务
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="builder">容器生成器</param>
        /// <param name="aopConfigAction">Aop配置操作</param>
        /// <param name="configs">依赖配置</param>
        public static void AddUtil(this IServiceCollection services, ContainerBuilder builder, Action<IAspectConfiguration> aopConfigAction = null, params IConfig[] configs)
        {
            services.AddHttpContextAccessor();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Dependency.Bootstrapper.Run(services, builder, configs, aopConfigAction);
        }
    }
}
