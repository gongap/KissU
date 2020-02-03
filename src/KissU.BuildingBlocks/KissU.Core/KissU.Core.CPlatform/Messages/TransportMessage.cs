using System;
using System.Runtime.CompilerServices;

namespace KissU.Core.CPlatform.Messages
{
    /// <summary>
    /// 传输消息模型。
    /// </summary>
    public class TransportMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransportMessage" /> class.
        /// </summary>
        public TransportMessage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportMessage" /> class.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <exception cref="ArgumentNullException">content</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TransportMessage(object content)
        {
            Content = content ?? throw new ArgumentNullException(nameof(content));
            ContentType = content.GetType().FullName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportMessage" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="content">The content.</param>
        /// <exception cref="ArgumentNullException">content</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TransportMessage(string id, object content)
        {
            Id = id;
            Content = content ?? throw new ArgumentNullException(nameof(content));
            ContentType = content.GetType().FullName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportMessage" /> class.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="fullName">The full name.</param>
        /// <exception cref="ArgumentNullException">content</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TransportMessage(object content, string fullName)
        {
            Content = content ?? throw new ArgumentNullException(nameof(content));
            ContentType = fullName;
        }

        /// <summary>
        /// 消息Id。
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 消息内容。
        /// </summary>
        public object Content { get; set; }

        /// <summary>
        /// 内容类型。
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// 是否调用消息。
        /// </summary>
        /// <returns>如果是则返回true，否则返回false。</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsInvokeMessage()
        {
            return ContentType == MessagePackTransportMessageType.remoteInvokeMessageTypeName;
        }

        /// <summary>
        /// 是否是调用结果消息。
        /// </summary>
        /// <returns>如果是则返回true，否则返回false。</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsInvokeResultMessage()
        {
            return ContentType == MessagePackTransportMessageType.remoteInvokeResultMessageTypeName;
        }

        /// <summary>
        /// Determines whether [is HTTP message].
        /// </summary>
        /// <returns><c>true</c> if [is HTTP message]; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsHttpMessage()
        {
            return ContentType == MessagePackTransportMessageType.httpMessageTypeName;
        }

        /// <summary>
        /// Determines whether [is HTTP result message].
        /// </summary>
        /// <returns><c>true</c> if [is HTTP result message]; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsHttpResultMessage()
        {
            return ContentType == MessagePackTransportMessageType.httpResultMessageTypeName;
        }

        /// <summary>
        /// 获取内容。
        /// </summary>
        /// <typeparam name="T">内容类型。</typeparam>
        /// <returns>内容实例。</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T GetContent<T>()
        {
            return (T)Content;
        }

        /// <summary>
        /// 创建一个调用传输消息。
        /// </summary>
        /// <param name="invokeMessage">调用实例。</param>
        /// <returns>调用传输消息。</returns>
        public static TransportMessage CreateInvokeMessage(RemoteInvokeMessage invokeMessage)
        {
            return new TransportMessage(invokeMessage, MessagePackTransportMessageType.remoteInvokeMessageTypeName)
            {
                Id = Guid.NewGuid().ToString("N"),
            };
        }

        /// <summary>
        /// 创建一个调用结果传输消息。
        /// </summary>
        /// <param name="id">消息Id。</param>
        /// <param name="invokeResultMessage">调用结果实例。</param>
        /// <returns>调用结果传输消息。</returns>
        public static TransportMessage CreateInvokeResultMessage(string id, RemoteInvokeResultMessage invokeResultMessage)
        {
            return new TransportMessage(invokeResultMessage, MessagePackTransportMessageType.remoteInvokeResultMessageTypeName)
            {
                Id = id,
            };
        }
    }
}