namespace KissU.Modules.IdentityServer.Domain
{
    public static class AbpIdentityServerDbProperties
    {
        public static string DbTablePrefix { get; set; } = "IdentityServer";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "AbpIdentityServer";
    }
}
