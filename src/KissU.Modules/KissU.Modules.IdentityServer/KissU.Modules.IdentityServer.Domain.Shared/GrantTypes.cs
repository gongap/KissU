using System;
using System.Collections.Generic;
using System.Text;

namespace KissU.Modules.IdentityServer.Domain.Shared
{
    public class GrantTypes
    {
        public static ICollection<string> Implicit =>
            new[] { Constants.GrantType.Implicit };

        public static ICollection<string> ImplicitAndClientCredentials =>
            new[] { Constants.GrantType.Implicit, Constants.GrantType.ClientCredentials };

        public static ICollection<string> Code =>
            new[] { Constants.GrantType.AuthorizationCode };

        public static ICollection<string> CodeAndClientCredentials =>
            new[] { Constants.GrantType.AuthorizationCode, Constants.GrantType.ClientCredentials };

        public static ICollection<string> Hybrid =>
            new[] { Constants.GrantType.Hybrid };

        public static ICollection<string> HybridAndClientCredentials =>
            new[] { Constants.GrantType.Hybrid, Constants.GrantType.ClientCredentials };

        public static ICollection<string> ClientCredentials =>
            new[] { Constants.GrantType.ClientCredentials };

        public static ICollection<string> ResourceOwnerPassword =>
            new[] { Constants.GrantType.ResourceOwnerPassword };

        public static ICollection<string> ResourceOwnerPasswordAndClientCredentials =>
            new[] { Constants.GrantType.ResourceOwnerPassword, Constants.GrantType.ClientCredentials };

        public static ICollection<string> DeviceFlow =>
            new[] { Constants.GrantType.DeviceFlow };
    }
}
