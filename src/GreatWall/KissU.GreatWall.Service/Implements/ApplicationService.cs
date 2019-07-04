using System.Threading.Tasks;
using KissU.GreatWall.Data;
using KissU.GreatWall.Domain.Models;
using KissU.GreatWall.Domain.Repositories;
using KissU.GreatWall.Service.Abstractions;
using KissU.GreatWall.Service.Dtos;
using KissU.GreatWall.Service.Queries;
using Util.Applications;
using Util.Datas.Queries;
using Util.Domains.Repositories;
using Util.Exceptions;

namespace KissU.GreatWall.Service.Implements {
    /// <summary>
    /// 应用程序服务
    /// </summary>
    public class ApplicationService : CrudServiceBase<Application, ApplicationDto, ApplicationQuery>, IApplicationService {
        /// <summary>
        /// 初始化应用程序服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="applicationRepository">应用程序仓储</param>
        public ApplicationService( IGreatWallUnitOfWork unitOfWork, IApplicationRepository applicationRepository )
            : base( unitOfWork, applicationRepository ) {
            ApplicationRepository = applicationRepository;
        }
        
        /// <summary>
        /// 应用程序仓储
        /// </summary>
        public IApplicationRepository ApplicationRepository { get; set; }

        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="query">查询参数</param>
        protected override IQueryBase<Application> CreateQuery( ApplicationQuery query ) {
            return new Query<Application>( query )
                .WhereIfNotEmpty( t => t.Code.Contains( query.Code ) )
                .WhereIfNotEmpty( t => t.Name.Contains( query.Name ) )
                .WhereIfNotEmpty( t => t.Remark.Contains( query.Remark ) );
        }

        /// <summary>
        /// 创建前操作
        /// </summary>
        protected override async Task CreateBeforeAsync( Application entity ) {
            await base.CreateBeforeAsync( entity );
            if( await ApplicationRepository.ExistsAsync( t => t.Code == entity.Code ) )
                ThrowCodeRepeatException( entity.Code );
            if( await ApplicationRepository.ExistsAsync( t => t.Name == entity.Name ) )
                ThrowNameRepeatException( entity.Name );
        }

        /// <summary>
        /// 抛出编码重复异常
        /// </summary>
        private void ThrowCodeRepeatException( string code ) {
            throw new Warning( string.Format( GreatWallResource.DuplicateApplicationCode, code ) );
        }

        /// <summary>
        /// 抛出名称重复异常
        /// </summary>
        private void ThrowNameRepeatException( string name ) {
            throw new Warning( string.Format( GreatWallResource.DuplicateApplicationName, name ) );
        }

        /// <summary>
        /// 修改前操作
        /// </summary>
        protected override async Task UpdateBeforeAsync( Application entity ) {
            await base.UpdateBeforeAsync( entity );
            if( await ApplicationRepository.ExistsAsync( t => t.Id != entity.Id && t.Code == entity.Code ) )
                ThrowCodeRepeatException( entity.Code );
            if( await ApplicationRepository.ExistsAsync( t => t.Id != entity.Id && t.Name == entity.Name ) )
                ThrowNameRepeatException( entity.Name );
        }
    }
}