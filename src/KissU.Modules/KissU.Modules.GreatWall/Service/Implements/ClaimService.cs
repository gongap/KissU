using GreatWall.Data;
using GreatWall.Domain.Models;
using GreatWall.Domain.Repositories;
using GreatWall.Service.Abstractions;
using GreatWall.Service.Dtos;
using GreatWall.Service.Queries;
using Util.Applications;
using Util.Datas.Queries;
using Util.Domains.Repositories;

namespace GreatWall.Service.Implements {
    /// <summary>
    /// 声明服务
    /// </summary>
    public class ClaimService : CrudServiceBase<Claim, ClaimDto, ClaimQuery>, IClaimService {
        /// <summary>
        /// 初始化声明服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="claimRepository">声明仓储</param>
        public ClaimService( IGreatWallUnitOfWork unitOfWork, IClaimRepository claimRepository )
            : base( unitOfWork, claimRepository ) {
            ClaimRepository = claimRepository;
        }
        
        /// <summary>
        /// 声明仓储
        /// </summary>
        public IClaimRepository ClaimRepository { get; set; }
        
        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<Claim> CreateQuery( ClaimQuery param ) {
            return new Query<Claim>( param )
                .WhereIfNotEmpty(  t => t.Name.Contains( param.Name ) )
                .WhereIfNotEmpty( t => t.Remark.Contains( param.Remark ) );
        }
    }
}