using KissU.Modules.IdentityServer.Domain;
using KissU.Modules.IdentityServer.Domain.UnitOfWorks;
using KissU.Util.Datas.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;

namespace KissU.Modules.IdentityServer.Data.UnitOfWorks.SqlServer
{
    /// <summary>
    /// 工作单元
    /// </summary>
    public class IdentityServerUnitOfWork : UnitOfWork, IIdentityServerUnitOfWork
    {
        /// <summary>
        /// 初始化工作单元
        /// </summary>
        /// <param name="options">配置项</param>
        public IdentityServerUnitOfWork(DbContextOptions<IdentityServerUnitOfWork> options) : base(options)
        {
        }
    }
}