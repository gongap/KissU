using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using KissU.Core.Helpers;
using KissU.Core.Properties;

namespace KissU.Core.Validations.Validators
{
    /// <summary>
    /// 身份证验证
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IdCardAttribute : ValidationAttribute
    {
        /// <summary>
        /// 格式化错误消息
        /// </summary>
        /// <param name="name">The name to include in the formatted message.</param>
        /// <returns>An instance of the formatted error message.</returns>
        public override string FormatErrorMessage(string name)
        {
            if (ErrorMessage == null && ErrorMessageResourceName == null)
                ErrorMessage = LibraryResource.InvalidIdCard;
            return string.Format(CultureInfo.CurrentCulture, ErrorMessageString);
        }

        /// <summary>
        /// 是否验证通过
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>ValidationResult.</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value.SafeString().IsEmpty())
                return ValidationResult.Success;
            if (Regex.IsMatch(value.SafeString(), ValidatePattern.IdCardPattern))
                return ValidationResult.Success;
            return new ValidationResult(FormatErrorMessage(string.Empty));
        }
    }
}