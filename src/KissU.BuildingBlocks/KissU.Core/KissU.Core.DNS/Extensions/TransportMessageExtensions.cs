using System.Runtime.CompilerServices;
using KissU.Core.CPlatform.Messages;

namespace KissU.Core.DNS.Extensions
{
    /// <summary>
    /// TransportMessageExtensions.
    /// </summary>
    public static class TransportMessageExtensions
    {

        /// <summary>
        /// Determines whether [is DNS result message] [the specified message].
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns><c>true</c> if [is DNS result message] [the specified message]; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsDnsResultMessage(this TransportMessage message)
        {
            return message.ContentType == typeof(DnsTransportMessage).FullName;
        }
    }
}
