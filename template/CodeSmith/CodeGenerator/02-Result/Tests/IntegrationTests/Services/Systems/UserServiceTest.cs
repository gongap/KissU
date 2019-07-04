using System;
using System.Collections.Generic;
using Xunit;
using Util;
using Util.Helpers;
using Util.Dependency;
using KissU.GreatWall.Systems.Domain.Models;
using KissU.GreatWall.Systems.Domain.Repositories;
using KissU.GreatWall.Service.Abstractions.Systems;
using KissU.GreatWall.Service.Dtos.Systems;
using KissU.GreatWall.Test.Integration.Dtos.Systems;

namespace KissU.GreatWall.Test.Integration.Services.Systems {
    /// <summary>
    /// 用户服务测试
    /// </summary>
    [Collection( "GlobalConfig" )]
    public class UserServiceTest : IDisposable {
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
        public UserServiceTest() {
            _scope = Ioc.BeginScope();
            _userRepository = _scope.Create<IUserRepository>();
            _userService = _scope.Create<IUserService>();
            _userDto = UserDtoTest.Create();
        }
        
        /// <summary>
        /// 测试清理
        /// </summary>
        public void Dispose() {
            _scope.Dispose();
        }
        
        /// <summary>
        /// 测试
        /// </summary>
        [Fact]
        public void Test() {
            var count = _userRepository.Count();
            _userService.Save( _userDto );
            Assert.Equal( count + 1, _userRepository.Count() );
        }
    }
}