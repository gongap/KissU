using System;
using System.Collections.Generic;
using Xunit;
using Util;
using Util.Helpers;
using Util.Dependency;
using GreatWall.Systems.Domain.Models;
using GreatWall.Systems.Domain.Repositories;
using GreatWall.Service.Abstractions.Systems;
using GreatWall.Service.Dtos.Systems;
using GreatWall.Test.Integration.Dtos.Systems;

namespace GreatWall.Test.Integration.Services.Systems {
    /// <summary>
    /// 角色服务测试
    /// </summary>
    [Collection( "GlobalConfig" )]
    public class RoleServiceTest : IDisposable {
        /// <summary>
        /// 容器作用域
        /// </summary>
        private readonly IScope _scope;
        /// <summary>
        /// 角色服务
        /// </summary>
        private readonly IRoleService _roleService;
        /// <summary>
        /// 角色仓储
        /// </summary>
        private readonly IRoleRepository _roleRepository;
        /// <summary>
        /// 角色Dto
        /// </summary>
        private readonly RoleDto _roleDto;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public RoleServiceTest() {
            _scope = Ioc.BeginScope();
            _roleRepository = _scope.Create<IRoleRepository>();
            _roleService = _scope.Create<IRoleService>();
            _roleDto = RoleDtoTest.Create();
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
            var count = _roleRepository.Count();
            _roleService.Save( _roleDto );
            Assert.Equal( count + 1, _roleRepository.Count() );
        }
    }
}