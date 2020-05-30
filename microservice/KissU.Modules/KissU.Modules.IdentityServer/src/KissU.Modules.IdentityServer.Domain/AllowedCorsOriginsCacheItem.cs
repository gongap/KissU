namespace KissU.Modules.IdentityServer.Domain
{
    public class AllowedCorsOriginsCacheItem
    {
        public const string AllOrigins = "AllOrigins";

        public string[] AllowedOrigins { get; set; }
    }
}