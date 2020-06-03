using System;

namespace KissU.Validation
{
    /// <summary>
    /// 验证属性.
    /// Implements the <see cref="Attribute" />
    /// </summary>
    /// <seealso cref="Attribute" />
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter)]
    public class ValidateAttribute : Attribute
    {
    }
}