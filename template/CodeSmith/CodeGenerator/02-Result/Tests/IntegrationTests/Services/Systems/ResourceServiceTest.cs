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
    /// 资源服务测试
    /// </summary>
    [Collection( "GlobalConfig" )]
    public class ResourceServiceTest : IDisposable {
        /// <summary>
        /// 容器作用域
        /// </summary>
        private readonly IScope _scope;
        /// <summary>
        /// 资源服务
        /// </summary>
        private readonly IResourceService _resourceService;
        /// <summary>
        /// 资源仓储
        /// </summary>
        private readonly IResourceRepository _resourceRepository;
        /// <summary>
        /// 资源Dto
        /// </summary>
        private readonly ResourceDto _resourceDto;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ResourceServiceTest() {
            _scope = Ioc.BeginScope();
            _resourceRepository = _scope.Create<IResourceRepository>();
            _resourceService = _scope.Create<IResourceService>();
            _resourceDto = ResourceDtoTest.Create();
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
            var count = _resourceRepository.Count();
            _resourceService.Save( _resourceDto );
            Assert.Equal( count + 1, _resourceRepository.Count() );
        }
    }
}