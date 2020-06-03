using System.Collections.Generic;
using System.Linq;
using KissU.Address;

namespace KissU.Surging.CPlatform.Routing
{
    /// <summary>
    /// 服务路由。
    /// </summary>
    public class ServiceRoute
    {
        /// <summary>
        /// 服务可用地址。
        /// </summary>
        public IEnumerable<AddressModel> Address { get; set; }

        /// <summary>
        /// 服务描述符。
        /// </summary>
        public ServiceDescriptor ServiceDescriptor { get; set; }

        /// <summary>
        /// Determines whether the specified <see cref="object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>
        /// .
        /// </returns>
        public override bool Equals(object obj)
        {
            var model = obj as ServiceRoute;
            if (model == null)
            {
                return false;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            if (model.ServiceDescriptor != ServiceDescriptor)
            {
                return false;
            }

            return model.Address.Count() == Address.Count() &&
                   model.Address.All(addressModel => Address.Contains(addressModel));
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
        public static bool operator ==(ServiceRoute model1, ServiceRoute model2)
        {
            return Equals(model1, model2);
        }

        /// <summary>
        /// Implements the != operator.
        /// </summary>
        /// <param name="model1">The model1.</param>
        /// <param name="model2">The model2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(ServiceRoute model1, ServiceRoute model2)
        {
            return !Equals(model1, model2);
        }
    }
}