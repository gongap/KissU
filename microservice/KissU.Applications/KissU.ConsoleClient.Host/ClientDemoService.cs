using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.IdentityModel;

namespace KissU.ConsoleClient.Host
{
    public class ClientDemoService : ITransientDependency
    {
        private readonly IIdentityModelAuthenticationService _authenticator;
        private readonly AbpRemoteServiceOptions _remoteServiceOptions;

        public ClientDemoService(
            IIdentityModelAuthenticationService authenticator, 
            IOptions<AbpRemoteServiceOptions> remoteServiceOptions)
        {
            _authenticator = authenticator;
            _remoteServiceOptions = remoteServiceOptions.Value;
        }

        public async Task RunAsync()
        {
            await TestWithHttpClient();
            await TestIdentityService();
            await TestTenantManagementService();
        }

        /// <summary>
        /// Shows how to manually create an HttpClient and authenticate using the
        /// IIdentityModelAuthenticationService service.
        /// </summary>
        private async Task TestWithHttpClient()
        {
            Console.WriteLine();
            Console.WriteLine("*** TestWithHttpClient ************************************");

            try
            {
                using (var client = new HttpClient())
                {
                    await _authenticator.TryAuthenticateAsync(client);

                    var url = GetServerUrl() + "api/user/getuserid/{username}?userName=10";

                    var response = await client.GetAsync(url);

                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine(response.StatusCode);
                    }
                    else
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(responseContent);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// Shows how to use application service interfaces (IIdentityUserAppService in this sample)
        /// to call a remote service which is possible by the dynamic http client proxy system.
        /// No need to use IIdentityModelAuthenticationService since the dynamic http client proxy
        /// system internally uses it. You just inject a service (IIdentityUserAppService)
        /// and call a method (GetListAsync) like a local method.
        /// </summary>
        private async Task TestIdentityService()
        {
            Console.WriteLine();
            Console.WriteLine("*** TestIdentityService ************************************");

            try
            {
                //var output = await _userAppService.GetListAsync(new GetIdentityUsersInput());

                //Console.WriteLine("Total user count: " + output.TotalCount);

                //foreach (var user in output.Items)
                //{
                //    Console.WriteLine($"- UserName={user.UserName}, Email={user.Email}, Name={user.Name}, Surname={user.Surname}");
                //}
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// Shows how to use application service interfaces (ITenantAppService in this sample)
        /// to call a remote service which is possible by the dynamic http client proxy system.
        /// No need to use IIdentityModelAuthenticationService since the dynamic http client proxy
        /// system internally uses it. You just inject a service (ITenantAppService)
        /// and call a method (GetListAsync) like a local method.
        /// </summary>
        private async Task TestTenantManagementService()
        {
            Console.WriteLine();
            Console.WriteLine("*** TestTenantManagementService ************************************");

            try
            {
                //var output = await _tenantAppService.GetListAsync(new GetTenantsInput());

                //Console.WriteLine("Total tenant count: " + output.TotalCount);

                //foreach (var tenant in output.Items)
                //{
                //    Console.WriteLine($"- Id={tenant.Id}, Name={tenant.Name}");
                //}
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private string GetServerUrl()
        {
            return _remoteServiceOptions.RemoteServices.Default.BaseUrl.EnsureEndsWith('/');
        }
    }
}