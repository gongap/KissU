using System.Runtime.Serialization;

namespace KissU.Core.Common.Application.Dtos
{
    [DataContract]
    public class PagedAndSortedResultRequest : PagedResultRequest
    {
        [DataMember]
        public virtual string Sorting { get; set; }
    }
}