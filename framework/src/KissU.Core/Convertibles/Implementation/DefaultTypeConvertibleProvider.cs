using System;
using System.Collections.Generic;
using System.Reflection;
using KissU.Core.Helpers.Utilities;
using KissU.Core.Serialization;

namespace KissU.Core.Convertibles.Implementation
{
    /// <summary>
    /// 一个默认的类型转换提供程序。
    /// </summary>
    public class DefaultTypeConvertibleProvider : ITypeConvertibleProvider
    {
        /// <summary>
        /// The serializer
        /// </summary>
        private readonly ISerializer<object> _serializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultTypeConvertibleProvider" /> class.
        /// </summary>
        /// <param name="serializer">The serializer.</param>
        public DefaultTypeConvertibleProvider(ISerializer<object> serializer)
        {
            _serializer = serializer;
        }

        /// <summary>
        /// 获取类型转换器。
        /// </summary>
        /// <returns>类型转换器集合。</returns>
        public IEnumerable<TypeConvertDelegate> GetConverters()
        {
            //// 枚举转换器
            yield return EnumTypeConvert;
            //// 简单类型
            yield return SimpleTypeConvert;
            //// guid转换器
            yield return GuidTypeConvert;
            //// 复杂类型
            yield return ComplexTypeConvert;
        }

        /// <summary>
        /// 枚举类型转换器
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="conversionType">Type of the conversion.</param>
        /// <returns>System.Object.</returns>
        private static object EnumTypeConvert(object instance, Type conversionType)
        {
            if (instance == null || !conversionType.GetTypeInfo().IsEnum)
            {
                return null;
            }

            return Enum.Parse(conversionType, instance.ToString());
        }

        /// <summary>
        /// 简单类型转换器
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="conversionType">Type of the conversion.</param>
        /// <returns>System.Object.</returns>
        private static object SimpleTypeConvert(object instance, Type conversionType)
        {
            if (instance is IConvertible && UtilityType.ConvertibleType.GetTypeInfo().IsAssignableFrom(conversionType))
            {
                return Convert.ChangeType(instance, conversionType);
            }

            return null;
        }

        /// <summary>
        /// 复杂类型转换器
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="conversionType">Type of the conversion.</param>
        /// <returns>System.Object.</returns>
        private object ComplexTypeConvert(object instance, Type conversionType)
        {
            try
            {
                return _serializer.Deserialize(instance, conversionType);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// GUID转换器
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="conversionType">Type of the conversion.</param>
        /// <returns>System.Object.</returns>
        private static object GuidTypeConvert(object instance, Type conversionType)
        {
            if (instance == null || conversionType != typeof(Guid))
            {
                return null;
            }

            Guid.TryParse(instance.ToString(), out var result);
            return result;
        }
    }
}