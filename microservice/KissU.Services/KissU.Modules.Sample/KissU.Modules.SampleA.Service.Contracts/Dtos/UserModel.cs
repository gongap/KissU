using System.ComponentModel.DataAnnotations;
using KissU.Surging.Caching.Interceptors;
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
        [CacheKey(2)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        [ProtoMember(3)]
        [Range(0, 150, ErrorMessage = "年龄只能在0到150岁之间")]
        [CacheKey(3)]
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the sex.
        /// </summary>
        [ProtoMember(4)]
        public Sex Sex { get; set; }
    }

    /// <summary>
    /// Enum Sex
    /// </summary>
    public enum Sex
    {
        /// <summary>
        /// The man
        /// </summary>
        Man,
        Woman
    }
}