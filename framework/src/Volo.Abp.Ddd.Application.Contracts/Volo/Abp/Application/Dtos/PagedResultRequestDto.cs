using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Volo.Abp.Application.Dtos
{
    /// <summary>
    /// Simply implements <see cref="IPagedResultRequest"/>.
    /// </summary>
    [Serializable]
    [DataContract]
    public class PagedResultRequestDto : LimitedResultRequestDto, IPagedResultRequest
    {
        [DataMember]
        [Range(0, int.MaxValue)]
        public virtual int SkipCount { get; set; }
    }
}