using System.Diagnostics.CodeAnalysis;
using Autofac;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Abp.Autofac.DependencyInjection
{
    /// <summary>
    /// Autofac implementation of the ASP.NET Core <see cref="IServiceScopeFactory"/>.
    /// </summary>
    /// <seealso cref="Microsoft.Extensions.DependencyInjection.IServiceScopeFactory" />
    [SuppressMessage("Microsoft.ApiDesignGuidelines", "CA2213", Justification = "The creator of the root service lifetime scope is responsible for disposal.")]
    internal class AutofacServiceScopeFactory : IServiceScopeFactory
    {
        private readonly ILifetimeScope _lifetimeScope;

        /// <summary>
        /// Initializes a new instance of the <see cref="AutofacServiceScopeFactory"/> class.
        /// </summary>
        /// <param name="lifetimeScope">The lifetime scope.</param>
        public AutofacServiceScopeFactory(ILifetimeScope lifetimeScope)
        {
            this._lifetimeScope = lifetimeScope;
        }

        /// <summary>
        /// Creates an <see cref="IServiceScope" /> which contains an
        /// <see cref="System.IServiceProvider" /> used to resolve dependencies within
        /// the scope.
        /// </summary>
        /// <returns>
        /// An <see cref="IServiceScope" /> controlling the lifetime of the scope. Once
        /// this is disposed, any scoped services that have been resolved
        /// from the <see cref="IServiceScope.ServiceProvider" />
        /// will also be disposed.
        /// </returns>
        public IServiceScope CreateScope()
        {
            return new AutofacServiceScope(this._lifetimeScope.BeginLifetimeScope());
        }
    }
}