using System.Runtime.Serialization;

namespace KissU.Core.Common.Application.Dtos
{
    [DataContract]
    public class PagedResult<T> : ListResult<T>
    {
        [DataMember]
        public long TotalCount { get; set; }
    }
}