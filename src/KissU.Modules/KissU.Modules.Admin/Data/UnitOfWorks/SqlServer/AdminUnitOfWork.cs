using Microsoft.EntityFrameworkCore;
using Util.Datas.Ef.SqlServer;

namespace KissU.Modules.Admin.Data.UnitOfWorks.SqlServer
{
    /// <summary>
    /// SqlServer工作单元
    /// </summary>
    public class AdminUnitOfWork : UnitOfWork, IAdminUnitOfWork
    {
        /// <summary>
        /// 初始化工作单元
        /// </summary>
        /// <param name="options">配置项</param>
        public AdminUnitOfWork(DbContextOptions<AdminUnitOfWork> options) : base(options)
        {
        }
    }
}