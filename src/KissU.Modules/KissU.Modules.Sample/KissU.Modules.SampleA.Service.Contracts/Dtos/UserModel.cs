using KissU.Core.System.Intercept;
using ProtoBuf;

namespace KissU.Modules.SampleA.Service.Contracts.Dtos
{
    /// <summary>
    /// UserModel.
    /// </summary>
    [ProtoContract]
    public class UserModel
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        [ProtoMember(1)]
        [CacheKey(1)]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [ProtoMember(2)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        [ProtoMember(3)]
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the sex.
        /// </summary>
        [ProtoMember(4)]
        public Sex Sex { get; set; }
    }
}