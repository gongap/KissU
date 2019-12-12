using System.Runtime.Serialization;

namespace KissU.Core.Common
{
    [DataContract]
    public class ApiResult<T>
    {

        [DataMember]
        public int StatusCode { get; set; }

        [DataMember]
        public T Value { get; set; }
    }
}
