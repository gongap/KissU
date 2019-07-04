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
    /// Api许可范围服务测试
    /// </summary>
    [Collection( "GlobalConfig" )]
    public class ApiScopeServiceTest : IDisposable {
        /// <summary>
        /// 容器作用域
        /// </summary>
        private readonly IScope _scope;
        /// <summary>
        /// Api许可范围服务
        /// </summary>
        private readonly IApiScopeService _apiScopeService;
        /// <summary>
        /// Api许可范围仓储
        /// </summary>
        private readonly IApiScopeRepository _apiScopeRepository;
        /// <summary>
        /// Api许可范围Dto
        /// </summary>
        private readonly ApiScopeDto _apiScopeDto;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ApiScopeServiceTest() {
            _scope = Ioc.BeginScope();
            _apiScopeRepository = _scope.Create<IApiScopeRepository>();
            _apiScopeService = _scope.Create<IApiScopeService>();
            _apiScopeDto = ApiScopeDtoTest.Create();
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
            var count = _apiScopeRepository.Count();
            _apiScopeService.Save( _apiScopeDto );
            Assert.Equal( count + 1, _apiScopeRepository.Count() );
        }
    }
}