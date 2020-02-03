using KissU.Core.CPlatform.Messages;

namespace KissU.Core.CPlatform.Diagnostics
{
    /// <summary>
    /// 诊断信息.
    /// Implements the <see cref="TransportMessage" />
    /// </summary>
    /// <seealso cref="TransportMessage" />
    public class DiagnosticMessage : TransportMessage
    {
        /// <summary>
        /// 消息名称.
        /// </summary>
        public string MessageName { get; set; }
    }
}