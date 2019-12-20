using System;
using System.Collections.Generic;
using System.Text;

namespace KissU.Modules.IdentityServer.Domain.Shared
{
    public class GrantTypes
    {
        public static ICollection<string> Implicit =>
            new[] { IdentityServerConstants.GrantType.Implicit };

        public static ICollection<string> ImplicitAndClientCredentials =>
            new[] { IdentityServerConstants.GrantType.Implicit, IdentityServerConstants.GrantType.ClientCredentials };

        public static ICollection<string> Code =>
            new[] { IdentityServerConstants.GrantType.AuthorizationCode };

        public static ICollection<string> CodeAndClientCredentials =>
            new[] { IdentityServerConstants.GrantType.AuthorizationCode, IdentityServerConstants.GrantType.ClientCredentials };

        public static ICollection<string> Hybrid =>
            new[] { IdentityServerConstants.GrantType.Hybrid };

        public static ICollection<string> HybridAndClientCredentials =>
            new[] { IdentityServerConstants.GrantType.Hybrid, IdentityServerConstants.GrantType.ClientCredentials };

        public static ICollection<string> ClientCredentials =>
            new[] { IdentityServerConstants.GrantType.ClientCredentials };

        public static ICollection<string> ResourceOwnerPassword =>
            new[] { IdentityServerConstants.GrantType.ResourceOwnerPassword };

        public static ICollection<string> ResourceOwnerPasswordAndClientCredentials =>
            new[] { IdentityServerConstants.GrantType.ResourceOwnerPassword, IdentityServerConstants.GrantType.ClientCredentials };

        public static ICollection<string> DeviceFlow =>
            new[] { IdentityServerConstants.GrantType.DeviceFlow };
    }
}
