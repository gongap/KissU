using Greet;
using KissU.Surging.CPlatform.Ioc;

namespace KissU.Modules.SampleA.Service.Behaviors
{
    /// <summary>
    /// GreeterBehavior.
    /// Implements the <see cref="Greet.Greeter.GreeterBase" />
    /// Implements the <see cref="KissU.Surging.CPlatform.Ioc.IServiceBehavior" />
    /// </summary>
    /// <seealso cref="Greet.Greeter.GreeterBase" />
    /// <seealso cref="KissU.Surging.CPlatform.Ioc.IServiceBehavior" />
    public class GreeterBehavior : Greeter.GreeterBase, IServiceBehavior
    {
    }
}