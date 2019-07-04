using System;
using Microsoft.EntityFrameworkCore;
using Util.Datas.UnitOfWorks;

namespace KFNets.Veterinary.Data.UnitOfWorks.MySql 
{
    /// <summary>
    /// 工作单元
    /// </summary>
    public class KFNetsUnitOfWork : Util.Datas.Ef.MySql.UnitOfWork,IKFNetsUnitOfWork 
	{
        /// <summary>
        /// 初始化工作单元
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="serviceProvider">服务提供器</param>
        public KFNetsUnitOfWork( DbContextOptions options, IServiceProvider serviceProvider) : base( options, serviceProvider ) 
		{
        }
    }
}