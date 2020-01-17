using System;
using System.Collections.Generic;
using System.Linq;

namespace KissU.IdentityServer.Quickstart.Account
{
    /// <summary>
    /// LoginViewModel.
    /// Implements the <see cref="KissU.IdentityServer.Quickstart.Account.LoginInputModel" />
    /// </summary>
    /// <seealso cref="KissU.IdentityServer.Quickstart.Account.LoginInputModel" />
    public class LoginViewModel : LoginInputModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether [allow remember login].
        /// </summary>
        /// <value><c>true</c> if [allow remember login]; otherwise, <c>false</c>.</value>
        public bool AllowRememberLogin { get; set; } = true;
        /// <summary>
        /// Gets or sets a value indicating whether [enable local login].
        /// </summary>
        /// <value><c>true</c> if [enable local login]; otherwise, <c>false</c>.</value>
        public bool EnableLocalLogin { get; set; } = true;

        /// <summary>
        /// Gets or sets the external providers.
        /// </summary>
        /// <value>The external providers.</value>
        public IEnumerable<ExternalProvider> ExternalProviders { get; set; } = Enumerable.Empty<ExternalProvider>();
        /// <summary>
        /// Gets the visible external providers.
        /// </summary>
        /// <value>The visible external providers.</value>
        public IEnumerable<ExternalProvider> VisibleExternalProviders => ExternalProviders.Where(x => !String.IsNullOrWhiteSpace(x.DisplayName));

        /// <summary>
        /// Gets a value indicating whether this instance is external login only.
        /// </summary>
        /// <value><c>true</c> if this instance is external login only; otherwise, <c>false</c>.</value>
        public bool IsExternalLoginOnly => EnableLocalLogin == false && ExternalProviders?.Count() == 1;
        /// <summary>
        /// Gets the external login scheme.
        /// </summary>
        /// <value>The external login scheme.</value>
        public string ExternalLoginScheme => IsExternalLoginOnly ? ExternalProviders?.SingleOrDefault()?.AuthenticationScheme : null;
    }
}