namespace KissU.Core.CPlatform.Support.Implementation
{
    /// <summary>
    /// 服务命令变更事件参数。
    /// </summary>
    public class ServiceCommandChangedEventArgs : ServiceCommandEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceCommandChangedEventArgs"/> class.
        /// </summary>
        /// <param name="serviceCommand">The service command.</param>
        /// <param name="oldServiceCommand">The old service command.</param>
        public ServiceCommandChangedEventArgs(ServiceCommandDescriptor serviceCommand, ServiceCommandDescriptor oldServiceCommand)
            : base(serviceCommand)
        {
            OldServiceCommand = oldServiceCommand;
        }

        /// <summary>
        /// 旧的服务命令信息。
        /// </summary>
        public ServiceCommandDescriptor OldServiceCommand { get; set; }
    }
}