using System;
using System.Text;
using AspectCore.Configuration;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using KissU.Util.Dependency;
using KissU.Util.Helpers;
using KissU.Util.Sessions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Util
{
    /// <summary>
    /// 系统扩展 - 基础设施
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 注册容器
        /// </summary>
        /// <param name="builder">应用程序生成器</param>
        public static void UseUtil(this IApplicationBuilder builder)
        {
            Ioc.Register(builder.ApplicationServices.GetAutofacRoot());
        }

        /// <summary>
        /// 注册Util基础设施服务
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="configs">依赖配置</param>
        public static IServiceProvider AddUtil(this IServiceCollection services, params IConfig[] configs)
        {
            return AddUtil(services, null, configs);
        }

        /// <summary>
        /// 注册Util基础设施服务
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="aopConfigAction">Aop配置操作</param>
        /// <param name="configs">依赖配置</param>
        public static IServiceProvider AddUtil(this IServiceCollection services, Action<IAspectConfiguration> aopConfigAction, params IConfig[] configs)
        {
            services.AddHttpContextAccessor();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            services.AddSingleton<ISession, Session>();
            return Bootstrapper.Run(services, configs, aopConfigAction);
        }

        /// <summary>
        /// 注册Util基础设施服务
        /// </summary>
        /// <param name="builder">容器生成器</param>
        /// <param name="configs">依赖配置</param>
        public static void AddUtil(this ContainerBuilder builder, params IConfig[] configs)
        {
            AddUtil(builder, new ServiceCollection(), configs);
        }

        /// <summary>
        /// 注册Util基础设施服务
        /// </summary>
        /// <param name="builder">容器生成器</param>
        /// <param name="services">服务集合</param>
        /// <param name="configs">依赖配置</param>
        public static void AddUtil(this ContainerBuilder builder, IServiceCollection services, params IConfig[] configs)
        {
            AddUtil(builder, services, null, configs);
        }

        /// <summary>
        /// 注册Util基础设施服务
        /// </summary>
        /// <param name="builder">容器生成器</param>
        /// <param name="services">服务集合</param>
        /// <param name="aopConfigAction">Aop配置操作</param>
        /// <param name="configs">依赖配置</param>
        public static void AddUtil(this ContainerBuilder builder, IServiceCollection services, Action<IAspectConfiguration> aopConfigAction, params IConfig[] configs)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            services.AddHttpContextAccessor();
            services.AddLogging();
            services.AddSingleton<ISession, Session>();
            Bootstrapper.Run(builder, services, configs, aopConfigAction);
        }
    }
}
