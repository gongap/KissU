using System.Runtime.Serialization;

namespace KissU.Core.Commons
{
    [DataContract]
    public class PagedResult<T> : ListResult<T>
    {
        [DataMember]
        public long TotalCount { get; set; }
    }
}