using System;
using System.Linq;

namespace KissU.Abp
{
    public class AbpExceptionToErrorInfoConverter : Exceptions.Handling.IExceptionToErrorInfoConverter
    {
        private readonly Volo.Abp.AspNetCore.ExceptionHandling.IExceptionToErrorInfoConverter _errorInfoConverter;

        /// <summary>
        /// Initializes a new instance of the <see cref="AbpExceptionToErrorInfoConverter"/> class.
        /// </summary>
        /// <param name="errorInfoConverter">The error information converter.</param>
        public AbpExceptionToErrorInfoConverter(Volo.Abp.AspNetCore.ExceptionHandling.IExceptionToErrorInfoConverter errorInfoConverter)
        {
            _errorInfoConverter = errorInfoConverter;
        }

        /// <summary>
        /// Converter method.
        /// </summary>
        /// <param name="exception">The exception</param>
        /// <param name="includeSensitiveDetails">Should include sensitive details to the error info?</param>
        /// <returns>Error info or null</returns>
        public Exceptions.RemoteServiceErrorInfo Convert(Exception exception, bool includeSensitiveDetails)
        {
            var errorInfo = _errorInfoConverter.Convert(exception, includeSensitiveDetails);
            return new Exceptions.RemoteServiceErrorInfo(errorInfo.Message, errorInfo.Details, errorInfo.Code)
            {
                ValidationErrors = errorInfo.ValidationErrors?.Select(x => new Exceptions.RemoteServiceValidationErrorInfo(x.Message, x.Members)).ToArray(),
            };
        }
    }
}