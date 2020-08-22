using KissU.Modules.Identity.Domain;
using KissU.Modules.IdentityServer.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Modules.IdentityServer.AspNetIdentity
{
    public static class AbpIdentityServerBuilderExtensions
    {
        public static IIdentityServerBuilder AddAspNetIdentity(
            this IIdentityServerBuilder builder,
            AbpIdentityServerBuilderOptions options = null)
        {
            if (options == null)
            {
                options = new AbpIdentityServerBuilderOptions();
            }

            //TODO: AspNet Identity integration lines. Can be extracted to a extension method
            if (options.IntegrateToAspNetIdentity)
            {
                builder.AddAspNetIdentity<IdentityUser>();
                builder.AddProfileService<AbpProfileService>();
                builder.AddResourceOwnerValidator<AbpResourceOwnerPasswordValidator>();
            }

            return builder;
        }
    }
}