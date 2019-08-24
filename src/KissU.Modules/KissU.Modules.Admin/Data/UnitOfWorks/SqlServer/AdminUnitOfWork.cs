using System;
using Microsoft.EntityFrameworkCore;
using Util.Datas.UnitOfWorks;

namespace KissU.Data.UnitOfWorks.SqlServer 
{
    /// <summary>
    /// 工作单元
    /// </summary>
    public class AdminUnitOfWork : Util.Datas.Ef.SqlServer.UnitOfWork,IAdminUnitOfWork 
	{
        /// <summary>
        /// 初始化工作单元
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="serviceProvider">服务提供器</param>
        public AdminUnitOfWork( DbContextOptions options, IServiceProvider serviceProvider ) : base( options, serviceProvider ) 
		{
        }
    }
}