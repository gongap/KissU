using System.Runtime.CompilerServices;
using KissU.CPlatform.Messages;

namespace KissU.DotNetty.Tcp.Extensions
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
        public static bool IsTcpDispatchMessage(this TransportMessage message)
        {
            return message.ContentType == typeof(byte[]).FullName;
        }
    }
}
