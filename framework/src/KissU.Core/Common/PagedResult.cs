using System.Collections.Generic;
using System.Runtime.Serialization;

namespace KissU.Common
{
    [DataContract]
    public class PagedResult<T> : ListResult<T>
    {
        [DataMember]
        public long TotalCount { get; set; }

        public PagedResult(long totalCount, IReadOnlyList<T> items) : base(items)
        {
            TotalCount = totalCount;
        }
    }
}