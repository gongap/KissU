using System.Linq;
using System.Net;
using JetBrains.Annotations;
using KissU.Address;
using KissU.CPlatform.Runtime.Client;
using KissU.CPlatform.Runtime.Server;
using KissU.Helpers;
using KissU.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseClient([NotNull] this IApplicationBuilder app)
        {
            Check.NotNull(app, nameof(app));
            var serviceEntryManager = app.ApplicationServices.GetService<IServiceEntryManager>();
            var addressDescriptors = serviceEntryManager.GetEntries().Select(i =>
            {
                i.Descriptor.Metadatas = null;
                return new ServiceSubscriber
                {
                    Address = new[]
                    {
                        new IpAddressModel
                        {
                            Ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList
                                .FirstOrDefault(a => a.AddressFamily.ToString().Equals("InterNetwork"))?.ToString()
                        }
                    },
                    ServiceDescriptor = i.Descriptor
                };
            }).ToList();
            app.ApplicationServices.GetService<IServiceSubscribeManager>().SetSubscribersAsync(addressDescriptors);
            app.ApplicationServices.GetService<IModuleProvider>().Initialize();
        }
    }
}
