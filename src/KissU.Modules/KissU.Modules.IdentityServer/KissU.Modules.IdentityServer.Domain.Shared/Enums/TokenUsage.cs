using System;
using System.Collections.Generic;
using System.Text;

namespace KissU.Modules.IdentityServer.Domain.Shared.Enums
{
    public enum TokenUsage
    {
        /// <summary>Re-use the refresh token handle</summary>
        ReUse,
        /// <summary>Issue a new refresh token handle every time</summary>
        OneTimeOnly,
    }
}
