using System.Threading.Tasks;
using GreatWall.Domain.Models;
using GreatWall.Domain.Repositories;
using Util.Datas.Ef.Core;

namespace GreatWall.Data.Repositories {
    /// <summary>
    /// 应用程序仓储
    /// </summary>
    public class ApplicationRepository : RepositoryBase<Application>, IApplicationRepository {
        /// <summary>
        /// 初始化应用程序仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ApplicationRepository( IGreatWallUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }

        /// <summary>
        /// 通过应用程序编码查找
        /// </summary>
        /// <param name="code">应用程序编码</param>
        public async Task<Application> GetByCodeAsync( string code ) {
            return await SingleAsync( t => t.Code == code );
        }
    }
}