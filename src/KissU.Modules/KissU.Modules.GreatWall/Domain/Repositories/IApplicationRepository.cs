using System.Threading.Tasks;
using GreatWall.Domain.Models;
using Util.Domains.Repositories;

namespace GreatWall.Domain.Repositories {
    /// <summary>
    /// 应用程序仓储
    /// </summary>
    public interface IApplicationRepository : IRepository<Application> {
        /// <summary>
        /// 通过应用程序编码查找
        /// </summary>
        /// <param name="code">应用程序编码</param>
        Task<Application> GetByCodeAsync( string code );
    }
}