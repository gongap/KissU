using System;
using KissU.AspNetCore.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.AspNetCore.Extensions
{
    /// <summary>
    /// ServiceCollectionExtensions.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the filters.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        /// <param name="filter">The filter.</param>
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