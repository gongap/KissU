using System;
using Newtonsoft.Json.Linq;

namespace KissU.Helpers
{
    /// <summary>
    /// 公共类型.
    /// </summary>
    public static class TypeHelper
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

        /// <summary>
        /// 获取类型
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <returns>Type.</returns>
        public static Type GetType<T>() => GetType(typeof(T));

        /// <summary>
        /// 获取类型
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>Type.</returns>
        public static Type GetType(Type type) => Nullable.GetUnderlyingType(type) ?? type;
    }
}