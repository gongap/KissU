using KissU.Surging.CPlatform.Messages;

namespace KissU.Surging.CPlatform.Runtime.Server
{
    /// <summary>
    /// 一个抽象的服务条目定位器。
    /// </summary>
    public interface IServiceEntryLocate
    {
        /// <summary>
        /// 定位服务条目。
        /// </summary>
        /// <param name="invokeMessage">远程调用消息。</param>
        /// <returns>服务条目。</returns>
        ServiceEntry Locate(RemoteInvokeMessage invokeMessage);

        /// <summary>
        /// 定位服务条目.
        /// </summary>
        /// <param name="httpMessage">The HTTP message.</param>
        /// <returns>ServiceEntry.</returns>
        ServiceEntry Locate(HttpRequestMessage httpMessage);
    }
}