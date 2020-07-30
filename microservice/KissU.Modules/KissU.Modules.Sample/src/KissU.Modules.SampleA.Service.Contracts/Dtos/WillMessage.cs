namespace KissU.Services.SampleA.Contract.Dtos
{
    /// <summary>
    /// WillMessage.
    /// </summary>
    public class WillMessage
    {
        /// <summary>
        /// Gets or sets the topic.
        /// </summary>
        public string Topic { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether [will retain].
        /// </summary>
        public bool WillRetain { get; set; }

        /// <summary>
        /// Gets or sets the qos.
        /// </summary>
        public int Qos { get; set; }
    }
}