using System.Threading.Tasks;
using KissU.Core.Applications;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Modules.GreatWall.Application.Queries;
using KissU.Util.Applications;

namespace KissU.Modules.GreatWall.Application.Abstractions
{
    /// <summary>
    /// 应用程序查询服务
    /// </summary>
    public interface IQueryApplicationAppService : IQueryService<ApplicationDto, ApplicationQuery>
    {
        /// <summary>
        /// 通过应用程序编码查找
        /// </summary>
        /// <param name="code">应用程序编码</param>
        /// <returns>Task&lt;ApplicationDto&gt;.</returns>
        Task<ApplicationDto> GetByCodeAsync(string code);
    }
}