using System;
using System.Collections.Specialized;

namespace KissU.WebSocket.Core.Net
{
    /// <summary>Defines some common token retrieval strategies</summary>
    public static class TokenRetrieval
    {
        /// <summary>Reads the token from the authrorization header.</summary>
        /// <param name="scheme">The scheme (defaults to Bearer).</param>
        /// <returns></returns>
        public static Func<NameValueCollection, string> FromAuthorizationHeader(string scheme = "Bearer") => headers =>
        {
            string str = headers["Authorization"];
            if (string.IsNullOrEmpty(str))
                return (string) null;
            return str.StartsWith(scheme + " ", StringComparison.OrdinalIgnoreCase) ? str.Substring(scheme.Length + 1).Trim() : (string) null;
        };

        /// <summary>Reads the token from a query string parameter.</summary>
        /// <param name="name">The name (defaults to access_token).</param>
        /// <returns></returns>
        public static Func<NameValueCollection, string> FromQueryString(string name = "access_token") => query => query[name];
    }
}
