using System.Net;

namespace KissU.Core.Stage.Internal
{
   public interface IIPChecker
    {
        bool IsBlackIp(IPAddress ip, string routePath);
    }
}
