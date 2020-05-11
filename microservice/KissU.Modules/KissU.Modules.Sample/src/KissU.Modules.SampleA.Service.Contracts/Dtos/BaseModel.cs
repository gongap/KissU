using System;
using ProtoBuf;

namespace KissU.Modules.SampleA.Service.Contracts.Dtos
{
    /// <summary>
    /// BaseModel.
    /// </summary>
    [ProtoContract]
    public class BaseModel
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        [ProtoMember(1)]
        public Guid Id => Guid.NewGuid();
    }
}