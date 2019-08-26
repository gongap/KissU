using KissU.Data;
using Microsoft.EntityFrameworkCore;

namespace KissU.Modules.Admin.Data.UnitOfWorks.SqlServer
{
    /// <summary>
    /// SqlServer工作单元
    /// </summary>
    public class AdminUnitOfWork : Util.Datas.Ef.SqlServer.UnitOfWork, IAdminUnitOfWork
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