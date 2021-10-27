using KissU.GrpcTransport.Runtime;
using KissU.Modules.Test.Service.Contracts;

namespace KissU.Modules.Test.Service.Behaviors
{
    public partial class GreeterBehavior : Greeter.GreeterBase, IGrpcBehavior
    {
    }
}
