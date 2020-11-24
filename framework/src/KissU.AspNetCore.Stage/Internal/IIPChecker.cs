using System.Net;

namespace KissU.AspNetCore.Stage.Internal
{
    /// <summary>
    /// Interface IIPChecker
    /// </summary>
    public interface IIPChecker
    {
        /// <summary>
        /// Determines whether [is black ip] [the specified ip].
        /// </summary>
        /// <param name="ip">The ip.</param>
        /// <param name="routePath">The route path.</param>
        /// <returns><c>true</c> if [is black ip] [the specified ip]; otherwise, <c>false</c>.</returns>
        bool IsBlackIp(IPAddress ip, string routePath);
    }
}