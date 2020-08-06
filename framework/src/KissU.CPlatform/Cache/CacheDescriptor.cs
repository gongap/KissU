using System;
using System.Collections.Generic;
using System.Linq;

namespace KissU.CPlatform.Cache
{
    /// <summary>
    /// 服务描述符。
    /// </summary>
    [Serializable]
    public class CacheDescriptor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CacheDescriptor" /> class.
        /// 初始化一个新的服务描述符。
        /// </summary>
        public CacheDescriptor()
        {
            Metadatas = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// 缓存Id。
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 前缀
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 元数据。
        /// </summary>
        public IDictionary<string, object> Metadatas { get; set; }

        /// <summary>
        /// 获取一个元数据。
        /// </summary>
        /// <typeparam name="T">元数据类型。</typeparam>
        /// <param name="name">元数据名称。</param>
        /// <param name="def">如果指定名称的元数据不存在则返回这个参数。</param>
        /// <returns>元数据值。</returns>
        public T GetMetadata<T>(string name, T def = default)
        {
            if (!Metadatas.ContainsKey(name))
            {
                return def;
            }

            return (T) Metadatas[name];
        }

        /// <summary>
        /// Determines whether the specified <see cref="object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            var model = obj as CacheDescriptor;
            if (model == null)
            {
                return false;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            if (model.Id != Id)
            {
                return false;
            }

            return model.Metadatas.Count == Metadatas.Count && model.Metadatas.All(metadata =>
            {
                object value;
                if (!Metadatas.TryGetValue(metadata.Key, out value))
                {
                    return false;
                }

                if (metadata.Value == null && value == null)
                {
                    return true;
                }

                if (metadata.Value == null || value == null)
                {
                    return false;
                }

                return metadata.Value.Equals(value);
            });
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// Implements the == operator.
        /// </summary>
        /// <param name="model1">The model1.</param>
        /// <param name="model2">The model2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(CacheDescriptor model1, CacheDescriptor model2)
        {
            return Equals(model1, model2);
        }

        /// <summary>
        /// Implements the != operator.
        /// </summary>
        /// <param name="model1">The model1.</param>
        /// <param name="model2">The model2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(CacheDescriptor model1, CacheDescriptor model2)
        {
            return !Equals(model1, model2);
        }
    }
}