using System.Collections.Generic;
using System.Linq;

namespace KissU.Surging.CPlatform.Cache
{
    /// <summary>
    /// 服务缓存
    /// </summary>
    public class ServiceCache
    {
        /// <summary>
        /// 服务缓存可用地址。
        /// </summary>
        public IEnumerable<CacheEndpoint> CacheEndpoint { get; set; }

        /// <summary>
        /// 服务缓存描述符。
        /// </summary>
        public CacheDescriptor CacheDescriptor { get; set; }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object  is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            var model = obj as ServiceCache;
            if (model == null)
            {
                return false;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            if (model.CacheDescriptor != CacheDescriptor)
            {
                return false;
            }

            return model.CacheEndpoint.Count() == CacheEndpoint.Count() &&
                   model.CacheEndpoint.All(addressModel => CacheEndpoint.Contains(addressModel));
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
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
        public static bool operator ==(ServiceCache model1, ServiceCache model2)
        {
            return Equals(model1, model2);
        }

        /// <summary>
        /// Implements the != operator.
        /// </summary>
        /// <param name="model1">The model1.</param>
        /// <param name="model2">The model2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(ServiceCache model1, ServiceCache model2)
        {
            return !Equals(model1, model2);
        }
    }
}