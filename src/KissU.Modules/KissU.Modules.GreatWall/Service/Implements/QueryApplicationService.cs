using System.Threading.Tasks;
using KissU.IModuleServices.GreatWall.Abstractions;
using KissU.IModuleServices.GreatWall.Dtos;
using KissU.IModuleServices.GreatWall.Queries;
using KissU.Modules.GreatWall.Data.Pos;
using KissU.Modules.GreatWall.Data.Stores.Abstractions;
using KissU.Modules.GreatWall.Domain.Repositories;
using Util.Applications;
using Util.Datas.Queries;
using Util.Domains.Repositories;
using Util.Maps;

namespace KissU.Modules.GreatWall.Service.Implements
{
    /// <summary>
    /// 应用程序查询服务
    /// </summary>
    public class QueryApplicationService : QueryServiceBase<ApplicationPo, ApplicationDto, ApplicationQuery>, IQueryApplicationService
    {
        /// <summary>
        /// 初始化应用程序查询服务
        /// </summary>
        /// <param name="applicationPoStore">应用程序存储器</param>
        /// <param name="applicationRepository">应用程序仓储</param>
        public QueryApplicationService(IApplicationPoStore applicationPoStore, IApplicationRepository applicationRepository) : base(applicationPoStore)
        {
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
        protected override IQueryBase<ApplicationPo> CreateQuery(ApplicationQuery query)
        {
            return new Query<ApplicationPo>(query)
                .WhereIfNotEmpty(t => t.Code.Contains(query.Code))
                .WhereIfNotEmpty(t => t.Name.Contains(query.Name))
                .WhereIfNotEmpty(t => t.Remark.Contains(query.Remark));
        }

        /// <summary>
        /// 通过应用程序编码查找
        /// </summary>
        /// <param name="code">应用程序编码</param>
        public async Task<ApplicationDto> GetByCodeAsync(string code)
        {
            var application = await ApplicationRepository.GetByCodeAsync(code);
            return application.MapTo<ApplicationDto>();
        }
    }
}