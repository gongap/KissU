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
    /// 应用程序服务测试
    /// </summary>
    [Collection( "GlobalConfig" )]
    public class ApplicationServiceTest : IDisposable {
        /// <summary>
        /// 容器作用域
        /// </summary>
        private readonly IScope _scope;
        /// <summary>
        /// 应用程序服务
        /// </summary>
        private readonly IApplicationService _applicationService;
        /// <summary>
        /// 应用程序仓储
        /// </summary>
        private readonly IApplicationRepository _applicationRepository;
        /// <summary>
        /// 应用程序Dto
        /// </summary>
        private readonly ApplicationDto _applicationDto;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ApplicationServiceTest() {
            _scope = Ioc.BeginScope();
            _applicationRepository = _scope.Create<IApplicationRepository>();
            _applicationService = _scope.Create<IApplicationService>();
            _applicationDto = ApplicationDtoTest.Create();
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
            var count = _applicationRepository.Count();
            _applicationService.Save( _applicationDto );
            Assert.Equal( count + 1, _applicationRepository.Count() );
        }
    }
}