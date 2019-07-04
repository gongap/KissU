using System;
using System.Threading.Tasks;
using Util;
using Util.Maps;
using Util.Domains.Repositories;
using Util.Datas.Queries;
using Util.Applications.Trees;
using KFNets.Veterinary.Data;
using KFNets.Veterinary.Domain.Systems.Models;
using KFNets.Veterinary.Domain.Systems.Repositories;
using KFNets.Veterinary.Service.Dtos.Systems;
using KFNets.Veterinary.Service.Queries.Systems;
using KFNets.Veterinary.Service.Abstractions.Systems;

namespace KFNets.Veterinary.Service.Implements.Systems 
{
    /// <summary>
    /// 角色服务
    /// </summary>
    public class RoleService : TreeServiceBase<Role, RoleDto, RoleQuery>, IRoleService 
	{
        /// <summary>
        /// 初始化角色服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="roleRepository">角色仓储</param>
        public RoleService( IKFNetsUnitOfWork unitOfWork, IRoleRepository roleRepository )
            : base( unitOfWork, roleRepository ) 
		{
            RoleRepository = roleRepository;
        }
        
        /// <summary>
        /// 角色仓储
        /// </summary>
        public IRoleRepository RoleRepository { get; set; }
        
        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<Role> CreateQuery( RoleQuery param ) 
		{
            return new Query<Role>( param );
        }

		/// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="request">创建请求参数</param>
        public async Task<Guid> CreateAsync(RoleDto request)
        {
            var role = new Role();
            request.MapTo(role);
            role.Init();
            var parent = await RoleRepository.FindAsync(role.ParentId);
            role.InitPath(parent);
            role.SortId = await RoleRepository.GenerateSortIdAsync(role.ParentId);
            await RoleRepository.AddAsync(role);
            return role.Id;
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="request">修改请求参数</param>
        public async Task UpdateAsync(RoleDto request)
        {
            var role = await RoleRepository.FindAsync(request.Id.ToGuid());
            role.CheckNull(nameof(role));
            request.MapTo(role);
            await RoleRepository.UpdatePathAsync(role);
            await RoleRepository.UpdateAsync(role);
        }
    }
}