using System;
using System.Collections.Generic;
using System.Text;

namespace KissU.Modules.IdentityServer.Domain.Shared.Enums
{
    /// <summary>Token expiration types.</summary>
    public enum TokenExpiration
    {
        /// <summary>Sliding token expiration</summary>
        Sliding,
        /// <summary>Absolute token expiration</summary>
        Absolute,
    }
}
