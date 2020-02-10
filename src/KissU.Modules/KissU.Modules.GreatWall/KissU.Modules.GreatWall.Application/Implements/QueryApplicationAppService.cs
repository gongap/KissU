using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Abstractions;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Modules.GreatWall.Application.Dtos.Extensions;
using KissU.Modules.GreatWall.Application.Queries;
using KissU.Modules.GreatWall.Data.Pos;
using KissU.Modules.GreatWall.Data.Stores.Abstractions;
using KissU.Modules.GreatWall.Domain.Repositories;
using KissU.Util;
using KissU.Util.Applications;
using KissU.Util.Datas.Queries;
using KissU.Util.Domains.Repositories;

namespace KissU.Modules.GreatWall.Application.Implements
{
    /// <summary>
    /// 应用程序查询服务
    /// </summary>
    public class QueryApplicationAppService : QueryServiceBase<ApplicationPo, ApplicationDto, ApplicationQuery>,
        IQueryApplicationAppService
    {
        /// <summary>
        /// 初始化应用程序查询服务
        /// </summary>
        /// <param name="applicationPoStore">应用程序存储器</param>
        /// <param name="applicationRepository">应用程序仓储</param>
        public QueryApplicationAppService(IApplicationPoStore applicationPoStore,
            IApplicationRepository applicationRepository) :
            base(applicationPoStore)
        {
            ApplicationStore = applicationPoStore;
            ApplicationRepository = applicationRepository;
        }

        /// <summary>
        /// 应用程序存储
        /// </summary>
        public IApplicationPoStore ApplicationStore { get; set; }

        /// <summary>
        /// 应用程序仓储
        /// </summary>
        public IApplicationRepository ApplicationRepository { get; set; }

        /// <summary>
        /// 通过应用程序编码查找
        /// </summary>
        /// <param name="code">应用程序编码</param>
        /// <returns>Task&lt;ApplicationDto&gt;.</returns>
        public async Task<ApplicationDto> GetByCodeAsync(string code)
        {
            var application = await ApplicationStore.SingleAsync(t => t.Code == code);
            return application.ToDto();
        }

        /// <summary>
        /// 转成参数
        /// </summary>
        /// <param name="po">The po.</param>
        /// <returns>ApplicationDto.</returns>
        protected override ApplicationDto ToDto(ApplicationPo po)
        {
            return po.ToDto();
        }

        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="query">查询参数</param>
        /// <returns>IQueryBase&lt;ApplicationPo&gt;.</returns>
        protected override IQueryBase<ApplicationPo> CreateQuery(ApplicationQuery query)
        {
            return new Query<ApplicationPo>(query)
                .WhereIfNotEmpty(t => t.Code.Contains(query.Code))
                .WhereIfNotEmpty(t => t.Name.Contains(query.Name))
                .WhereIfNotEmpty(t => t.Remark.Contains(query.Remark));
        }
    }
}