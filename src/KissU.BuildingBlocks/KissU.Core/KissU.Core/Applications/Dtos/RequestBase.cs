using System.Linq;
using KissU.Util.Exceptions;
using KissU.Util.Validations;

namespace KissU.Util.Applications.Dtos
{
    /// <summary>
    /// 请求参数
    /// </summary>
    public abstract class RequestBase : IRequest
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