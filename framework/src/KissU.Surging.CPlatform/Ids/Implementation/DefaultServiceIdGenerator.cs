using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Logging;

namespace KissU.Surging.CPlatform.Ids.Implementation
{
    /// <summary>
    /// 一个默认的服务Id生成器。
    /// </summary>
    public class DefaultServiceIdGenerator : IServiceIdGenerator
    {
        private readonly ILogger<DefaultServiceIdGenerator> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultServiceIdGenerator" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public DefaultServiceIdGenerator(ILogger<DefaultServiceIdGenerator> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 生成一个服务Id。
        /// </summary>
        /// <param name="method">本地方法信息。</param>
        /// <returns>对应方法的唯一服务Id。</returns>
        /// <exception cref="ArgumentNullException">method</exception>
        /// <exception cref="ArgumentNullException">DeclaringType - 方法的定义类型不能为空。</exception>
        /// <exception cref="ArgumentNullException">method</exception>
        public string GenerateServiceId(MethodInfo method)
        {
            if (method == null)
            {
                throw new ArgumentNullException(nameof(method));
            }

            var type = method.DeclaringType;
            if (type == null)
            {
                throw new ArgumentNullException(nameof(method.DeclaringType), "方法的定义类型不能为空。");
            }

            var id = $"{type.FullName}.{method.Name}";
            var parameters = method.GetParameters();
            if (parameters.Any())
            {
                id += "_" + string.Join("_", parameters.Select(i => i.Name));
            }

            if (_logger.IsEnabled(LogLevel.Trace))
            {
                _logger.LogTrace($"为方法：{method}生成服务Id：{id}。");
            }

            return id;
        }
    }
}