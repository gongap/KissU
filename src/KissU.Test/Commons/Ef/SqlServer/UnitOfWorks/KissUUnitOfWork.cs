using KissU.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Util.Aspects;
using Util.Datas.Tests.Commons.Datas.SqlServer.Configs;
using Util.Datas.UnitOfWorks;
using Util.Reflections;

namespace Util.Datas.Tests.Ef.SqlServer.UnitOfWorks {
    /// <summary>
    /// SqlServer工作单元
    /// </summary>
    [Ignore]
    public class KissUUnitOfWork : Util.Datas.Ef.SqlServer.UnitOfWork, IKissUUnitOfWork
    {
        /// <summary>
        /// 类型查找器
        /// </summary>
        private readonly IFind _finder;

        /// <summary>
        /// 初始化SqlServer工作单元
        /// </summary>
        public KissUUnitOfWork() : base(new DbContextOptionsBuilder().UseSqlServer(AppConfig.Connection).Options)
        {
            _finder = new Finder();
        }

        /// <summary>
        /// 获取定义映射配置的程序集列表
        /// </summary>
        protected override Assembly[] GetAssemblies()
        {
            return _finder.GetAssemblies().ToArray();
        }
    }
}