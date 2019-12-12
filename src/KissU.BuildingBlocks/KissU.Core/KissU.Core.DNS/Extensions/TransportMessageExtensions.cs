using System.Runtime.CompilerServices;
using KissU.Core.CPlatform.Messages;

namespace KissU.Core.DNS.Extensions
{
    public static class TransportMessageExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsDnsResultMessage(this TransportMessage message)
        {
            return message.ContentType == typeof(DnsTransportMessage).FullName;
        }
    }
}
