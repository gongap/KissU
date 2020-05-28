using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace KissU.Modules.IdentityServer
{
    public abstract class UserClaim : Entity
    {
        public virtual string Type { get; protected set; }

        protected UserClaim()
        {

        }

        protected UserClaim([NotNull] string type)
        {
            Check.NotNull(type, nameof(type));

            Type = type;
        }
    }
}