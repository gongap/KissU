using KissU.Core.KestrelHttpServer;

namespace KissU.Core.Stage.Internal
{
    public interface IWebServerListener
    {
        void Listen(WebHostContext context);
    }
}
