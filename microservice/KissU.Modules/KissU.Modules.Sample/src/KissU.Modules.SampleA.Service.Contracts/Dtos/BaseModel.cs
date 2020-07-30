using System;
using ProtoBuf;

namespace KissU.Services.SampleA.Contract.Dtos
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