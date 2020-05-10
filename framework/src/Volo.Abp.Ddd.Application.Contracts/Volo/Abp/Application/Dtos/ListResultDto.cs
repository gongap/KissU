using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Volo.Abp.Application.Dtos
{
    [Serializable]
    [DataContract]
    public class ListResultDto<T> : IListResult<T>
    {
        /// <inheritdoc />
        [DataMember]
        public IReadOnlyList<T> Items
        {
            get { return _items ?? (_items = new List<T>()); }
            set { _items = value; }
        }
        private IReadOnlyList<T> _items;

        /// <summary>
        /// Creates a new <see cref="ListResultDto{T}"/> object.
        /// </summary>
        public ListResultDto()
        {
            
        }

        /// <summary>
        /// Creates a new <see cref="ListResultDto{T}"/> object.
        /// </summary>
        /// <param name="items">List of items</param>
        public ListResultDto(IReadOnlyList<T> items)
        {
            Items = items;
        }
    }
}