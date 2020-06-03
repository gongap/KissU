using System.Reflection;

namespace KissU.Validation
{
    /// <summary>
    /// 验证处理器
    /// </summary>
    public interface IValidationProcessor
    {
        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="parameterInfo">参数信息</param>
        /// <param name="value">值</param>
        void Validate(ParameterInfo parameterInfo, object value);
    }
}