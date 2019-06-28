using System;
using System.Collections.Generic;
using Xunit;
using Util;
using Util.Helpers;
using Util.Dependency;
using KissU.Domain.Systems.Models;
using KissU.Domain.Systems.Repositories;
using KissU.Service.Abstractions.Systems;
using KissU.Service.Dtos.Systems;
using KissU.IntegrationTest.Tests.Dtos.Systems;
using KissU.Service.Dtos.Systems.Extensions;

namespace KissU.IntegrationTest.Tests.Services.Systems 
{
    /// <summary>
    /// 用户服务测试
    /// </summary>
    [Collection( "GlobalConfig" )]
    public class UserServiceTest : IDisposable 
	{
        /// <summary>
        /// 容器作用域
        /// </summary>
        private readonly IScope _scope;
        /// <summary>
        /// 用户服务
        /// </summary>
        private readonly IUserService _userService;
        /// <summary>
        /// 用户仓储
        /// </summary>
        private readonly IUserRepository _userRepository;
        /// <summary>
        /// 用户Dto
        /// </summary>
        private readonly UserDto _userDto;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public UserServiceTest() 
		{
            _scope = Ioc.BeginScope();
            _userRepository = _scope.Create<IUserRepository>();
            _userService = _scope.Create<IUserService>();
            _userDto = UserDtoTest.Create();
        }
        
        /// <summary>
        /// 测试清理
        /// </summary>
        public void Dispose() 
		{
            _scope.Dispose();
        }
        
        /// <summary>
        /// 测试
        /// </summary>
        [Fact]
        public void Test() 
		{
		    var count = _userRepository.Count();
			_userRepository.Add( _userDto.ToEntity());
            Assert.Equal( count + 1, _userRepository.Count() );
        }
    }
}