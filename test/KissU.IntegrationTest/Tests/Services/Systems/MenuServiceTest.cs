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

namespace KissU.IntegrationTest.Tests.Services.Systems {
    /// <summary>
    /// 菜单服务测试
    /// </summary>
    [Collection( "GlobalConfig" )]
    public class MenuServiceTest : IDisposable {
        /// <summary>
        /// 容器作用域
        /// </summary>
        private readonly IScope _scope;
        /// <summary>
        /// 菜单服务
        /// </summary>
        private readonly IMenuService _menuService;
        /// <summary>
        /// 菜单仓储
        /// </summary>
        private readonly IMenuRepository _menuRepository;
        /// <summary>
        /// 菜单Dto
        /// </summary>
        private readonly MenuDto _menuDto;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public MenuServiceTest() {
            _scope = Ioc.BeginScope();
            _menuRepository = _scope.Create<IMenuRepository>();
            _menuService = _scope.Create<IMenuService>();
            _menuDto = MenuDtoTest.Create();
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
            var count = _menuRepository.Count();
            Assert.Equal( count + 1, _menuRepository.Count() );
        }
    }
}