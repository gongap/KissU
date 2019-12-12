using System.Runtime.CompilerServices;
using KissU.Core.CPlatform.Messages;

namespace KissU.Core.Protocol.Udp.Extensions
{
    public static class TransportMessageExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsUdpDispatchMessage(this TransportMessage message)
        {
            return message.ContentType == typeof(byte[]).FullName;
        }
    }
}
