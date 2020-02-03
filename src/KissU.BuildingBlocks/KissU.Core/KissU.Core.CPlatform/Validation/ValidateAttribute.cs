using System;

namespace KissU.Core.CPlatform.Validation
{
    /// <summary>
    /// 验证属性.
    /// Implements the <see cref="Attribute" />
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter)]
    public class ValidateAttribute : Attribute
    {
    }
}