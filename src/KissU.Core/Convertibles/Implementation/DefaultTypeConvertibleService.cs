﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using KissU.Exceptions;
using Microsoft.Extensions.Logging;

namespace KissU.Convertibles.Implementation
{
    /// <summary>
    /// 一个默认的类型转换服务。
    /// </summary>
    public class DefaultTypeConvertibleService : ITypeConvertibleService
    {
        /// <summary>
        /// The converters
        /// </summary>
        private readonly IEnumerable<TypeConvertDelegate> _converters;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<DefaultTypeConvertibleService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultTypeConvertibleService" /> class.
        /// </summary>
        /// <param name="providers">The providers.</param>
        /// <param name="logger">The logger.</param>
        public DefaultTypeConvertibleService(IEnumerable<ITypeConvertibleProvider> providers,
            ILogger<DefaultTypeConvertibleService> logger)
        {
            _logger = logger;
            providers = providers.ToArray();
            if (providers.Any())
            {
                _logger.LogInformation($"发现了{providers.Count()}个类型转换提供程序：");
                foreach (var provider in providers)
                {
                    _logger.LogInformation(provider.ToString());
                }
            }

            _converters = providers.SelectMany(p => p.GetConverters()).ToArray();
        }

        /// <summary>
        /// 转换。
        /// </summary>
        /// <param name="instance">需要转换的实例。</param>
        /// <param name="conversionType">转换的类型。</param>
        /// <returns>转换之后的类型，如果无法转换则返回null。</returns>
        /// <exception cref="ArgumentNullException">instance</exception>
        /// <exception cref="ArgumentNullException">conversionType</exception>
        /// <exception cref="ArgumentNullException">instance</exception>
        /// <exception cref="ArgumentNullException">conversionType</exception>
        public object Convert(object instance, Type conversionType)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            if (conversionType == null)
            {
                throw new ArgumentNullException(nameof(conversionType));
            }

            if (conversionType.GetTypeInfo().IsInstanceOfType(instance))
            {
                return instance;
            }

            if (_logger.IsEnabled(LogLevel.Trace))
            {
                _logger.LogTrace($"准备将 {instance.GetType()} 转换为：{conversionType}。");
            }

            object result = null;
            foreach (var converter in _converters)
            {
                result = converter(instance, conversionType);
                if (result != null)
                {
                    break;
                }
            }

            if (result != null)
            {
                return result;
            }

            var exception = new CPlatformException($"无法将实例：{instance}转换为{conversionType}。");

            if (_logger.IsEnabled(LogLevel.Error))
            {
                _logger.LogError(exception, $"将 {instance.GetType()} 转换成 {conversionType} 时发生了错误。");
            }

            throw exception;
        }
    }
}