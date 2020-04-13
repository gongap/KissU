using System;
using Newtonsoft.Json.Linq;

namespace KissU.Core.Helpers.Utilities
{
    /// <summary>
    /// 公共类型.
    /// </summary>
    public static class UtilityType
    {
        /// <summary>
        /// json对象类型
        /// </summary>
        public static Type JObjectType => typeof(JObject);

        /// <summary>
        /// json数组类型
        /// </summary>
        public static Type JArrayType => typeof(JArray);

        /// <summary>
        /// 对象类型
        /// </summary>
        public static Type ObjectType => typeof(object);

        /// <summary>
        /// 可转换类型
        /// </summary>
        public static Type ConvertibleType => typeof(IConvertible);
    }
}