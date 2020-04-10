using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Events;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using KissU.Services.Identity.Quickstart.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KissU.Services.Identity.Quickstart.Consent
{
    /// <summary>
    /// This controller processes the consent UI
    /// </summary>
    [SecurityHeaders]
    [Authorize]
    public class ConsentController : Controller
    {
        /// <summary>
        /// The interaction
        /// </summary>
        private readonly IIdentityServerInteractionService _interaction;
        /// <summary>
        /// The client store
        /// </summary>
        private readonly IClientStore _clientStore;
        /// <summary>
        /// The resource store
        /// </summary>
        private readonly IResourceStore _resourceStore;
        /// <summary>
        /// The events
        /// </summary>
        private readonly IEventService _events;
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<ConsentController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsentController"/> class.
        /// </summary>
        /// <param name="interaction">The interaction.</param>
        /// <param name="clientStore">The client store.</param>
        /// <param name="resourceStore">The resource store.</param>
        /// <param name="events">The events.</param>
        /// <param name="logger">The logger.</param>
        public ConsentController(
            IIdentityServerInteractionService interaction,
            IClientStore clientStore,
            IResourceStore resourceStore,
            IEventService events,
            ILogger<ConsentController> logger)
        {
            _interaction = interaction;
            _clientStore = clientStore;
            _resourceStore = resourceStore;
            _events = events;
            _logger = logger;
        }

        /// <summary>
        /// Shows the consent screen
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [HttpGet]
        public async Task<IActionResult> Index(string returnUrl)
        {
            var vm = await BuildViewModelAsync(returnUrl);
            if (vm != null)
            {
                return View("Index", vm);
            }

            return View("Error");
        }

        /// <summary>
        /// Handles the consent screen postback
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ConsentInputModel model)
        {
            var result = await ProcessConsent(model);

            if (result.IsRedirect)
            {
                if (await _clientStore.IsPkceClientAsync(result.ClientId))
                {
                    // if the client is PKCE then we assume it's native, so this change in how to
                    // return the response is for better UX for the end user.
                    return View("Redirect", new RedirectViewModel { RedirectUrl = result.RedirectUri });
                }

                return Redirect(result.RedirectUri);
            }

            if (result.HasValidationError)
            {
                ModelState.AddModelError(string.Empty, result.ValidationError);
            }

            if (result.ShowView)
            {
                return View("Index", result.ViewModel);
            }

            return View("Error");
        }

        /*****************************************/
        /* helper APIs for the ConsentController */
        /*****************************************/
        /// <summary>
        /// Processes the consent.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;ProcessConsentResult&gt;.</returns>
        private async Task<ProcessConsentResult> ProcessConsent(ConsentInputModel model)
        {
            var result = new ProcessConsentResult();

            // validate return url is still valid
            var request = await _interaction.GetAuthorizationContextAsync(model.ReturnUrl);
            if (request == null) return result;

            ConsentResponse grantedConsent = null;

            // user clicked 'no' - send back the standard 'access_denied' response
            if (model?.Button == "no")
            {
                grantedConsent = ConsentResponse.Denied;

                // emit event
                await _events.RaiseAsync(new ConsentDeniedEvent(User.GetSubjectId(), request.ClientId, request.ScopesRequested));
            }
            // user clicked 'yes' - validate the data
            else if (model?.Button == "yes")
            {
                // if the user consented to some scope, build the response model
                if (model.ScopesConsented != null && model.ScopesConsented.Any())
                {
                    var scopes = model.ScopesConsented;
                    if (ConsentOptions.EnableOfflineAccess == false)
                    {
                        scopes = scopes.Where(x => x != IdentityServer4.IdentityServerConstants.StandardScopes.OfflineAccess);
                    }

                    grantedConsent = new ConsentResponse
                    {
                        RememberConsent = model.RememberConsent,
                        ScopesConsented = scopes.ToArray()
                    };

                    // emit event
                    await _events.RaiseAsync(new ConsentGrantedEvent(User.GetSubjectId(), request.ClientId, request.ScopesRequested, grantedConsent.ScopesConsented, grantedConsent.RememberConsent));
                }
                else
                {
                    result.ValidationError = ConsentOptions.MustChooseOneErrorMessage;
                }
            }
            else
            {
                result.ValidationError = ConsentOptions.InvalidSelectionErrorMessage;
            }

            if (grantedConsent != null)
            {
                // communicate outcome of consent back to identityserver
                await _interaction.GrantConsentAsync(request, grantedConsent);

                // indicate that's it ok to redirect back to authorization endpoint
                result.RedirectUri = model.ReturnUrl;
                result.ClientId = request.ClientId;
            }
            else
            {
                // we need to redisplay the consent UI
                result.ViewModel = await BuildViewModelAsync(model.ReturnUrl, model);
            }

            return result;
        }

        /// <summary>
        /// build view model as an asynchronous operation.
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;ConsentViewModel&gt;.</returns>
        private async Task<ConsentViewModel> BuildViewModelAsync(string returnUrl, ConsentInputModel model = null)
        {
            var request = await _interaction.GetAuthorizationContextAsync(returnUrl);
            if (request != null)
            {
                var client = await _clientStore.FindEnabledClientByIdAsync(request.ClientId);
                if (client != null)
                {
                    var resources = await _resourceStore.FindEnabledResourcesByScopeAsync(request.ScopesRequested);
                    if (resources != null && (resources.IdentityResources.Any() || resources.ApiResources.Any()))
                    {
                        return CreateConsentViewModel(model, returnUrl, request, client, resources);
                    }
                    else
                    {
                        _logger.LogError("No scopes matching: {0}", request.ScopesRequested.Aggregate((x, y) => x + ", " + y));
                    }
                }
                else
                {
                    _logger.LogError("Invalid client id: {0}", request.ClientId);
                }
            }
            else
            {
                _logger.LogError("No consent request matching request: {0}", returnUrl);
            }

            return null;
        }

        /// <summary>
        /// Creates the consent view model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <param name="request">The request.</param>
        /// <param name="client">The client.</param>
        /// <param name="resources">The resources.</param>
        /// <returns>ConsentViewModel.</returns>
        private ConsentViewModel CreateConsentViewModel(
            ConsentInputModel model, string returnUrl,
            AuthorizationRequest request,
            Client client, Resources resources)
        {
            var vm = new ConsentViewModel
            {
                RememberConsent = model?.RememberConsent ?? true,
                ScopesConsented = model?.ScopesConsented ?? Enumerable.Empty<string>(),

                ReturnUrl = returnUrl,

                ClientName = client.ClientName ?? client.ClientId,
                ClientUrl = client.ClientUri,
                ClientLogoUrl = client.LogoUri,
                AllowRememberConsent = client.AllowRememberConsent
            };

            vm.IdentityScopes = resources.IdentityResources.Select(x => CreateScopeViewModel(x, vm.ScopesConsented.Contains(x.Name) || model == null)).ToArray();
            vm.ResourceScopes = resources.ApiResources.SelectMany(x => x.Scopes).Select(x => CreateScopeViewModel(x, vm.ScopesConsented.Contains(x.Name) || model == null)).ToArray();
            if (ConsentOptions.EnableOfflineAccess && resources.OfflineAccess)
            {
                vm.ResourceScopes = vm.ResourceScopes.Union(new ScopeViewModel[] {
                    GetOfflineAccessScope(vm.ScopesConsented.Contains(IdentityServer4.IdentityServerConstants.StandardScopes.OfflineAccess) || model == null)
                });
            }

            return vm;
        }

        /// <summary>
        /// Creates the scope view model.
        /// </summary>
        /// <param name="identity">The identity.</param>
        /// <param name="check">if set to <c>true</c> [check].</param>
        /// <returns>ScopeViewModel.</returns>
        private ScopeViewModel CreateScopeViewModel(IdentityResource identity, bool check)
        {
            return new ScopeViewModel
            {
                Name = identity.Name,
                DisplayName = identity.DisplayName,
                Description = identity.Description,
                Emphasize = identity.Emphasize,
                Required = identity.Required,
                Checked = check || identity.Required
            };
        }

        /// <summary>
        /// Creates the scope view model.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="check">if set to <c>true</c> [check].</param>
        /// <returns>ScopeViewModel.</returns>
        public ScopeViewModel CreateScopeViewModel(Scope scope, bool check)
        {
            return new ScopeViewModel
            {
                Name = scope.Name,
                DisplayName = scope.DisplayName,
                Description = scope.Description,
                Emphasize = scope.Emphasize,
                Required = scope.Required,
                Checked = check || scope.Required
            };
        }

        /// <summary>
        /// Gets the offline access scope.
        /// </summary>
        /// <param name="check">if set to <c>true</c> [check].</param>
        /// <returns>ScopeViewModel.</returns>
        private ScopeViewModel GetOfflineAccessScope(bool check)
        {
            return new ScopeViewModel
            {
                Name = IdentityServer4.IdentityServerConstants.StandardScopes.OfflineAccess,
                DisplayName = ConsentOptions.OfflineAccessDisplayName,
                Description = ConsentOptions.OfflineAccessDescription,
                Emphasize = true,
                Checked = check
            };
        }
    }
}