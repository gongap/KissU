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
    /// Api资源服务测试
    /// </summary>
    [Collection( "GlobalConfig" )]
    public class ApiServiceTest : IDisposable {
        /// <summary>
        /// 容器作用域
        /// </summary>
        private readonly IScope _scope;
        /// <summary>
        /// Api资源服务
        /// </summary>
        private readonly IApiService _apiService;
        /// <summary>
        /// Api资源仓储
        /// </summary>
        private readonly IApiRepository _apiRepository;
        /// <summary>
        /// Api资源Dto
        /// </summary>
        private readonly ApiDto _apiDto;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ApiServiceTest() {
            _scope = Ioc.BeginScope();
            _apiRepository = _scope.Create<IApiRepository>();
            _apiService = _scope.Create<IApiService>();
            _apiDto = ApiDtoTest.Create();
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
            var count = _apiRepository.Count();
            _apiService.Save( _apiDto );
            Assert.Equal( count + 1, _apiRepository.Count() );
        }
    }
}