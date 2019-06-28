using Xunit;
using KissU.Domain.Systems.Models;

namespace KissU.IntegrationTest.Tests.Models.Systems 
{
    /// <summary>
    /// Api资源测试
    /// </summary>
    public partial class ApiTest 
	{
        /// <summary>
        /// Api资源
        /// </summary>
        private Api _api;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ApiTest() 
		{
            _api = Create();
        }
    }
}