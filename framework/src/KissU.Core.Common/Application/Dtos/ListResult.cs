using System.Collections.Generic;
using System.Runtime.Serialization;

namespace KissU.Core.Common.Application.Dtos
{
    [DataContract]
    public class ListResult<T>
    {
        [DataMember]
        public List<T> Items { get; set; }
    }
}