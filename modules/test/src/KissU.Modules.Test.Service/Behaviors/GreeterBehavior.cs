using KissU.Dependency;
using KissU.Modules.Test.Service.Contracts;

namespace KissU.Modules.Test.Service.Behaviors
{
    public partial class GreeterBehavior : Greeter.GreeterBase, IServiceBehavior
    {
    }
}
