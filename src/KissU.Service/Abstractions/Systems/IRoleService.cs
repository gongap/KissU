using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using Util.Applications.Aspects;
using Util.Validations.Aspects;
using Util.Applications.Trees;
using KissU.Service.Dtos.Systems;
using KissU.Service.Queries.Systems;

namespace KissU.Service.Abstractions.Systems 
{
    /// <summary>
    /// 角色服务
    /// </summary>
    public interface IRoleService : ITreeService<RoleDto, RoleQuery> 
	{
	    /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="request">创建请求参数</param>
        [UnitOfWork]
        Task<Guid> CreateAsync([NotNull] [Valid] RoleDto request);
        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="request">修改请求参数</param>
        [UnitOfWork]
        Task UpdateAsync([NotNull] [Valid] RoleDto request);
    }
}