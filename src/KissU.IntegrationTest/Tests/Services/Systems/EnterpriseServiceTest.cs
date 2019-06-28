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
    /// 企业服务测试
    /// </summary>
    [Collection( "GlobalConfig" )]
    public class EnterpriseServiceTest : IDisposable 
	{
        /// <summary>
        /// 容器作用域
        /// </summary>
        private readonly IScope _scope;
        /// <summary>
        /// 企业服务
        /// </summary>
        private readonly IEnterpriseService _enterpriseService;
        /// <summary>
        /// 企业仓储
        /// </summary>
        private readonly IEnterpriseRepository _enterpriseRepository;
        /// <summary>
        /// 企业Dto
        /// </summary>
        private readonly EnterpriseDto _enterpriseDto;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public EnterpriseServiceTest() 
		{
            _scope = Ioc.BeginScope();
            _enterpriseRepository = _scope.Create<IEnterpriseRepository>();
            _enterpriseService = _scope.Create<IEnterpriseService>();
            _enterpriseDto = EnterpriseDtoTest.Create();
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
		    var count = _enterpriseRepository.Count();
			_enterpriseRepository.Add( _enterpriseDto.ToEntity());
            Assert.Equal( count + 1, _enterpriseRepository.Count() );
        }
    }
}