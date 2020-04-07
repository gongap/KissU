using System.Linq;
using KissU.Core.Exceptions;
using KissU.Core.Validations;

namespace KissU.Util.Ddd.Domain.Services
{
    /// <summary>
    /// 参数
    /// </summary>
    public abstract class ParameterBase : IValidation
    {
        /// <summary>
        /// 验证
        /// </summary>
        /// <returns>ValidationResultCollection.</returns>
        /// <exception cref="Warning"></exception>
        public virtual ValidationResultCollection Validate()
        {
            var result = DataAnnotationValidation.Validate(this);
            if (result.IsValid)
                return ValidationResultCollection.Success;
            throw new Warning(result.First().ErrorMessage);
        }
    }
}