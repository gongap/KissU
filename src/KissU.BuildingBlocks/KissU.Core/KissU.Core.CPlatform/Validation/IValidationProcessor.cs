using System.Reflection;

namespace KissU.Core.CPlatform.Validation
{
    public interface IValidationProcessor
    {
        void Validate(ParameterInfo parameterInfo, object value);
    }
}