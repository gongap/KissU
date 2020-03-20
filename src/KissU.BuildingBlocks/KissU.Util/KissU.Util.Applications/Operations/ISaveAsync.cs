using System.Threading.Tasks;
using KissU.Core.Applications.Dtos;
using KissU.Core.Validations.Aspects;
using KissU.Util.Applications.Aspects;

namespace KissU.Util.Applications.Operations
{
    /// <summary>
    /// 保存操作
    /// </summary>
    /// <typeparam name="TRequest">参数类型</typeparam>
    public interface ISaveAsync<in TRequest> where TRequest : IRequest, IKey, new()
    {
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="request">参数</param>
        /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
        [UnitOfWork]
        Task SaveAsync([Valid] TRequest request);
    }
}