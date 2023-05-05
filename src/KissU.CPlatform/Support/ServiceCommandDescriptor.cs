namespace KissU.CPlatform.Support
{
    /// <summary>
    /// 服务命令描述符.
    /// Implements the <see cref="ServiceCommand" />
    /// </summary>
    /// <seealso cref="ServiceCommand" />
    public class ServiceCommandDescriptor : ServiceCommand
    {
        /// <summary>
        /// 服务标识符.
        /// </summary>
        public string ServiceId { get; set; }
    }
}