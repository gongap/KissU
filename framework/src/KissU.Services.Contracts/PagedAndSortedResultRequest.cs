using System.Runtime.Serialization;
using Volo.Abp.Application.Dtos;

namespace KissU.Services.Contracts
{
    [DataContract]
    public class PagedAndSortedResultRequest : PagedResultRequest
    {
        [DataMember]
        public virtual string Sorting { get; set; }
    }
}