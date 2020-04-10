using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using KissU.Core.Convertibles;
using KissU.Core.Exceptions;
using KissU.Core.Utilities;

namespace KissU.Core.Validation.Implementation
{
    /// <summary>
    /// 默认验证处理器.
    /// Implements the <see cref="IValidationProcessor" />
    /// </summary>
    /// <seealso cref="IValidationProcessor" />
    public class DefaultValidationProcessor : IValidationProcessor
    {
        private readonly ITypeConvertibleService _typeConvertibleService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultValidationProcessor" /> class.
        /// </summary>
        /// <param name="typeConvertibleService">The type convertible service.</param>
        public DefaultValidationProcessor(ITypeConvertibleService typeConvertibleService)
        {
            _typeConvertibleService = typeConvertibleService;
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="parameterInfo">参数信息</param>
        /// <param name="value">值</param>
        /// <exception cref="ValidateException"></exception>
        /// <exception cref="ValidateException">校验异常</exception>
        public void Validate(ParameterInfo parameterInfo, object value)
        {
            Check.NotNull(parameterInfo, nameof(parameterInfo));
            if (value != null)
            {
                var parameterType = parameterInfo.ParameterType;
                var parameter = _typeConvertibleService.Convert(value, parameterType);
                var customAttributes = parameterInfo.GetCustomAttributes(true);
                var customValidAttributes = customAttributes
                    .Where(ca => ca.GetType() != typeof(ValidateAttribute))
                    .OfType<ValidationAttribute>()
                    .ToList();
                var validationContext = new ValidationContext(parameter);
                var validationResults = new List<ValidationResult>();
                var isObjValid = Validator.TryValidateObject(parameter, validationContext, validationResults, true);
                var isValueValid = Validator.TryValidateValue(parameter, validationContext, validationResults,
                    customValidAttributes);
                if (isObjValid && isValueValid)
                {
                    return;
                }

                throw new ValidateException(validationResults.Select(p => p.ErrorMessage).First());
            }
        }
    }
}