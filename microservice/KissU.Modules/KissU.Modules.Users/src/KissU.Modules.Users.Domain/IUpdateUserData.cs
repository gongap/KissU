using JetBrains.Annotations;
using KissU.Modules.Users.Abstractions;

namespace KissU.Modules.Users.Domain
{
    public interface IUpdateUserData
    {
        bool Update([NotNull] IUserData user);
    }
}