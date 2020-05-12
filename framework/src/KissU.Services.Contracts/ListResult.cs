using System.Collections.Generic;
using System.Runtime.Serialization;

namespace KissU.Services.Contracts
{
    [DataContract]
    public class ListResult<T>
    {
        [DataMember]
        public List<T> Items { get; set; }
    }
}