using System;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Abstractions;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Modules.GreatWall.Application.Dtos.Extensions;
using KissU.Modules.GreatWall.Data;
using KissU.Modules.GreatWall.Domain;
using KissU.Modules.GreatWall.Domain.Models;
using KissU.Modules.GreatWall.Domain.Repositories;
using KissU.Modules.GreatWall.Domain.Shared;
using KissU.Modules.GreatWall.Domain.UnitOfWorks;
using KissU.Util;
using KissU.Util.Applications;
using KissU.Util.Exceptions;

namespace KissU.Modules.GreatWall.Application.Implements
{
    /// <summary>
    /// Api资源服务
    /// </summary>
    public class ApiResourceAppService : ServiceBase, IApiResourceAppService
    {
        /// <summary>
        /// 初始化Api资源服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="apiResourceRepository">Api资源仓储</param>
        public ApiResourceAppService(IGreatWallUnitOfWork unitOfWork, IApiResourceRepository apiResourceRepository)
        {
            UnitOfWork = unitOfWork;
            ApiResourceRepository = apiResourceRepository;
        }

        /// <summary>
        /// 工作单元
        /// </summary>
        public IGreatWallUnitOfWork UnitOfWork { get; set; }

        /// <summary>
        /// Api资源仓储
        /// </summary>
        public IApiResourceRepository ApiResourceRepository { get; set; }

        /// <summary>
        /// 创建Api资源
        /// </summary>
        /// <param name="dto">Api资源参数</param>
        public async Task<Guid> CreateAsync(ApiResourceDto dto)
        {
            var entity = dto.ToEntity();
            await ValidateCreateAsync(entity);
            entity.Init();
            await ApiResourceRepository.AddAsync(entity);
            await UnitOfWork.CommitAsync();
            return entity.Id;
        }

        /// <summary>
        /// 修改Api资源
        /// </summary>
        /// <param name="dto">Api资源参数</param>
        public async Task UpdateAsync(ApiResourceDto dto)
        {
            var entity = dto.ToEntity();
            await ValidateUpdateAsync(entity);
            await ApiResourceRepository.UpdateAsync(entity);
            await UnitOfWork.CommitAsync();
        }

        /// <summary>
        /// 删除Api资源
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        public async Task DeleteAsync(string ids)
        {
            if (string.IsNullOrWhiteSpace(ids))
                return;
            var entities = await ApiResourceRepository.FindByIdsAsync(ids);
            if (entities?.Count == 0)
                return;
            await ApiResourceRepository.RemoveAsync(entities);
            await UnitOfWork.CommitAsync();
        }

        /// <summary>
        /// 验证创建Api资源
        /// </summary>
        private async Task ValidateCreateAsync(ApiResource entity)
        {
            entity.CheckNull(nameof(entity));
            if (await ApiResourceRepository.CanCreateAsync(entity) == false)
                ThrowUriRepeatException(entity);
        }

        /// <summary>
        /// 抛出资源标识重复异常
        /// </summary>
        private void ThrowUriRepeatException(ApiResource identityResource)
        {
            throw new Warning(string.Format(GreatWallResource.DuplicateUri, identityResource.Uri));
        }

        /// <summary>
        /// 验证修改Api资源
        /// </summary>
        private async Task ValidateUpdateAsync(ApiResource entity)
        {
            entity.CheckNull(nameof(entity));
            if (await ApiResourceRepository.CanUpdateAsync(entity) == false)
                ThrowUriRepeatException(entity);
        }
    }
}