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
    /// 菜单服务
    /// </summary>
    public interface IMenuService : ITreeService<MenuDto, MenuQuery> 
	{
	    /// <summary>
        /// 创建菜单
        /// </summary>
        /// <param name="request">创建请求参数</param>
        [UnitOfWork]
        Task<Guid> CreateAsync([NotNull] [Valid] MenuDto request);
        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="request">修改请求参数</param>
        [UnitOfWork]
        Task UpdateAsync([NotNull] [Valid] MenuDto request);
    }
}