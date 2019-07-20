using System.Threading.Tasks;
using GreatWall.Data.Pos;
using GreatWall.Data.Pos.Extensions;
using GreatWall.Data.Stores.Abstractions;
using GreatWall.Domain.Models;
using GreatWall.Domain.Repositories;
using Util.Datas.Ef.Core;

namespace GreatWall.Data.Repositories {
    /// <summary>
    /// 应用程序仓储
    /// </summary>
    public class ApplicationRepository : CompactRepositoryBase<Application, ApplicationPo>, IApplicationRepository {
        /// <summary>
        /// 应用程序存储器
        /// </summary>
        private readonly IApplicationPoStore _store;

        /// <summary>
        /// 初始化应用程序仓储
        /// </summary>
        /// <param name="store">应用程序存储器</param>
        public ApplicationRepository( IApplicationPoStore store ) : base( store ) {
            _store = store;
        }

        /// <summary>
        /// 转成实体
        /// </summary>
        /// <param name="po">持久化对象</param>
        protected override Application ToEntity( ApplicationPo po ) {
            return po.ToEntity();
        }

        /// <summary>
        /// 转成持久化对象
        /// </summary>
        /// <param name="entity">实体</param>
        protected override ApplicationPo ToPo( Application entity ) {
            return entity.ToPo();
        }

        /// <summary>
        /// 通过应用程序编码查找
        /// </summary>
        /// <param name="code">应用程序编码</param>
        public async Task<Application> GetByCodeAsync( string code ) {
            var po = await _store.SingleAsync( t => t.Code == code );
            return ToEntity( po );
        }
    }
}