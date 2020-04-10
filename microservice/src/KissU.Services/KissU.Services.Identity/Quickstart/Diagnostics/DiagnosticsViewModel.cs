using System.Collections.Generic;
using System.Text;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json;

namespace KissU.Services.Identity.Quickstart.Diagnostics
{
    /// <summary>
    /// DiagnosticsViewModel.
    /// </summary>
    public class DiagnosticsViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticsViewModel" /> class.
        /// </summary>
        /// <param name="result">The result.</param>
        public DiagnosticsViewModel(AuthenticateResult result)
        {
            AuthenticateResult = result;

            if (result.Properties.Items.ContainsKey("client_list"))
            {
                var encoded = result.Properties.Items["client_list"];
                var bytes = Base64Url.Decode(encoded);
                var value = Encoding.UTF8.GetString(bytes);

                Clients = JsonConvert.DeserializeObject<string[]>(value);
            }
        }

        /// <summary>
        /// Gets the authenticate result.
        /// </summary>
        /// <value>The authenticate result.</value>
        public AuthenticateResult AuthenticateResult { get; }
        /// <summary>
        /// Gets the clients.
        /// </summary>
        /// <value>The clients.</value>
        public IEnumerable<string> Clients { get; } = new List<string>();
    }
}