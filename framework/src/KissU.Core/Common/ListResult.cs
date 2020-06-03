using System.Collections.Generic;
using System.Runtime.Serialization;

namespace KissU.Common
{
    [DataContract]
    public class ListResult<T>
    {
        [DataMember]
        public IReadOnlyList<T> Items { get; set; }

        public ListResult(IReadOnlyList<T> items)
        {
            Items = items;
        }
    }
}