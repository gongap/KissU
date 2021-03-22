using JetBrains.Annotations;

namespace KissU.Dependency
{
    public interface IObjectAccessor<out T>
    {
        [CanBeNull]
        T Value { get; }
    }
}