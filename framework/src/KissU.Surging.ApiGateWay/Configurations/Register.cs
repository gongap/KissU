namespace KissU.Surging.ApiGateWay.Configurations
{
    /// <summary>
    /// Register.
    /// </summary>
    public class Register
    {
        /// <summary>
        /// Gets or sets the provider.
        /// </summary>
        public RegisterProvider Provider { get; set; } = RegisterProvider.Consul;

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public string Address { get; set; } = "127.0.0.1:8500";
    }
}