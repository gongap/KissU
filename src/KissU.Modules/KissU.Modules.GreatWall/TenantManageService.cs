using Surging.Core.ProxyGenerator;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using System;
using System.Linq;
using Util;
using Util.Maps;
using Util.Domains.Repositories;
using Util.Datas.Queries;
using Util.Datas.Ef;
using KissU.IModuleServices.QuickStart;
using KissU.IModuleServices.QuickStart.Dtos;
using KissU.IModuleServices.QuickStart.Queries;
using KissU.Modules.QuickStart.Infrastructure;
using KissU.Modules.QuickStart.Domain.Models;
using KissU.Modules.QuickStart.Domain.Repositories;

namespace KissU.Modules.QuickStart.Application.Implements.Systems
{
    /// <summary>
    /// 租户服务
    /// </summary>
    public class TenantManageService : ProxyServiceBase, ITenantManageService
    {
        /// <summary>
        /// 初始化租户服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="clientRepository">租户仓储</param>
        public TenantManageService(IQuickStartUnitOfWork unitOfWork, ITenantRepository clientRepository)
        {
            UnitOfWork = unitOfWork;
            UserRepository = clientRepository;
        }

        /// <summary>
        /// 工作单元
        /// </summary>
        public IQuickStartUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// 租户仓储
        /// </summary>
        public ITenantRepository UserRepository { get; set; }

        /// <summary>
        /// 获取全部
        /// </summary>
        public async Task<List<TenantDto>> GetAll()
        {
            var entities = await UserRepository.FindAllAsync();
            return entities.Select(ToDto).ToList();
        }

        /// <summary>
        /// 通过编号获取
        /// </summary>
        /// <param name="id">实体编号</param>
        public async Task<TenantDto> GetById(string id)
        {
            var key = Util.Helpers.Convert.To<Guid>(id);
            return ToDto(await UserRepository.FindAsync(key));
        }

        /// <summary>
        /// 通过编号列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        public async Task<List<TenantDto>> GetByIds(string ids)
        {
            var entities = await UserRepository.FindByIdsAsync(ids);
            return entities.Select(ToDto).ToList();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        public async Task<List<TenantDto>> Query(TenantQuery parameter)
        {
            if (parameter == null)
                return new List<TenantDto>();
            return (await ExecuteQuery(parameter).ToListAsync()).Select(ToDto).ToList();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        public async Task<PagerList<TenantDto>> PagerQuery(TenantQuery parameter)
        {
            if (parameter == null)
                return new PagerList<TenantDto>();
            var query = CreateQuery(parameter);
            var queryable = Filter(query);
            queryable = Filter(queryable, parameter);
            return (await queryable.ToPagerListAsync(query.GetPager())).Convert(ToDto);
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">创建参数</param>
        public async Task<string> Create(TenantCreateRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            var entity = ToEntityFromCreateRequest(request);
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            entity.Init();
            await UserRepository.AddAsync(entity);
            await UnitOfWork.CommitAsync();
            Publish(new TenantEvent() { TenantId = entity.Id.ToString(), Code = entity.Code, Name = entity.Name });
            return entity.Id.ToString();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">修改参数</param>
        public async Task Update(TenantUpdateRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            var entity = ToEntityFromUpdateRequest(request);
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            var oldEntity = await UserRepository.FindAsync(entity.Id);
            if (oldEntity == null)
                throw new ArgumentNullException(nameof(oldEntity));
            var changes = oldEntity.GetChanges(entity);
            await UserRepository.UpdateAsync(entity);
            await UnitOfWork.CommitAsync();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        public async Task Delete(string ids)
        {
            if (string.IsNullOrWhiteSpace(ids))
                return;
            var entities = await UserRepository.FindByIdsAsync(ids);
            if (entities?.Count == 0)
                return;
            await UserRepository.RemoveAsync(entities);
            await UnitOfWork.CommitAsync();
        }

        #region 私有方法
        /// <summary>
        /// 查询时是否跟踪对象
        /// </summary>
        private bool IsTracking => false;

        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="request">参数</param>
        private Tenant ToEntity(TenantDto request)
        {
            return request.MapTo<Tenant>();
        }

        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        private TenantDto ToDto(Tenant entity)
        {
            return entity.MapTo<TenantDto>();
        }

        /// <summary>
        /// 创建参数转换为实体
        /// </summary>
        /// <param name="request">创建参数</param>
        protected virtual Tenant ToEntityFromCreateRequest(TenantCreateRequest request)
        {
            return request.MapTo<Tenant>();
        }

        /// <summary>
        /// 修改参数转换为实体
        /// </summary>
        /// <param name="request">修改参数</param>
        protected virtual Tenant ToEntityFromUpdateRequest(TenantUpdateRequest request)
        {
            return request.MapTo<Tenant>();
        }

        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="parameter">查询参数</param>
        private IQueryBase<Tenant> CreateQuery(TenantQuery parameter)
        {
            var query = new Query<Tenant>(parameter)
                .Or(t => t.Code == parameter.Code)
                .Or(t => t.Code.Contains(parameter.Keyword), t => t.Name.Contains(parameter.Keyword));
            if (parameter.Enabled.HasValue)
            {
                query.And(t => t.Enabled == parameter.Enabled.Value);
            }
            return query;
        }

        /// <summary>
        /// 执行查询
        /// </summary>
        private IQueryable<Tenant> ExecuteQuery(TenantQuery parameter)
        {
            var query = CreateQuery(parameter);
            var queryable = Filter(query);
            queryable = Filter(queryable, parameter);
            var order = query.GetOrder();
            return string.IsNullOrWhiteSpace(order) ? queryable : queryable.OrderBy(order);
        }

        /// <summary>
        /// 过滤
        /// </summary>
        private IQueryable<Tenant> Filter(IQueryBase<Tenant> query)
        {
            return IsTracking ? UserRepository.Find().Where(query) : UserRepository.FindAsNoTracking().Where(query);
        }

        /// <summary>
        /// 过滤
        /// </summary>
        private IQueryable<Tenant> Filter(IQueryable<Tenant> queryable, TenantQuery parameter)
        {
            return queryable;
        }
        #endregion
    }
}