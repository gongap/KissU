using System.Collections.Generic;
using System.Linq;
using KissU.CPlatform.Address;

namespace KissU.CPlatform.Mqtt
{
    /// <summary>
    /// Mqtt服务路由.
    /// </summary>
    public class MqttServiceRoute
    {
        /// <summary>
        /// Mqtt服务可用地址。
        /// </summary>
        public IEnumerable<AddressModel> MqttEndpoint { get; set; }

        /// <summary>
        /// Mqtt服务描述符。
        /// </summary>
        public MqttDescriptor MqttDescriptor { get; set; }

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
            var model = obj as MqttServiceRoute;
            if (model == null)
            {
                return false;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            if (model.MqttDescriptor != MqttDescriptor)
            {
                return false;
            }

            return model.MqttEndpoint.Count() == MqttEndpoint.Count() &&
                   model.MqttEndpoint.All(addressModel => MqttEndpoint.Contains(addressModel));
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
        public static bool operator ==(MqttServiceRoute model1, MqttServiceRoute model2)
        {
            return Equals(model1, model2);
        }

        /// <summary>
        /// Implements the != operator.
        /// </summary>
        /// <param name="model1">The model1.</param>
        /// <param name="model2">The model2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(MqttServiceRoute model1, MqttServiceRoute model2)
        {
            return !Equals(model1, model2);
        }
    }
}