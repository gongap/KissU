using KissU.Core.Applications.Dtos;
using KissU.Core.Validations.Aspects;
using KissU.Util.Applications.Aspects;

namespace KissU.Util.Applications.Operations
{
    /// <summary>
    /// 创建操作
    /// </summary>
    /// <typeparam name="TCreateRequest">创建参数类型</typeparam>
    public interface ICreate<in TCreateRequest> where TCreateRequest : IRequest, new()
    {
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">创建参数</param>
        /// <returns>结果</returns>
        [UnitOfWork]
        string Create([Valid] TCreateRequest request);
    }
}