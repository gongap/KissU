using KissU.Core.CPlatform;
using ProtoBuf;

namespace KissU.Modules.SampleA.Service.Contracts.Dtos
{
    /// <summary>
    /// IdentityUser.
    /// Implements the <see cref="KissU.Core.CPlatform.RequestData" />
    /// </summary>
    /// <seealso cref="KissU.Core.CPlatform.RequestData" />
    [ProtoContract]
    public class IdentityUser : RequestData
    {
        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        [ProtoMember(1)]
        public string RoleId { get; set; }
    }
}