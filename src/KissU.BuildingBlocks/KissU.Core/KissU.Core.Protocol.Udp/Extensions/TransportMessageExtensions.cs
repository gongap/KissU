using System.Runtime.CompilerServices;
using KissU.Core.CPlatform.Messages;

namespace KissU.Core.Protocol.Udp.Extensions
{
    /// <summary>
    /// TransportMessageExtensions.
    /// </summary>
    public static class TransportMessageExtensions
    {

        /// <summary>
        /// Determines whether [is UDP dispatch message] [the specified message].
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns><c>true</c> if [is UDP dispatch message] [the specified message]; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsUdpDispatchMessage(this TransportMessage message)
        {
            return message.ContentType == typeof(byte[]).FullName;
        }
    }
}
