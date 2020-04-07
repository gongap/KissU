using System.Threading.Tasks;
using KissU.Core.Validations.Aspects;
using KissU.Util.Ddd.Application.Contracts.Aspects;
using KissU.Util.Ddd.Application.Contracts.Dtos;

namespace KissU.Util.Ddd.Application.Contracts.Operations
{
    /// <summary>
    /// 创建操作
    /// </summary>
    /// <typeparam name="TCreateRequest">创建参数类型</typeparam>
    public interface ICreateAsync<in TCreateRequest> where TCreateRequest : IRequest, new()
    {
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">创建参数</param>
        /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
        [UnitOfWork]
        Task<string> CreateAsync([Valid] TCreateRequest request);
    }
}