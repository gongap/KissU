using System;
using System.Collections.Generic;

namespace KissU.Modules.Blogging.Application.Contracts.Tagging.Dtos
{
    public class GetTagListInput
    {
        public IEnumerable<Guid> Ids { get; set; }
    }
}