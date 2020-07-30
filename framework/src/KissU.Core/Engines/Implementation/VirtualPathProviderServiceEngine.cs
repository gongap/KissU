namespace KissU.Engines.Implementation
{
    /// <summary>
    /// 服务引擎虚拟路径提供者.
    /// Implements the <see cref="IServiceEngine" />
    /// </summary>
    /// <seealso cref="IServiceEngine" />
    public abstract class VirtualPathProviderServiceEngine : IServiceEngine
    {
        /// <summary>
        /// Gets or sets the module service location formats.
        /// </summary>
        public string[] ModuleServiceLocationFormats { get; set; }

        /// <summary>
        /// Gets or sets the component service location formats.
        /// </summary>
        public string[] ComponentServiceLocationFormats { get; set; }
    }
}