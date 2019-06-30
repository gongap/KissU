﻿using Util.Webs.Controllers;
using KissU.Service.Dtos.Systems;
using KissU.Service.Queries.Systems;
using KissU.Service.Abstractions.Systems;

namespace KissU.Web.Apis.Systems 
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    public class UserController : CrudControllerBase<UserDto, UserQuery> 
	{
        
        /// <summary>
        /// 初始化用户控制器
        /// </summary>
		/// <param name="service">用户服务</param>
        public UserController( IUserService service ) : base( service ) 
		{
            UserService = service;
        }

        /// <summary>
        /// 用户服务
        /// </summary>
        public IUserService UserService { get; }
    }
}