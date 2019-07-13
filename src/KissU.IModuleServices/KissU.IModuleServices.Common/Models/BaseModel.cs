using ProtoBuf;
using Surging.Core.System.Intercept;
using System;
using System.Collections.Generic;
using System.Text;

namespace KissU.IModuleServices.Common.Models
{
    [ProtoContract]
    public class BaseModel
    {
        [ProtoMember(1)]
        public Guid Id => Guid.NewGuid();
    }
}
