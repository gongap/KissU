using System.Threading.Tasks;
using DotNetty.Buffers;
using DotNetty.Codecs.Http.WebSockets;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Groups;

namespace KissU.DotNettyWSServer
{
    /// <summary>
    /// PlayerGroup.
    /// </summary>
    public class PlayerGroup
    {
        /// <summary>
        /// Gets or sets the channel group.
        /// </summary>
        public static IChannelGroup ChannelGroup { get; set; }

        /// <summary>
        /// Adds the channel.
        /// </summary>
        /// <param name="channel">The channel.</param>
        public static void AddChannel(IChannel channel)
        {
            ChannelGroup.Add(channel);
        }

        /// <summary>
        /// Removes the channel.
        /// </summary>
        /// <param name="channel">The channel.</param>
        public static void RemoveChannel(IChannel channel)
        {
            ChannelGroup.Remove(channel);
        }

        /// <summary>
        /// Broads the cast.
        /// </summary>
        /// <param name="message">The message.</param>
        public static async Task BroadCast(IByteBuffer message)
        {
            if (ChannelGroup == null) return;

            var frame = new BinaryWebSocketFrame(message);
            message.Retain();
            await ChannelGroup.WriteAndFlushAsync(frame);
        }

        /// <summary>
        /// Destories this instance.
        /// </summary>
        public static async Task Destory()
        {
            if (ChannelGroup == null) return;
            await ChannelGroup.CloseAsync();
        }
    }
}