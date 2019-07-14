using Microsoft.EntityFrameworkCore;
using System;

namespace KissU.Modules.QuickStart.Infrastructure.UnitOfWorks.SqlServer {
    /// <summary>
    /// 工作单元
    /// </summary>
    public class QuickStartUnitOfWork : Util.Datas.Ef.SqlServer.UnitOfWork, IQuickStartUnitOfWork
    {
        /// <summary>
        /// 初始化工作单元
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="serviceProvider">服务提供器</param>
        public QuickStartUnitOfWork( DbContextOptions<QuickStartUnitOfWork> options, IServiceProvider serviceProvider) : base( options, serviceProvider) {
        }
    }
}