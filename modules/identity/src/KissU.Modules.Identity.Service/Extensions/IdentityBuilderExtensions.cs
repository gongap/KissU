using System;
using Microsoft.AspNetCore.Identity;

namespace KissU.Modules.Identity.Service.Extensions
{
    /// <summary>
    /// Helper functions for configuring identity services.
    /// </summary>
    public static class IdentityBuilderExtensions
    {
        /// <summary>
        /// Adds the default token providers used to generate tokens for reset passwords, change email
        /// and change telephone number operations, and for two factor authentication token generation.
        /// </summary>
        /// <param name="builder">The current <see cref="T:Microsoft.AspNetCore.Identity.IdentityBuilder" /> instance.</param>
        /// <returns>The current <see cref="T:Microsoft.AspNetCore.Identity.IdentityBuilder" /> instance.</returns>
        public static IdentityBuilder AddTokenProviders(
            this IdentityBuilder builder)
        {
            Type userType = builder.UserType;
            Type provider1 = typeof(PhoneNumberTokenProvider<>).MakeGenericType(userType);
            Type provider2 = typeof(EmailTokenProvider<>).MakeGenericType(userType);
            Type provider3 = typeof(AuthenticatorTokenProvider<>).MakeGenericType(userType);
            return builder.AddTokenProvider(TokenOptions.DefaultEmailProvider, provider1)
                .AddTokenProvider(TokenOptions.DefaultPhoneProvider, provider2)
                .AddTokenProvider(TokenOptions.DefaultAuthenticatorProvider, provider3);
        }
    }
}