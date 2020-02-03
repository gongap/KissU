namespace KissU.Core.CPlatform.Support.Implementation
{
    /// <summary>
    /// 服务命令事件参数。
    /// </summary>
    public class ServiceCommandEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceCommandEventArgs" /> class.
        /// </summary>
        /// <param name="serviceCommand">The service command.</param>
        public ServiceCommandEventArgs(ServiceCommandDescriptor serviceCommand)
        {
            Command = serviceCommand;
        }

        /// <summary>
        /// 服务命令信息。
        /// </summary>
        public ServiceCommandDescriptor Command { get; }
    }
}