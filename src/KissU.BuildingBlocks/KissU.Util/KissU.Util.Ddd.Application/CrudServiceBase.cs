using System;
using KissU.Core.Datas.Queries;
using KissU.Core.Datas.UnitOfWorks;
using KissU.Core.Maps;
using KissU.Util.Ddd.Application.Contracts;
using KissU.Util.Ddd.Application.Contracts.Aspects;
using KissU.Util.Ddd.Application.Contracts.Dtos;
using KissU.Util.Ddd.Domain;
using KissU.Util.Ddd.Domain.Datas.Repositories;
using Convert = KissU.Core.Helpers.Convert;

namespace KissU.Util.Ddd.Application
{
    /// <summary>
    /// 增删改查服务
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQueryParameter">查询参数类型</typeparam>
    public abstract class CrudServiceBase<TEntity, TDto, TQueryParameter>
        : CrudServiceBase<TEntity, TDto, TDto, TDto, TDto, TQueryParameter, Guid>, ICrudService<TDto, TQueryParameter>
        where TEntity : class, IAggregateRoot<TEntity, Guid>, new()
        where TDto : IDto, new()
        where TQueryParameter : IQueryParameter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CrudServiceBase{TEntity, TDto, TQueryParameter}" /> class.
        /// 初始化增删改查服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="repository">仓储</param>
        protected CrudServiceBase(IUnitOfWork unitOfWork, IRepository<TEntity, Guid> repository)
            : base(unitOfWork, repository)
        {
        }
    }

    /// <summary>
    /// 增删改查服务
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQueryParameter">查询参数类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public abstract class CrudServiceBase<TEntity, TDto, TQueryParameter, TKey>
        : CrudServiceBase<TEntity, TDto, TDto, TQueryParameter, TKey>, ICrudService<TDto, TQueryParameter>
        where TEntity : class, IAggregateRoot<TEntity, TKey>, new()
        where TDto : IDto, new()
        where TQueryParameter : IQueryParameter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CrudServiceBase{TEntity, TDto, TQueryParameter, TKey}" /> class.
        /// 初始化增删改查服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="repository">仓储</param>
        protected CrudServiceBase(IUnitOfWork unitOfWork, IRepository<TEntity, TKey> repository)
            : base(unitOfWork, repository)
        {
        }
    }

    /// <summary>
    /// 增删改查服务
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TRequest">参数类型</typeparam>
    /// <typeparam name="TQueryParameter">查询参数类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public abstract class CrudServiceBase<TEntity, TDto, TRequest, TQueryParameter, TKey>
        : CrudServiceBase<TEntity, TDto, TRequest, TRequest, TRequest, TQueryParameter, TKey>,
            ICrudService<TDto, TRequest, TQueryParameter>
        where TEntity : class, IAggregateRoot<TEntity, TKey>, new()
        where TDto : IDto, new()
        where TRequest : IRequest, IKey, new()
        where TQueryParameter : IQueryParameter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CrudServiceBase{TEntity, TDto, TRequest, TQueryParameter, TKey}" />
        /// class.
        /// 初始化增删改查服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="repository">仓储</param>
        protected CrudServiceBase(IUnitOfWork unitOfWork, IRepository<TEntity, TKey> repository)
            : base(unitOfWork, repository)
        {
        }
    }

    /// <summary>
    /// 增删改查服务
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TRequest">参数类型</typeparam>
    /// <typeparam name="TCreateRequest">创建参数类型</typeparam>
    /// <typeparam name="TUpdateRequest">修改参数类型</typeparam>
    /// <typeparam name="TQueryParameter">查询参数类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public abstract partial class CrudServiceBase<TEntity, TDto, TRequest, TCreateRequest, TUpdateRequest,
            TQueryParameter, TKey>
        : DeleteServiceBase<TEntity, TDto, TQueryParameter, TKey>,
            ICrudService<TDto, TRequest, TCreateRequest, TUpdateRequest, TQueryParameter>, ICommitAfter
        where TEntity : class, IAggregateRoot<TEntity, TKey>, new()
        where TDto : IDto, new()
        where TRequest : IRequest, IKey, new()
        where TCreateRequest : IRequest, new()
        where TUpdateRequest : IRequest, new()
        where TQueryParameter : IQueryParameter
    {
        /// <summary>
        /// 仓储
        /// </summary>
        private readonly IRepository<TEntity, TKey> _repository;

        /// <summary>
        /// 工作单元
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CrudServiceBase{TEntity, TDto, TRequest, TCreateRequest, TUpdateRequest, TQueryParameter, TKey}" /> class.
        /// 初始化增删改查服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="repository">仓储</param>
        protected CrudServiceBase(IUnitOfWork unitOfWork, IRepository<TEntity, TKey> repository)
            : base(unitOfWork, repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="request">参数</param>
        /// <returns>结果</returns>
        protected virtual TEntity ToEntity(TRequest request)
        {
            return request.MapTo<TEntity>();
        }

        /// <summary>
        /// 创建参数转换为实体
        /// </summary>
        /// <param name="request">创建参数</param>
        /// <returns>结果</returns>
        protected virtual TEntity ToEntityFromCreateRequest(TCreateRequest request)
        {
            if (typeof(TCreateRequest) == typeof(TRequest))
            {
                return ToEntity(Convert.To<TRequest>(request));
            }

            return request.MapTo<TEntity>();
        }

        /// <summary>
        /// 修改参数转换为实体
        /// </summary>
        /// <param name="request">修改参数</param>
        /// <returns>结果</returns>
        protected virtual TEntity ToEntityFromUpdateRequest(TUpdateRequest request)
        {
            if (typeof(TUpdateRequest) == typeof(TRequest))
            {
                return ToEntity(Convert.To<TRequest>(request));
            }

            return request.MapTo<TEntity>();
        }

        /// <summary>
        /// 参数转换为实体
        /// </summary>
        /// <param name="request">创建参数</param>
        /// <returns>结果</returns>
        protected virtual TEntity ToEntityFromDto(TDto request)
        {
            if (typeof(TDto) == typeof(TRequest))
            {
                return ToEntity(Convert.To<TRequest>(request));
            }

            return request.MapTo<TEntity>();
        }
    }
}