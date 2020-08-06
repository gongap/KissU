using KissU.Kestrel;

namespace KissU.Stage.Internal
{
    /// <summary>
    /// Interface IWebServerListener
    /// </summary>
    public interface IWebServerListener
    {
        /// <summary>
        /// Listens the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        void Listen(WebHostContext context);
    }
}