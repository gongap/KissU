﻿using System;
using KissU.Core.KestrelHttpServer.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Core.KestrelHttpServer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddFilters(this IServiceCollection serviceCollection, Type filter)
        {
            if (typeof(IAuthorizationFilter).IsAssignableFrom(filter))
            {
                serviceCollection.AddSingleton(typeof(IAuthorizationFilter), filter);
            }
            else if (typeof(IActionFilter).IsAssignableFrom(filter))
            {
                serviceCollection.AddSingleton(typeof(IActionFilter), filter);
            }
            else if (typeof(IExceptionFilter).IsAssignableFrom(filter))
            {
                serviceCollection.AddSingleton(typeof(IExceptionFilter), filter);
            }
        }
    }
}
