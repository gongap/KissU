using System.Runtime.Serialization;

namespace KissU.Core.Commons
{
    [DataContract]
    public class LimitedResultRequest
    {
        /// <summary>
        /// Default value: 10.
        /// </summary>
        [DataMember]
        public static int DefaultMaxResultCount { get; set; } = 10;

        /// <summary>
        /// Maximum possible value of the <see cref="MaxResultCount"/>.
        /// Default value: 1,000.
        /// </summary>
        [DataMember]
        public static int MaxMaxResultCount { get; set; } = 1000;

        /// <summary>
        /// Maximum result count should be returned.
        /// This is generally used to limit result count on paging.
        /// </summary>
        [DataMember]
        public virtual int MaxResultCount { get; set; } = DefaultMaxResultCount;
    }
}