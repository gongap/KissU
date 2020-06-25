namespace KissU.AuthServer.Host.Modules.Account
{
    public class AccountOptions
    {
        /// <summary>
        /// Default value: "Windows".
        /// </summary>
        public string WindowsAuthenticationSchemeName { get; set; }

        public AccountOptions()
        {
            //TODO: This makes us depend on the Microsoft.AspNetCore.Server.IISIntegration package.
            WindowsAuthenticationSchemeName = "Windows"; //Microsoft.AspNetCore.Server.IISIntegration.IISDefaults.AuthenticationScheme;
        }
    }
}
