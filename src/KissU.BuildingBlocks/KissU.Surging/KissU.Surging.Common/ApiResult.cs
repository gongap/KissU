using System.Runtime.Serialization;

namespace KissU.Surging.Common
{
    /// <summary>
    /// ApiResult.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract]
    public class ApiResult<T>
    {
        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        [DataMember]
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [DataMember]
        public T Value { get; set; }
    }
}