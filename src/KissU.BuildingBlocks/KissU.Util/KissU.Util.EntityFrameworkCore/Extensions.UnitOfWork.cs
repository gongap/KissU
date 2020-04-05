using System.Linq;
using KissU.Util.Ddd.Datas.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace KissU.Util.EntityFrameworkCore
{
    /// <summary>
    /// Ef工作单元扩展
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 清空缓存
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public static void ClearCache(this IUnitOfWork unitOfWork)
        {
            var dbContext = unitOfWork as DbContext;
            dbContext?.ChangeTracker.Entries().ToList().ForEach(entry => entry.State = EntityState.Detached);
        }
    }
}