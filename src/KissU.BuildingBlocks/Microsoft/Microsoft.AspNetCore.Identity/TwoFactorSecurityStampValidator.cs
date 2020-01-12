// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Microsoft.AspNetCore.Identity
{
    /// <summary>
    /// Responsible for validation of two factor identity cookie security stamp.
    /// </summary>
    /// <typeparam name="TUser">The type encapsulating a user.</typeparam>
    public class TwoFactorSecurityStampValidator<TUser> : SecurityStampValidator<TUser>, ITwoFactorSecurityStampValidator where TUser : class
    {
        /// <summary>
        /// Creates a new instance of <see cref="SecurityStampValidator{TUser}"/>.
        /// </summary>
        /// <param name="options">Used to access the <see cref="IdentityOptions"/>.</param>
        /// <param name="signInManager">The <see cref="SignInManager{TUser}"/>.</param>
        /// <param name="clock">The system clock.</param>
        /// <param name="logger">The logger.</param>
        public TwoFactorSecurityStampValidator(IOptions<SecurityStampValidatorOptions> options, SignInManager<TUser> signInManager, ISystemClock clock, ILoggerFactory logger) : base(options, signInManager, clock, logger)
        { }

        /// <summary>
        /// Verifies the principal's security stamp, returns the matching user if successful
        /// </summary>
        /// <param name="principal">The principal to verify.</param>
        /// <returns>The verified user or null if verification fails.</returns>
        protected override Task<TUser> VerifySecurityStamp(ClaimsPrincipal principal)
            => SignInManager.ValidateTwoFactorSecurityStampAsync(principal);

        /// <summary>
        /// Called when the security stamp has been verified.
        /// </summary>
        /// <param name="user">The user who has been verified.</param>
        /// <param name="context">The <see cref="CookieValidatePrincipalContext"/>.</param>
        /// <returns>A task.</returns>
        protected override Task SecurityStampVerified(TUser user, CookieValidatePrincipalContext context)
            => Task.CompletedTask;
    }
}
