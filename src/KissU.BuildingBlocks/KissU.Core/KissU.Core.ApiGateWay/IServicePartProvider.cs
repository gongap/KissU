using System.Collections.Generic;
using System.Threading.Tasks;

namespace KissU.Core.ApiGateWay
{
    /// <summary>
    /// Interface IServicePartProvider
    /// </summary>
    public interface IServicePartProvider
    {
        /// <summary>
        /// Determines whether the specified routh path is part.
        /// </summary>
        /// <param name="routhPath">The routh path.</param>
        /// <returns><c>true</c> if the specified routh path is part; otherwise, <c>false</c>.</returns>
        bool IsPart(string routhPath);

        /// <summary>
        /// Merges the specified routh path.
        /// </summary>
        /// <param name="routhPath">The routh path.</param>
        /// <param name="param">The parameter.</param>
        /// <returns>Task&lt;System.Object&gt;.</returns>
        Task<object> Merge(string routhPath, Dictionary<string, object> param);
    }
}