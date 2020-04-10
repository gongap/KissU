using System;
using System.Linq;
using System.Reflection;
using Autofac;

namespace KissU.Surging.ServiceHosting.Internal.Implementation
{
    /// <summary>
    /// 服务配置构建器
    /// </summary>
    public class ConfigureServicesBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigureServicesBuilder" /> class.
        /// 初始化
        /// </summary>
        /// <param name="configureServices">服务配置方法</param>
        public ConfigureServicesBuilder(MethodInfo configureServices)
        {
            MethodInfo = configureServices;
        }

        /// <summary>
        /// 方法
        /// </summary>
        public MethodInfo MethodInfo { get; }

        /// <summary>
        /// 构建
        /// </summary>
        /// <param name="instance">实例</param>
        /// <returns>构建委托</returns>
        public Func<ContainerBuilder, IContainer> Build(object instance)
        {
            return services => Invoke(instance, services);
        }

        /// <summary>
        /// 调用
        /// </summary>
        /// <param name="instance">实例</param>
        /// <param name="services">服务构建器</param>
        /// <returns>容器</returns>
        private IContainer Invoke(object instance, ContainerBuilder services)
        {
            if (MethodInfo == null)
            {
                return null;
            }

            // 只支持ContainerBuilder参数
            var parameters = MethodInfo.GetParameters();
            if (parameters.Length > 1 ||
                parameters.Any(p => p.ParameterType != typeof(ContainerBuilder)))
            {
                throw new InvalidOperationException("ConfigureServices方法必须是无参数或只有一个参数为ContainerBuilder类型");
            }

            var arguments = new object[MethodInfo.GetParameters().Length];

            if (parameters.Length > 0)
            {
                arguments[0] = services;
            }

            return MethodInfo.Invoke(instance, arguments) as IContainer;
        }
    }
}