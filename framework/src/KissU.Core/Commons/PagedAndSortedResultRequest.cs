using System.Runtime.Serialization;

namespace KissU.Core.Commons
{
    [DataContract]
    public class PagedAndSortedResultRequest : PagedResultRequest
    {
        [DataMember]
        public virtual string Sorting { get; set; }
    }
}