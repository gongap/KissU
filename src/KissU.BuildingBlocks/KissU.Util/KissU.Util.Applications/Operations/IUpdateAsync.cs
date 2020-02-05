using System.Threading.Tasks;
using KissU.Util.Applications.Aspects;
using KissU.Util.Applications.Dtos;
using KissU.Util.Validations.Aspects;

namespace KissU.Util.Applications.Operations
{
    /// <summary>
    /// 修改操作
    /// </summary>
    /// <typeparam name="TUpdateRequest">修改参数类型</typeparam>
    public interface IUpdateAsync<in TUpdateRequest> where TUpdateRequest : IRequest, new()
    {
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">修改参数</param>
        /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
        [UnitOfWork]
        Task UpdateAsync([Valid] TUpdateRequest request);
    }
}