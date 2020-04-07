using System.Threading.Tasks;
using KissU.Modules.GreatWall.Domain.Models;
using KissU.Util.Ddd.Domain.Domains.Repositories;

namespace KissU.Modules.GreatWall.Domain.Repositories
{
    /// <summary>
    /// 应用程序仓储
    /// </summary>
    public interface IApplicationRepository : ICompactRepository<Application>
    {
        /// <summary>
        /// 通过应用程序编码查找
        /// </summary>
        /// <param name="code">应用程序编码</param>
        /// <returns>Task&lt;Application&gt;.</returns>
        Task<Application> GetByCodeAsync(string code);

        /// <summary>
        /// 是否允许跨域访问
        /// </summary>
        /// <param name="origin">来源</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> IsOriginAllowedAsync(string origin);

        /// <summary>
        /// 是否允许创建应用程序
        /// </summary>
        /// <param name="entity">应用程序</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> CanCreateAsync(Application entity);

        /// <summary>
        /// 是否允许修改应用程序
        /// </summary>
        /// <param name="entity">应用程序</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> CanUpdateAsync(Application entity);
    }
}