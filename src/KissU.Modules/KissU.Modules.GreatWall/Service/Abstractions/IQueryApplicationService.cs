using System.Threading.Tasks;
using GreatWall.Service.Dtos;
using GreatWall.Service.Queries;
using Util.Applications;

namespace GreatWall.Service.Abstractions {
    /// <summary>
    /// 应用程序查询服务
    /// </summary>
    public interface IQueryApplicationService : IQueryService<ApplicationDto, ApplicationQuery> {
        /// <summary>
        /// 通过应用程序编码查找
        /// </summary>
        /// <param name="code">应用程序编码</param>
        Task<ApplicationDto> GetByCodeAsync( string code );
    }
}