using System;
using System.Runtime.Serialization;

namespace Volo.Abp.Application.Dtos
{
    /// <summary>
    /// Simply implements <see cref="IPagedAndSortedResultRequest"/>.
    /// </summary>
    [Serializable]
    [DataContract]
    public class PagedAndSortedResultRequestDto : PagedResultRequestDto, IPagedAndSortedResultRequest
    {
        [DataMember]
        public virtual string Sorting { get; set; }
    }
}