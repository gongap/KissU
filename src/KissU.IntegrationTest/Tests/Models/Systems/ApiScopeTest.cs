﻿using Xunit;
using KissU.Domain.Systems.Models;

namespace KissU.IntegrationTest.Tests.Models.Systems 
{
    /// <summary>
    /// Api许可范围测试
    /// </summary>
    public partial class ApiScopeTest 
	{
        /// <summary>
        /// Api许可范围
        /// </summary>
        private ApiScope _apiScope;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ApiScopeTest() 
		{
            _apiScope = Create();
        }
    }
}