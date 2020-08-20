using System;
using KissU.Exceptions.Prompts;
using Volo.Abp.AspNetCore.ExceptionHandling;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Json;

namespace KissU.Abp.Business.Exceptions
{
    /// <summary>
    /// 异常提示
    /// </summary>
    public class AbpExceptionPrompt : IExceptionPrompt, ISingletonDependency
    {
        private readonly IExceptionToErrorInfoConverter _errorInfoConverter;
        private readonly IJsonSerializer _jsonSerializer;

        public AbpExceptionPrompt(IExceptionToErrorInfoConverter errorInfoConverter, IJsonSerializer jsonSerializer)
        {
            _errorInfoConverter = errorInfoConverter;
            _jsonSerializer = jsonSerializer;
        }

        /// <summary>
        /// 获取异常提示
        /// </summary>
        /// <param name="exception">异常</param>
        /// <returns>System.String.</returns>
        public string GetPrompt(Exception exception)
        {
            var errorInfo = _errorInfoConverter.Convert(exception);
            return _jsonSerializer.Serialize(errorInfo);
        }
    }
}