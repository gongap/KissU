using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Modules.GreatWall.Application.Queries;
using KissU.Util;
using KissU.Util.Applications;

namespace KissU.Modules.GreatWall.Application.Abstractions {
    /// <summary>
    /// 应用程序查询服务
    /// </summary>
    public interface IQueryApplicationAppService : IQueryService<ApplicationDto, ApplicationQuery> {
        /// <summary>
        /// 通过应用程序编码查找
        /// </summary>
        /// <param name="code">应用程序编码</param>
        Task<ApplicationDto> GetByCodeAsync( string code );
        /// <summary>
        /// 是否允许跨域访问
        /// </summary>
        /// <param name="origin">来源</param>
        Task<bool> IsOriginAllowedAsync( string origin );
        /// <summary>
        /// 获取作用域
        /// </summary>
        Task<List<Item>> GetScopes();
    }
}