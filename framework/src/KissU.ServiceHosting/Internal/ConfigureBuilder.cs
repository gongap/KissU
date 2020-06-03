using System;
using System.Reflection;
using Autofac;

namespace KissU.Surging.ServiceHosting.Internal
{
    /// <summary>
    /// 配置构建器
    /// </summary>
    public class ConfigureBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigureBuilder" /> class.
        /// 初始化
        /// </summary>
        /// <param name="methodInfo">配置方法</param>
        public ConfigureBuilder(MethodInfo methodInfo)
        {
            MethodInfo = methodInfo;
        }

        /// <summary>
        /// 方法
        /// </summary>
        public MethodInfo MethodInfo { get; }

        /// <summary>
        /// 构建
        /// </summary>
        /// <param name="instance">实例</param>
        /// <returns>容器</returns>
        public Action<IContainer> Build(object instance)
        {
            return container => Invoke(instance, container);
        }

        /// <summary>
        /// 调用
        /// </summary>
        /// <param name="instance">实例</param>
        /// <param name="container">容器</param>
        private void Invoke(object instance, IContainer container)
        {
            using var scope = container.BeginLifetimeScope();
            var parameterInfos = MethodInfo.GetParameters();
            var parameters = new object[parameterInfos.Length];
            for (var index = 0; index < parameterInfos.Length; index++)
            {
                var parameterInfo = parameterInfos[index];
                if (parameterInfo.ParameterType == typeof(IContainer))
                {
                    parameters[index] = container;
                }
                else
                {
                    try
                    {
                        parameters[index] = scope.Resolve(parameterInfo.ParameterType);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"无法解析的服务类型: '{parameterInfo.ParameterType.FullName}'参数： '{parameterInfo.Name}' 方法： '{MethodInfo.Name}' 类型 '{MethodInfo.DeclaringType?.FullName}'.", ex);
                    }
                }
            }

            MethodInfo.Invoke(instance, parameters);
        }
    }
}