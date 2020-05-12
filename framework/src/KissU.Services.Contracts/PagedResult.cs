using System.Collections.Generic;
using System.Runtime.Serialization;

namespace KissU.Services.Contracts
{
    [DataContract]
    public class PagedResult<T> : ListResult<T>
    {
        [DataMember]
        public long TotalCount { get; set; }
    }
}