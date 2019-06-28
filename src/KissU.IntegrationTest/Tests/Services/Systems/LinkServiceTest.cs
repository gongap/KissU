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
    /// 链接服务测试
    /// </summary>
    [Collection( "GlobalConfig" )]
    public class LinkServiceTest : IDisposable 
	{
        /// <summary>
        /// 容器作用域
        /// </summary>
        private readonly IScope _scope;
        /// <summary>
        /// 链接服务
        /// </summary>
        private readonly ILinkService _linkService;
        /// <summary>
        /// 链接仓储
        /// </summary>
        private readonly ILinkRepository _linkRepository;
        /// <summary>
        /// 链接Dto
        /// </summary>
        private readonly LinkDto _linkDto;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public LinkServiceTest() 
		{
            _scope = Ioc.BeginScope();
            _linkRepository = _scope.Create<ILinkRepository>();
            _linkService = _scope.Create<ILinkService>();
            _linkDto = LinkDtoTest.Create();
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
		    var count = _linkRepository.Count();
			_linkRepository.Add( _linkDto.ToEntity());
            Assert.Equal( count + 1, _linkRepository.Count() );
        }
    }
}