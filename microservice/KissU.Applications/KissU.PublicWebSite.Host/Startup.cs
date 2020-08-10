﻿using Autofac;
using KissU.Dependency;
using KissU.Caching;
using KissU.CPlatform;
using KissU.ServiceProxy;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.PublicWebSite.Host
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<PublicWebSiteHostModule>();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.AddMicroService(service => { service.AddClient().AddCache(); });
            builder.Register(p => new CPlatformContainer(ServiceLocator.Current));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.InitializeApplication();
            ServiceLocator.Register(app.ApplicationServices);
        }
    }
}
