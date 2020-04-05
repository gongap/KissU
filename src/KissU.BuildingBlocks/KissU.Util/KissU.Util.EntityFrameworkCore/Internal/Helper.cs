using System;
using System.Text;
using KissU.Util.Ddd.Domains;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace KissU.Util.EntityFrameworkCore.Internal
{
    /// <summary>
    /// 工具操作
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// 初始化版本号
        /// </summary>
        /// <param name="entry">The entry.</param>
        public static void InitVersion(EntityEntry entry)
        {
            if (!(entry.Entity is IVersion entity))
                return;
            entity.Version = Encoding.UTF8.GetBytes(Guid.NewGuid().ToString());
        }
    }
}