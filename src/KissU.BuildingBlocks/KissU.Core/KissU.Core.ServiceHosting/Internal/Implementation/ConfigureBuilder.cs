using System;
using System.Reflection;
using Autofac;

namespace KissU.Core.ServiceHosting.Internal.Implementation
{
    /// <summary>
    /// 配置构建器
    /// </summary>
    public class ConfigureBuilder
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="configure">方法信息</param>
        public ConfigureBuilder(MethodInfo configure)
        {
            MethodInfo = configure;
        }

        /// <summary>
        /// 方法信息
        /// </summary>
        public MethodInfo MethodInfo { get; }

        /// <summary>
        /// 构建
        /// </summary>
        /// <param name="instance">实例</param>
        /// <returns>容器</returns>
        public Action<IContainer> Build(object instance)
        {
            return builder => Invoke(instance, builder);
        }

        /// <summary>
        /// 调用
        /// </summary>
        /// <param name="instance">实例</param>
        /// <param name="builder">容器</param>
        private void Invoke(object instance, IContainer builder)
        {
            using (var scope = builder.BeginLifetimeScope())
            {
                var parameterInfos = MethodInfo.GetParameters();
                var parameters = new object[parameterInfos.Length];
                for (var index = 0; index < parameterInfos.Length; index++)
                {
                    var parameterInfo = parameterInfos[index];
                    if (parameterInfo.ParameterType == typeof(IContainer))
                    {
                        parameters[index] = builder;
                    }
                    else
                    {
                        try
                        {
                            parameters[index] = scope.Resolve(parameterInfo.ParameterType);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(string.Format(
                                "无法解析的服务类型: '{0}'参数： '{1}' 方法： '{2}' 类型 '{3}'.",
                                parameterInfo.ParameterType.FullName,
                                parameterInfo.Name,
                                MethodInfo.Name,
                                MethodInfo.DeclaringType.FullName), ex);
                        }
                    }
                }

                MethodInfo.Invoke(instance, parameters);
            }
        }
    }
}
