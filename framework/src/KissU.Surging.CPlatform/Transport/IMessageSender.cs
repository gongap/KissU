﻿using System.Threading.Tasks;
using KissU.Surging.CPlatform.Messages;

namespace KissU.Surging.CPlatform.Transport
{
    /// <summary>
    /// 一个抽象的发送者。
    /// </summary>
    public interface IMessageSender
    {
        /// <summary>
        /// 发送消息。
        /// </summary>
        /// <param name="message">消息内容。</param>
        /// <returns>一个任务。</returns>
        Task SendAsync(TransportMessage message);

        /// <summary>
        /// 发送消息并清空缓冲区。
        /// </summary>
        /// <param name="message">消息内容。</param>
        /// <returns>一个任务。</returns>
        Task SendAndFlushAsync(TransportMessage message);
    }
}