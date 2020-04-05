using System;
using System.Threading.Tasks;
using KissU.Core.Aspects;

namespace KissU.Util.Ddd.Datas.UnitOfWorks
{
    /// <summary>
    /// 工作单元
    /// </summary>
    [Ignore]
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 提交,返回影响的行数
        /// </summary>
        /// <returns>System.Int32.</returns>
        int Commit();

        /// <summary>
        /// 提交,返回影响的行数
        /// </summary>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        Task<int> CommitAsync();
    }
}