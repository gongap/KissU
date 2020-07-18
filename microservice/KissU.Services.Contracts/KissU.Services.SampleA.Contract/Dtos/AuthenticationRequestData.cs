using ProtoBuf;

namespace KissU.Services.SampleA.Contract.Dtos
{
    /// <summary>
    /// AuthenticationRequestData.
    /// </summary>
    [ProtoContract]
    public class AuthenticationRequestData
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        [ProtoMember(1)]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [ProtoMember(2)]
        public string Password { get; set; }
    }
}