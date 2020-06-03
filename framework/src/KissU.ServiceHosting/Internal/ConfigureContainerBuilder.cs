using System;
using System.Reflection;

namespace KissU.Surging.ServiceHosting.Internal
{
    /// <summary>
    /// 容器配置构建器
    /// </summary>
    public class ConfigureContainerBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigureContainerBuilder" /> class.
        /// 初始化
        /// </summary>
        /// <param name="configureContainerMethod">配置容器方法</param>
        public ConfigureContainerBuilder(MethodInfo configureContainerMethod)
        {
            MethodInfo = configureContainerMethod;
        }

        /// <summary>
        /// 方法
        /// </summary>
        public MethodInfo MethodInfo { get; }

        /// <summary>
        /// 构建
        /// </summary>
        /// <param name="instance">实例</param>
        /// <returns>实例委托</returns>
        public Action<object> Build(object instance)
        {
            return container => Invoke(instance, container);
        }

        /// <summary>
        /// 获取容器类型
        /// </summary>
        /// <returns>Type.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public Type GetContainerType()
        {
            var parameters = MethodInfo.GetParameters();
            if (parameters.Length != 1)
            {
                throw new InvalidOperationException($"{MethodInfo.Name} 方法必须有一个参数");
            }

            return parameters[0].ParameterType;
        }

        /// <summary>
        /// 调用
        /// </summary>
        /// <param name="instance">实例</param>
        /// <param name="container">容器</param>
        private void Invoke(object instance, object container)
        {
            if (MethodInfo == null)
            {
                return;
            }

            var arguments = new object[1] {container};
            MethodInfo.Invoke(instance, arguments);
        }
    }
}