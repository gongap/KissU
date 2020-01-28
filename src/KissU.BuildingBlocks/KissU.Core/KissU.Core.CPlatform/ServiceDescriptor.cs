using System;
using System.Collections.Generic;
using System.Linq;

namespace KissU.Core.CPlatform
{
    /// <summary>
    /// 服务描述符。
    /// </summary>
    [Serializable]
    public class ServiceDescriptor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceDescriptor"/> class.
        /// 初始化一个新的服务描述符。
        /// </summary>
        public ServiceDescriptor()
        {
            Metadatas = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// 服务Id。
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }

        /// <summary>
        /// 访问的令牌
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 路由
        /// </summary>
        /// <value>The route path.</value>
        public string RoutePath { get; set; }

        /// <summary>
        /// 元数据。
        /// </summary>
        /// <value>The metadatas.</value>
        public IDictionary<string, object> Metadatas { get; set; }

        /// <summary>
        /// 获取一个元数据。
        /// </summary>
        /// <typeparam name="T">元数据类型。</typeparam>
        /// <param name="name">元数据名称。</param>
        /// <param name="def">如果指定名称的元数据不存在则返回这个参数。</param>
        /// <returns>元数据值。</returns>
        public T GetMetadata<T>(string name, T def = default(T))
        {
            if (!Metadatas.ContainsKey(name))
            {
                return def;
            }

            return (T)Metadatas[name];
        }

        /// <summary>
        /// 确定指定对象是否等于当前对象.
        /// </summary>
        /// <param name="obj">与当前对象进行比较的对象.</param>
        /// <returns>如果指定对象等于当前对象，则返回true；否则返回true。否则为假。</returns>
        public override bool Equals(object obj)
        {
            var model = obj as ServiceDescriptor;
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
        /// 用作默认哈希函数。
        /// </summary>
        /// <returns>当前对象的哈希码.</returns>
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
        public static bool operator ==(ServiceDescriptor model1, ServiceDescriptor model2)
        {
            return Equals(model1, model2);
        }

        /// <summary>
        /// Implements the != operator.
        /// </summary>
        /// <param name="model1">The model1.</param>
        /// <param name="model2">The model2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(ServiceDescriptor model1, ServiceDescriptor model2)
        {
            return !Equals(model1, model2);
        }
    }
}