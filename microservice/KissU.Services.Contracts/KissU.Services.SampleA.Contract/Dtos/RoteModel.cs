using ProtoBuf;

namespace KissU.Modules.SampleA.Service.Contracts.Dtos
{
    /// <summary>
    /// RoteModel.
    /// </summary>
    [ProtoContract]
    public class RoteModel
    {
        /// <summary>
        /// Gets or sets the service identifier.
        /// </summary>
        [ProtoMember(1)]
        public string ServiceId { get; set; }
    }
}