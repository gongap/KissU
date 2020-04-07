using KissU.Core.Datas.Queries;
using KissU.Util.Ddd.Application.Contracts.Operations;

namespace KissU.Util.Ddd.Application.Contracts
{
    /// <summary>
    /// 查询服务
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQueryParameter">查询参数类型</typeparam>
    public interface IQueryService<TDto, in TQueryParameter> : IService,
        IGetById<TDto>, IGetByIdAsync<TDto>,
        IGetAll<TDto>, IGetAllAsync<TDto>,
        IPageQuery<TDto, TQueryParameter>, IPageQueryAsync<TDto, TQueryParameter>
        where TDto : new()
        where TQueryParameter : IQueryParameter
    {
    }
}