using KissU.Surging.CPlatform;
using ProtoBuf;

namespace KissU.Services.SampleA.Contract.Dtos
{
    /// <summary>
    /// IdentityUser.
    /// Implements the <see cref="KissU.Surging.CPlatform.RequestData" />
    /// </summary>
    /// <seealso cref="KissU.Surging.CPlatform.RequestData" />
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